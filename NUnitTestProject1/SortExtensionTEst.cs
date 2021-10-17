using NUnit.Framework;
using Logic;
using System.Linq;
using CoreLibrary;
using System.Collections.Generic;
using MockData;

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
        public void TestAlphabeticOrder()
        {
            var original = data.GetProducts();
            var sorted = original.Sort(SortType.Alphabetic);
            Assert.AreEqual(4, sorted.Count());

            var offerArray = sorted.ToArray();
            Assert.AreEqual("End", offerArray[0].Name);
            Assert.AreEqual("LinDos 9", offerArray[1].Name);
            Assert.AreEqual("Opti Pri", offerArray[2].Name);
            Assert.AreEqual("Xyzzy", offerArray[3].Name);
        }

        [Test]
        public void TestInverseAlphabeticOrder()
        {
            var original = data.GetProducts();
            var sorted = original.Sort(SortType.InverseAlphabetic);
            Assert.AreEqual(4, sorted.Count());

            var offerArray = sorted.ToArray();
            Assert.AreEqual("Xyzzy", offerArray[0].Name);
            Assert.AreEqual("Opti Pri", offerArray[1].Name);
            Assert.AreEqual("LinDos 9", offerArray[2].Name);
            Assert.AreEqual("End", offerArray[3].Name);
        }

        [Test]
        public void TestExpensiveOrder()
        {
            var original = data.GetProducts();
            var sorted = original.Sort(SortType.Expensive);
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
    }
}