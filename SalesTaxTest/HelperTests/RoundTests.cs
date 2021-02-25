using Microsoft.VisualStudio.TestTools.UnitTesting;
using SalesTaxProject.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace SalesTaxTest.HelperTests
{
    [TestClass]
    public class RoundTests
    {
        [TestMethod]
        public void Test1()
        {
            decimal number = 0.5625m;
            decimal expected = 0.6m;
            decimal actual = Helper.RoundDecimal(number);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Test2()
        {
            decimal number = 134.52m;
            decimal expected = 134.55m;
            decimal actual = Helper.RoundDecimal(number);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Test3()
        {
            decimal number = 1.34657483m;
            decimal expected = 1.35m;
            decimal actual = Helper.RoundDecimal(number);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Test4()
        {
            decimal number = 112.99m;
            decimal expected = 113m;
            decimal actual = Helper.RoundDecimal(number);
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Test5()
        {
            decimal number = 135.549m;
            decimal expected = 135.55m;
            decimal actual = Helper.RoundDecimal(number);
            Assert.AreEqual(expected, actual);
        }
    }
}
