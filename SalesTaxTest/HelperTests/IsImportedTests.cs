using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using SalesTaxProject.Utils;

namespace SalesTaxTest.HelperTests
{
    [TestClass]
    public class IsImportedTests
    {
        [TestMethod]
        public void IsImportedTest1()
        {
            string description = "1 pack of imported cigerrates";
            bool expectedImported = true;
            bool actualImported = Helper.IsImported(description);
            Assert.AreEqual(expectedImported, actualImported);
        }
        [TestMethod]
        public void IsImportedTest2()
        {
            string description = "1 bundle of joy";
            bool expectedImported = false;
            bool actualImported = Helper.IsImported(description);
            Assert.AreEqual(expectedImported, actualImported);
        }
        [TestMethod]
        public void IsImportedTest3()
        {
            string description = "4 cartons of mangoes";
            bool expectedImported = false;
            bool actualImported = Helper.IsImported(description);
            Assert.AreEqual(expectedImported, actualImported);
        }
        [TestMethod]
        public void IsImportedTest4()
        {
            string description = "235 kilos of weights imported";
            bool expectedImported = true;
            bool actualImported = Helper.IsImported(description);
            Assert.AreEqual(expectedImported, actualImported);
        }
    }
}
