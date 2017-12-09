using EpamTask4;
using EpamTask4.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
   public class SaleService
    {
        public void Create(DateTime time, int managerId, int clientId, int productId, decimal sum)
        {
            var saleRepo = new SaleRepository();

            var sale = new InfoSale()
            {
                SaleDate = time,
                Sum = sum,
                ID_Manager = managerId,
                ID_Client = clientId,
                ID_Product = productId
            };
            
            saleRepo.Insert(sale);
        }
    }
}
