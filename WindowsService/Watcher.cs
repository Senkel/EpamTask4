using Business;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsService
{
   public class Watcher : IDisposable
    {
        private BlockingCollection<string> queue = new BlockingCollection<string>(new ConcurrentQueue<string>());

        private FileSystemWatcher _watcher;

        private string _dir = ConfigurationManager.AppSettings["sourceURL"];
        private string _dirComplete = ConfigurationManager.AppSettings["targetURL"];

        public Watcher(int threadsNumber)
        {
            if (!Directory.Exists(_dirComplete)) Directory.CreateDirectory(_dirComplete);

            _watcher = new FileSystemWatcher(_dir, "*.csv");

            Run();

            ProcessFiles();

            Threading(threadsNumber);
        }

        private void Threading(int n)
        {
            var tasks = new Task[n];
            for (int i = 0; i < n; i++)
            {
                tasks[i] = Task.Factory.StartNew(Processing, TaskCreationOptions.LongRunning);
             tasks[i] = Task.Run(() => Processing());
            }

            try
            {
                int index = Task.WaitAny(tasks);
            }
            catch (AggregateException)
            {
                Console.WriteLine("An exception occurred.");
            }
        }

        private void ProcessFiles()
        {
            foreach (var file in Directory.GetFiles(_dir))
            {
                AddToQueue(file);
            }
        }

        private void OnCreated(object sender, FileSystemEventArgs e)
        {
            AddToQueue(e.FullPath);
        }

        private void AddToQueue(string path)
        {
            queue.Add(path);
        }

        private void Processing()
        {
            while (true)
            {
                var file = queue.Take();
                var saleManager = new SalesManager(file);
                var filename = Path.GetFileName(file);
                if (File.Exists(Path.Combine(_dirComplete, filename)))
                {
                    File.Delete(file);
                }
                else
                {
                    File.Move(file, Path.Combine(_dirComplete, filename));
                }
            }
        }

        public void Run()
        {
            if (_watcher != null && !_watcher.EnableRaisingEvents)
            {
                _watcher.Created += new FileSystemEventHandler(OnCreated);
                _watcher.EnableRaisingEvents = true;
            }
        }

        public void Stop()
        {
            
            if (_watcher != null && _watcher.EnableRaisingEvents)
            {
                _watcher.Created -= new FileSystemEventHandler(OnCreated);
                _watcher.EnableRaisingEvents = false;
                
            }
        }

        public void Dispose()
        {
            if (_watcher != null)
            {
                Stop();
                _watcher.Dispose();
                _watcher = null;
            }
        }

        ~Watcher()
        {
            Dispose();
        }
    }
}
