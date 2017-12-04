using EpamTask4;
using EpamTask4.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
   public class SaveService
    {
        public void Add(Sales sales)
        {
            var managerRepo = new ManagerRepository();
            var clientRepo = new ClientRepository();
            var productRepo = new ProductRepository();
            var saleRepo = new SaleRepository();

            var manager = managerRepo.GetByName(sales.Manager);
            if (manager == null)
            {
                managerRepo.Insert(new Manager() { ManagerName = sales.Manager });
            }

            foreach (var saleItem in sales.SaleItems)
            {
                var client = clientRepo.GetByName(saleItem.Client);
                if (client == null)
                {
                    clientRepo.Insert(new Client() { ClientName = saleItem.Client });
                }
            }

        }
    }
}
