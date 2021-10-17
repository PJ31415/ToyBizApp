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
        /// Stored in perfect data type for financial information (joke), but sufficient for toy app.
        /// </summary>
        public double Price { get; set; }
        public string Description { get; set; }
        public DateTime LastModified { get; set; }
    }
}
