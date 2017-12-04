using Business.Services;
using EpamTask4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
   public class SalesManager
    {
        public SalesManager(string file)
        {
            var fileParser = new SalesParser();
            var fileInfo = fileParser.Parse(file);
            if (fileInfo != null)
            {
                Manager manager = new ManagerService().GetOrCreate(fileInfo.Manager);

                foreach (var saleItem in fileInfo.SaleItems)
                {
                    Client client = new ClientService().GetOrCreate(saleItem.Client);
                    Product product = new ProductService().GetOrCreate(saleItem.Product);

                    var sale = new SaleService();
                    sale.Create(
                        saleItem.Time,
                        manager.Id,
                        client.Id,
                        product.Id,
                        saleItem.Sum
                        );
                }
            }
        }
    }
}
