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
            List<decimal> sampleItems = new List<decimal>() {  0.15m,  0.25m , 0.12m  };
            decimal expectedSum = 0.52m;
            Evaluater evaluater = new Evaluater();
            decimal actualSum = evaluater.CalculateSum(sampleItems);
            Assert.AreEqual(expectedSum, actualSum, "The actual sum of costs and expected sum of taxes are not equal");
        }

        [TestMethod]
        public void TotalCostTest2()
        {
            List<decimal> sampleItems = new List<decimal>() { 1.15m, 1.39m, 2.38m, 12.84m };
            decimal expectedSum = 17.76m;
            Evaluater evaluater = new Evaluater();
            decimal actualSum = evaluater.CalculateSum(sampleItems);
            Assert.AreEqual(expectedSum, actualSum, "The actual sum of costs and expected sum of taxes are not equal");
        }

        [TestMethod]
        public void TotalCostTest3()
        {
            List<decimal> sampleItems = new List<decimal>() { 102134.25m, 82132.75m, 100023.15m };
            decimal expectedSum = 284290.15m;
            Evaluater evaluater = new Evaluater();
            decimal actualSum = evaluater.CalculateSum(sampleItems);
            Assert.AreEqual(expectedSum, actualSum, "The actual sum of costs and expected sum of taxes are not equal");
        }
    }
}
