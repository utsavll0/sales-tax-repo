using Microsoft.VisualStudio.TestTools.UnitTesting;
using SalesTaxProject.Business;
using SalesTaxProject.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace EvaluatorTests.SalesTaxTest
{
    [TestClass]
    public class FormatDescriptionTests
    {
        [TestMethod]
        public void FormatDescriptionTest1()
        {
            string description = "1 bottle of imported coca-cola";
            string expected = "1 imported bottle of coca-cola";
            string actual = Evaluaters.GetFormattedDescription(description);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void FormatDescriptionTest2()
        {
            string description = "1 imported cake";
            string expected = "1 imported cake";
            string actual = Evaluaters.GetFormattedDescription(description);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void FormatDescriptionTest3()
        {
            string description = "3 sands of imported time";
            string expected = "3 imported sands of time";
            string actual = Evaluaters.GetFormattedDescription(description);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void FormatDescriptionTest4()
        {
            string description = "3 pieces of chalk";
            string expected = "3 pieces of chalk";
            string actual = Evaluaters.GetFormattedDescription(description);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void FormatDescriptionTest5()
        {
            string description = "2 bundles of pencils imported";
            string expected = "2 imported bundles of pencils";
            string actual = Evaluaters.GetFormattedDescription(description);
            Assert.AreEqual(expected, actual);
        }
    }
}
