using CoreLibrary;
using System;
using System.Collections.Generic;

namespace MockData
{
    public class MockoDB : IDataProvider
    {
        public string Name => "MockoDB";

        public IEnumerable<Product> GetProducts()
        {
            return new List<Product>
            {
                new Product{ Id = 2, Name = "Opti Pri", Price = 3001, Description = "Looks like truck, claims to be alien", LastModified = new DateTime(2007, 1, 1)  },
                new Product{ Id = 3, Name = "LinDos 9", Price = 577, Description = "Set of floppy discs.", LastModified = new DateTime(1970, 1, 1, 0, 0, 9)},
                new Product{ Id = 5, Name = "Xyzzy", Price = 12345, Description = "If you go alone - buy it!", LastModified = new DateTime(1999, 5, 8) },
                new Product{ Id = 8, Name = "End", Price = 9999, Description = ".", LastModified = new DateTime(2012, 12, 31, 5, 5, 5) },
            };
        }
    }
}
