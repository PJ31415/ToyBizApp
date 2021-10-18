using Logic;
using NUnit.Framework;

namespace Tests
{
    public class DiscountManagerTest
    {
        DiscountManager manager;
        [SetUp]
        public void Setup()
        {
            manager = new DiscountManager();
        }

        [Test]
        public void TestApplyDiscount()
        {
            var product = new ProductDTO { Id = 13, Name = "T-800", Price = 1984, Description = "Will be back." };
            var discounted = manager.ApplyDiscount(product);
            Assert.AreSame(product, discounted);
            Assert.AreEqual(product.Price, discounted.Price);
            Assert.AreEqual(992, discounted.FinalPrice, 1e-10);
            Assert.AreEqual(0.5, discounted.Discount, 1e-10);
        }

        [Test]
        public void TestToDTOThrowOnNull()
        {
            ProductDTO product = null;
            Assert.That(() => manager.ApplyDiscount(product), Throws.ArgumentNullException);
        }
    }
}