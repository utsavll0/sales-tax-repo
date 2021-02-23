using Microsoft.VisualStudio.TestTools.UnitTesting;
using SalesTaxProject.Business;
using SalesTaxProject.Exceptions;
using SalesTaxProject.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SalesTaxTest.EvaluatorTests
{
    [TestClass]
    public class ProcessRawItemsTests
    {

        [TestMethod]
        public void ProcessRawItemsTest1()
        {
            List<string> rawItem = new List<string>() { "1 box of chocolate at 1.50","1 box of imported ciggerates at 2.25" };
            List<Item> expected = new List<Item>() { new Item { Description="1 box of chocolate",isExempted=true,isImported=false,ShelfPrice=1.50m,Cost=0.00m,Tax=0.00m},
                                                       new Item{    Description="1 box of imported ciggerates",isExempted=false,isImported=true,ShelfPrice=2.25m,Cost=0.00m,Tax=0.00m } };
            List<Item> actual = Evaluaters.ProcessRawItems(rawItem);
            Assert.AreEqual(actual.Count, expected.Count);
            for(int i = 0; i < actual.Count; i++)
            {
                Assert.IsTrue(actual[i].Equals(expected[i]));
            }
        }
        [TestMethod]
        public void ProcessRawItemsTest2()
        {
            List<string> rawItem = new List<string>() { "1 box of chocolate 1.50", "1 box of imported ciggerates at 2.25" };
            Assert.ThrowsException<CostMissingException>(() => Evaluaters.ProcessRawItems(rawItem));
        }
    }
}
