using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
   public class SaleItem
    {
        public DateTime Time { get; set; }
        public string Client { get; set; }
        public string Product { get; set; }
        public decimal Sum { get; set; }
    }
}
