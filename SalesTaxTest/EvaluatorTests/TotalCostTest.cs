using Microsoft.VisualStudio.TestTools.UnitTesting;
using SalesTaxProject.Business;
using SalesTaxProject.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace EvaluatorTests.SalesTaxTest
{
    [TestClass]
    public class TotalCostTest
    {
        [TestMethod]
        public void TotalCostTest1()
        {
            List<Item> sampleItems = new List<Item>() { new Item { Cost = 0.15m }, new Item { Cost = 0.25m }, new Item { Cost = 0.12m } };
            decimal expectedSum = 0.52m;
            decimal actualSum = Evaluaters.CalculateTotalCost(sampleItems);
            Assert.AreEqual(expectedSum, actualSum, "The actual sum of costs and expected sum of taxes are not equal");
        }

        [TestMethod]
        public void TotalCostTest2()
        {
            List<Item> sampleItems = new List<Item>() { new Item { Cost = 1.15m }, new Item { Cost = 1.39m }, new Item { Cost = 2.38m }, new Item { Cost = 12.84m } };
            decimal expectedSum = 17.76m;
            decimal actualSum = Evaluaters.CalculateTotalCost(sampleItems);
            Assert.AreEqual(expectedSum, actualSum, "The actual sum of costs and expected sum of taxes are not equal");
        }

        [TestMethod]
        public void TotalCostTest3()
        {
            List<Item> sampleItems = new List<Item>() { new Item { Cost = 102134.25m }, new Item { Cost = 82132.75m }, new Item { Cost = 100023.15m } };
            decimal expectedSum = 284290.15m;
            decimal actualSum = Evaluaters.CalculateTotalCost(sampleItems);
            Assert.AreEqual(expectedSum, actualSum, "The actual sum of costs and expected sum of taxes are not equal");
        }
    }
}
