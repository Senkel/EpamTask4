using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class CsvParser
    {
        public List<SaleItem> Parse(string file)
        {
            var textReader = new StreamReader(file);
            var csv = new CsvReader(textReader);
            csv.Configuration.HasHeaderRecord = false;
            var result = new List<SaleItem>();
            while (csv.Read())
            {
                var time = csv.GetField<DateTime>(0);
                var client = csv.GetField<string>(1);
                var product = csv.GetField<string>(2);
                var sum = csv.GetField<decimal>(3);

                var item = new SaleItem()
                {
                    Time = time,
                    Client = client,
                    Product = product,
                    Sum = sum
                };

                result.Add(item);
            }

            return result;
        }
    }
}
