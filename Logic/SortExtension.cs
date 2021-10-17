using CoreLibrary;
using System.Collections.Generic;
using System.Linq;

namespace Logic
{
    public static class SortExtension
    {
        public static IEnumerable<Product> Sort(this IEnumerable<Product> products, SortType sort)
        {
            switch (sort)
            {
                case SortType.Expensive:
                    return products.OrderByDescending(p => p.Price);
                case SortType.Alphabetic:
                    return products.OrderBy(p => p.Name);
                case SortType.InverseAlphabetic:
                    return products.OrderByDescending(p => p.Name);
                default:
                    return products;
            }
        }
    }
}
