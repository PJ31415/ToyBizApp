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
                case SortType.PriceDescending:
                    return products.OrderByDescending(p => p.Price);
                case SortType.PriceAscending:
                    return products.OrderBy(p => p.Price);
                case SortType.NameAscending:
                    return products.OrderBy(p => p.Name);
                case SortType.NameDescending:
                    return products.OrderByDescending(p => p.Name);
                default:
                    return products;
            }
        }
    }
}
