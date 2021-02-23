using Microsoft.VisualStudio.TestTools.UnitTesting;
using SalesTaxProject.Business;
using SalesTaxProject.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace EvaluatorTests.SalesTaxTest
{
    [TestClass]
    public class CalculateCostTests
    {
        [TestMethod]
        public void CalculateCostTest1()
        {
            Item sampleItem = new Item() { ShelfPrice = 47.50m, Tax = 0.35m };
            decimal expected = 47.85m;
            decimal actual = Evaluaters.CalculateCostForItem(sampleItem);
            Assert.AreEqual(expected, actual, "The actual calculated tax and expected tax are not equal");
        }
        [TestMethod]
        public void CalculateCostTest2()
        {
            Item sampleItem = new Item() { ShelfPrice = 91234.50m, Tax = 21323.35m };
            decimal expected = 112557.85m;
            decimal actual = Evaluaters.CalculateCostForItem(sampleItem);
            Assert.AreEqual(expected, actual, "The actual calculated tax and expected tax are not equal");
        }
        [TestMethod]
        public void CalculateCostTest3()
        {
            Item sampleItem = new Item() { ShelfPrice = 28132.50m, Tax = 0.35m };
            decimal expected = 28132.85m;
            decimal actual = Evaluaters.CalculateCostForItem(sampleItem);
            Assert.AreEqual(expected, actual, "The actual calculated tax and expected tax are not equal");
        }
    }
}
