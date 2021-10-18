using System;

namespace CoreLibrary
{
    /// <summary>
    /// Data object for our products
    /// </summary>
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        /// <summary>
        /// Our initial price.
        /// In the end type may depend on data sources we use.
        /// </summary>
        public decimal Price { get; set; }
        public string Description { get; set; }
        public DateTime LastModified { get; set; }
    }
}
