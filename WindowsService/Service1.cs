using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace WindowsService
{
    public partial class Service1 : ServiceBase
    {
        private Watcher watcher;

        public Service1()
        {
            InitializeComponent();
        }

        public void OnDebug()
        {
            OnStart(null);
        }

        protected override void OnStart(string[] args)
        {
            watcher = new Watcher(10);
        }

        protected override void OnStop()
        {
            try
            {
                watcher.Stop();
            }
            finally
            {
                watcher.Dispose();
            }
        }
    }
}
