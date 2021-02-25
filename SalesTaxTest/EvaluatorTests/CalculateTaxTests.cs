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
            decimal shelfPrice = 47.50m; bool isImported = true; bool isExempted = false;
            decimal expected = 7.15m;
            Evaluater evaluater = new Evaluater();
            decimal actual = evaluater.CalculateTaxForItem(shelfPrice, isImported, isExempted);
            Assert.AreEqual(expected, actual, "The actual calculated tax and expected tax are not equal");

        }
        [TestMethod]
        public void CalculateTaxTest2()
        {
            decimal shelfPrice = 12.25m; bool isImported = false; bool isExempted = true;
            decimal expected = 0.00m;
            Evaluater evaluater = new Evaluater();
            decimal actual = evaluater.CalculateTaxForItem(shelfPrice, isImported, isExempted);
            Assert.AreEqual(expected, actual, "The actual calculated tax and expected tax are not equal");
        }
        [TestMethod]
        public void CalculateTaxTest3()
        {
            decimal shelfPrice = 97.99m; bool isImported = true; bool isExempted = true;
            decimal expected = 4.90m;
            Evaluater evaluater = new Evaluater();
            decimal actual = evaluater.CalculateTaxForItem(shelfPrice, isImported, isExempted);
            Assert.AreEqual(expected, actual, "The actual calculated tax and expected tax are not equal");
        }
        [TestMethod]
        public void CalculateTaxTest4()
        {
            decimal shelfPrice = 43.57m; bool isImported = false; bool isExempted = false;
            decimal expected = 4.35m;
            Evaluater evaluater = new Evaluater();
            decimal actual = evaluater.CalculateTaxForItem(shelfPrice, isImported, isExempted);
            Assert.AreEqual(expected, actual, "The actual calculated tax and expected tax are not equal");
        }
        [TestMethod]
        public void CalculateTaxTest5()
        {
            decimal shelfPrice = -43.57m; bool isImported = false; bool isExempted = false;
            Evaluater evaluater = new Evaluater();
            Assert.ThrowsException<ShelfPriceNegetiveException>(() => evaluater.CalculateTaxForItem(shelfPrice,isImported,isExempted),"Exception for negetive shelf price was not thrown");
        }
    }
}
