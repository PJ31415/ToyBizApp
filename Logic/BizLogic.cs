using CoreLibrary;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Logic
{
    /// <summary>
    /// Toy busines logic engine
    /// </summary>
    public class BizLogic
    {
        /// <summary>
        /// Initialize business logic engine
        /// </summary>
        /// <param name="dataProvider">data source</param>
        public BizLogic(IDataProvider dataProvider)
        {
            this.dataProvider = dataProvider ?? throw new ArgumentNullException();
        }

        private readonly IDataProvider dataProvider;

        public IEnumerable<ProductDTO> GetOffers(SortType sortType, int pageSize = 12, int page = 0)
        {
            var offers = dataProvider.GetProducts();
            var mapper = new Mapper();
            var discountManager = new DiscountManager();

            return offers.Sort(sortType).Skip(page * pageSize).Take(pageSize)
                .Select(p => { var dto = mapper.ToDTO(p); discountManager.ApplyDiscount(dto); return dto; });
        }
    }
}
