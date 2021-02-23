using Microsoft.VisualStudio.TestTools.UnitTesting;
using SalesTaxProject.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace SalesTaxTest.HelperTests
{
    [TestClass]
    public class IsExemptedTests
    {
        [TestMethod]
        public void IsExemptedTest1()
        {
            string description = "1 pack of imported mangoes";
            bool expectedExempted = true;
            bool actualExempted = Helper.IsExempted(description);
            Assert.AreEqual(expectedExempted, actualExempted);
        }
        [TestMethod]
        public void IsExemptedTest2()
        {
            string description = "1 bundle of joy";
            bool expectedExempted = false;
            bool actualExempted = Helper.IsExempted(description);
            Assert.AreEqual(expectedExempted, actualExempted);
        }
        [TestMethod]
        public void IsExemptedTest3()
        {
            string description = "4 cartons of alcohal";
            bool expectedExempted = false;
            bool actualExempted = Helper.IsExempted(description);
            Assert.AreEqual(expectedExempted, actualExempted);
        }
        [TestMethod]
        public void IsExemptedTest4()
        {
            string description = "235 kilos of calpol pills";
            bool expectedExempted = true;
            bool actualExempted = Helper.IsExempted(description);
            Assert.AreEqual(expectedExempted, actualExempted);
        }
        [TestMethod]
        public void IsExemptedTest5()
        {
            string description = "1 pack of imported medicines";
            bool expectedExempted = true;
            bool actualExempted = Helper.IsExempted(description);
            Assert.AreEqual(expectedExempted, actualExempted);
        }
        [TestMethod]
        public void IsExemptedTest6()
        {
            string description = "1 piece of food";
            bool expectedExempted = true;
            bool actualExempted = Helper.IsExempted(description);
            Assert.AreEqual(expectedExempted, actualExempted);
        }
    }
}
