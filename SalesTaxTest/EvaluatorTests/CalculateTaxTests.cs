using Microsoft.VisualStudio.TestTools.UnitTesting;
using SalesTaxProject.Business;
using SalesTaxProject.Exceptions;
using SalesTaxProject.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace EvaluatorTests.SalesTaxTest
{
    [TestClass]
    public class CalculateTaxTests
    {
        [TestMethod]
        public void CalculateTaxTest1()
        {
            Item sampleItem = new Item() { ShelfPrice = 47.50m, isImported = true, isExempted = false };
            decimal expected = 7.15m;
            decimal actual = Evaluaters.CalculateTaxForItem(sampleItem);
            Assert.AreEqual(expected, actual, "The actual calculated tax and expected tax are not equal");

        }
        [TestMethod]
        public void CalculateTaxTest2()
        {
            Item sampleItem = new Item() { ShelfPrice = 12.25m, isImported = false, isExempted = true };
            decimal expected = 0.00m;
            decimal actual = Evaluaters.CalculateTaxForItem(sampleItem);
            Assert.AreEqual(expected, actual, "The actual calculated tax and expected tax are not equal");
        }
        [TestMethod]
        public void CalculateTaxTest3()
        {
            Item sampleItem = new Item() { ShelfPrice = 97.99m, isImported = true, isExempted = true };
            decimal expected = 4.90m;
            decimal actual = Evaluaters.CalculateTaxForItem(sampleItem);
            Assert.AreEqual(expected, actual, "The actual calculated tax and expected tax are not equal");
        }
        [TestMethod]
        public void CalculateTaxTest4()
        {
            Item sampleItem = new Item() { ShelfPrice = 43.57m, isImported = false, isExempted = false };
            decimal expected = 4.35m;
            decimal actual = Evaluaters.CalculateTaxForItem(sampleItem);
            Assert.AreEqual(expected, actual, "The actual calculated tax and expected tax are not equal");
        }
        [TestMethod]
        public void CalculateTaxTest5()
        {
            Item sampleItem = new Item() { ShelfPrice = -43.57m, isImported = false, isExempted = false };
            Assert.ThrowsException<ShelfPriceNegetiveException>(() => Evaluaters.CalculateTaxForItem(sampleItem),"Exception for negetive shelf price was not thrown");
        }
    }
}
