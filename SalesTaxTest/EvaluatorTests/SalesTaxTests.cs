using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework.Internal;
using SalesTaxProject;
using SalesTaxProject.Model;
using SalesTaxProject.Business;
using System.Collections.Generic;

namespace EvaluatorTests.SalesTaxTest
{
    [TestClass]
    public class SalesTaxTests
    {
        [TestMethod]
        public void SalesTaxTest1()
        {
            List<Item> sampleItems = new List<Item>() { new Item { Tax = 0.15m }, new Item { Tax = 0.25m }, new Item { Tax = 0.12m } };
            decimal expectedSum = 0.52m;
            decimal actualSum = Evaluaters.CalculateSalesTax(sampleItems);
            Assert.AreEqual(expectedSum, actualSum, "The actual sum of taxes and expected sum of taxes are not equal");
        }

        [TestMethod]
        public void SalesTaxTest2()
        {
            List<Item> sampleItems = new List<Item>() { new Item { Tax = 1.15m }, new Item { Tax = 1.39m }, new Item { Tax = 2.38m }, new Item { Tax = 12.84m } };
            decimal expectedSum = 17.76m;
            decimal actualSum = Evaluaters.CalculateSalesTax(sampleItems);
            Assert.AreEqual(expectedSum, actualSum, "The actual sum of taxes and expected sum of taxes are not equal");
        }

        [TestMethod]
        public void SalesTaxTest3()
        {
            List<Item> sampleItems = new List<Item>() { new Item { Tax = 102134.25m }, new Item { Tax = 82132.75m }, new Item { Tax = 100023.15m } };
            decimal expectedSum = 284290.15m;
            decimal actualSum = Evaluaters.CalculateSalesTax(sampleItems);
            Assert.AreEqual(expectedSum, actualSum, "The actual sum of taxes and expected sum of taxes are not equal");
        }

    }
}
