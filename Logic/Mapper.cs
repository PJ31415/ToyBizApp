using System;

namespace Logic
{
    public class Mapper
    {
        public ProductDTO ToDTO(CoreLibrary.Product product)
        {
            if (product == null) throw new ArgumentNullException(nameof(product));
            return new ProductDTO
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Description = product.Description ?? "N/A"
            };
        }

        // reverse mapping or merging with saved would be needed if application allowed editing entities
    }
}
