namespace Logic
{
    /// <summary>
    /// Data Transfer Object for <see cref="CoreLibrary.Product"/>
    /// </summary>
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; } = 0;
        public decimal FinalPrice { get => this.Price * (1 - this.Discount); }
        public string Description { get; set; }
    }
}
