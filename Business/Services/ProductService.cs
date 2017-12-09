using EpamTask4;
using EpamTask4.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
   public class ProductService
    {
        public Product GetOrCreate(string title)
        {
            var productRepo = new ProductRepository();

            Product product = productRepo.GetByTitle(title);

            if (product == null)
            {
                product = new Product() { Title = title };
                
                productRepo.Insert(product);
            }

            return product;
        }
    }
}
