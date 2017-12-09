using EpamTask4;
using EpamTask4.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class ManagerService
    {
        public Manager GetOrCreate(string name)
        {
            var managerRepo = new ManagerRepository();

            Manager manager = managerRepo.GetByName(name);

           

            if (manager == null)
            {
                manager = new Manager() { ManagerName = name };
               
                managerRepo.Insert(manager);
            }

            return manager;
        }
    }
}
