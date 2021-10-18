using System;

namespace Logic
{
    public class DiscountManager
    {
        public ProductDTO ApplyDiscount(ProductDTO product)
        {
            if (product == null) throw new ArgumentNullException(nameof(product));
            product.Discount = product.Name.Length / 10.0M;
            return product;
        }
    }
}
