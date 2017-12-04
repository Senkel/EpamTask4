using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class Sales
    {
        public string Manager { get; set; }
        public DateTime Date { get; set; }
        public List<SaleItem> SaleItems { get; set; }
    }
}
