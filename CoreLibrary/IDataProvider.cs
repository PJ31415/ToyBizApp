using System.Collections.Generic;

namespace CoreLibrary
{
    public interface IDataProvider
    {
        string Name { get; }
        IEnumerable<Product> GetProducts();
    }
}
