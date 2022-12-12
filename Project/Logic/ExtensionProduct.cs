using Project.Models;
using System.Collections.Generic;
using System.Linq;

namespace Project.Logic
{
    public class ExtensionProduct
    {
        public static List<long> GetPriceMinMax(string price)
        {
            long min = 0;
            long max = 0;
            if (price.Equals("<500")) { min = 0; max = 500000000; }
            if (price.Equals("500-800")) { min = 500000000; max = 800000000; }
            if (price.Equals("800-1t")) { min = 800000000; max = 1000000000; }
            if (price.Equals("1-3t")) { min = 1000000000; max = 3000000000; }
            if (price.Equals("3-7t")) { min = 3000000000; max = 7000000000; }
            if (price.Equals("7-10t")) { min = 7000000000; max =10000000000; }
            if (price.Equals("10-20t")) { min = 10000000000; max = 20000000000; }
            if (price.Equals(">20t")) { min = 20000000000; max = 0; }
            List<long> result = new List<long>();
            result.Add(min); result.Add(max);
            return result;
        }
        public static List<Product> FilterSort(List<Product> pro, string sort)
        {
            if (sort.Equals("desdate")) { pro = pro.OrderByDescending(x => x.DateUp).ToList(); }
            if (sort.Equals("asedate")) { pro = pro.OrderBy(x => x.DateUp).ToList(); }
            if (sort.Equals("aseprice")) { pro = pro.OrderBy(x => x.NoPrice).ToList(); }
            if (sort.Equals("desprice")) { pro = pro.OrderByDescending(x => x.NoPrice).ToList(); }
            return pro;
        }
    }
}
