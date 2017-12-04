using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Business
{
   public class SalesParser
    {
        public Sales Parse(string path)
        {
            var file = System.IO.Path.GetFileName(path);
            var rgx = new Regex("^(?<manager>\\w*)_(?<dd>\\d{2})(?<mm>\\d{2})(?<yyyy>\\d{4}).csv$");

            var matches = rgx.Matches(file);
            if (matches.Count > 0)
            {
                var groups = matches[0].Groups;

                var manager = groups["manager"].Value;

                var day = int.Parse(groups["dd"].Value);
                var month = int.Parse(groups["mm"].Value);
                var year = int.Parse(groups["yyyy"].Value);

                var date = new DateTime(year, month, day);

                var csv = new CsvParser();

                var sales = new Sales()
                {
                    Date = date,
                    Manager = manager,
                    SaleItems = csv.Parse(path)
                };
                return sales;
            }
            else
            {
                return null;
            }
        }
    }
}
