using Logic;
using MockData;
using NUnit.Framework;
using System.Linq;

namespace Tests
{
    public class SortExtensionTest
    {
        MockoDB data;
        [SetUp]
        public void Setup()
        {
            // as we have mock data implemented already why not use it for tests
            data = new MockoDB();
        }

        [Test]
        public void TestNameAscendingOrder()
        {
            var original = data.GetProducts();
            var sorted = original.Sort(SortType.NameAscending);
            Assert.AreEqual(4, sorted.Count());

            var offerArray = sorted.ToArray();
            Assert.AreEqual("End", offerArray[0].Name);
            Assert.AreEqual("LinDos 9", offerArray[1].Name);
            Assert.AreEqual("Opti Pri", offerArray[2].Name);
            Assert.AreEqual("Xyzzy", offerArray[3].Name);
        }

        [Test]
        public void TestNameDescendingOrder()
        {
            var original = data.GetProducts();
            var sorted = original.Sort(SortType.NameDescending);
            Assert.AreEqual(4, sorted.Count());

            var offerArray = sorted.ToArray();
            Assert.AreEqual("Xyzzy", offerArray[0].Name);
            Assert.AreEqual("Opti Pri", offerArray[1].Name);
            Assert.AreEqual("LinDos 9", offerArray[2].Name);
            Assert.AreEqual("End", offerArray[3].Name);
        }

        [Test]
        public void TestPriceDescendingOrder()
        {
            var original = data.GetProducts();
            var sorted = original.Sort(SortType.PriceDescending);
            Assert.AreEqual(4, sorted.Count());

            var offerArray = sorted.ToArray();
            Assert.AreEqual("Xyzzy", offerArray[0].Name);
            Assert.AreEqual("End", offerArray[1].Name);
            Assert.AreEqual("Opti Pri", offerArray[2].Name);
            Assert.AreEqual("LinDos 9", offerArray[3].Name);
            Assert.AreEqual(12345, offerArray[0].Price);
            Assert.AreEqual(9999, offerArray[1].Price);
            Assert.AreEqual(3001, offerArray[2].Price);
            Assert.AreEqual(577, offerArray[3].Price);
        }

        [Test]
        public void TestPriceAscendingOrder()
        {
            var original = data.GetProducts();
            var sorted = original.Sort(SortType.PriceAscending);
            Assert.AreEqual(4, sorted.Count());

            var offerArray = sorted.ToArray();
            Assert.AreEqual("LinDos 9", offerArray[0].Name);
            Assert.AreEqual("Opti Pri", offerArray[1].Name);
            Assert.AreEqual("End", offerArray[2].Name);
            Assert.AreEqual("Xyzzy", offerArray[3].Name);
            Assert.AreEqual(577, offerArray[0].Price);
            Assert.AreEqual(3001, offerArray[1].Price);
            Assert.AreEqual(9999, offerArray[2].Price);
            Assert.AreEqual(12345, offerArray[3].Price);
        }
    }
}