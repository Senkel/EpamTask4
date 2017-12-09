using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamTask4.Repository
{
   public class ManagerRepository:BasicRepository<Manager>
    {
        public Manager GetByName(string name)
        {
            using (var entities = new MyDBEntities())
            {
                return entities.Manager
                    .FirstOrDefault(m => m.ManagerName == name);
            }
        }
    }
}
