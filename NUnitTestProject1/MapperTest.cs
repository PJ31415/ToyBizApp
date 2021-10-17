using NUnit.Framework;
using Logic;
using CoreLibrary;
using System;

namespace Tests
{
    public class MapperTests
    {
        Mapper mapper;
        [SetUp]
        public void Setup()
        {
            mapper = new Mapper();
        }

        [Test]
        public void TestToDTO()
        {
            var product = new Product { Id = 21, Name = "Blackjack", Price = 21, Description = "Hit it.", LastModified = new DateTime(2121, 1, 10, 21, 21, 21) };
            var dto = mapper.ToDTO(product);
            Assert.AreEqual(product.Id, dto.Id);
            Assert.AreEqual(product.Name, dto.Name);
            Assert.AreEqual(product.Price, dto.Price);
            Assert.AreEqual(product.Price, dto.FinalPrice);
            Assert.Zero(dto.Discount);
        }

        [Test]
        public void TestToDTOThrowOnNull()
        {
            Product product = null;
            Assert.That(() => mapper.ToDTO(product), Throws.ArgumentNullException);
        }
    }
}