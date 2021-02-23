using Microsoft.VisualStudio.TestTools.UnitTesting;
using SalesTaxProject.Business;
using System;
using System.Collections.Generic;
using System.Text;

namespace SalesTaxTest.FormattersTests
{   
    [TestClass]
    public class RoundTests
    {
        [TestMethod]
        public void RoundTest1()
        {
            decimal numberUnderTest = 3.45643m;
            decimal expectedRoundedNumber = 3.45m;
            decimal actualRoundedNumber = Formatters.RoundDecimal(numberUnderTest);
            Assert.AreEqual(expectedRoundedNumber, actualRoundedNumber);
        }
        [TestMethod]
        public void RoundTest2()
        {
            decimal numberUnderTest = 212321.00m;
            decimal expectedRoundedNumber = 212321.00m;
            decimal actualRoundedNumber = Formatters.RoundDecimal(numberUnderTest);
            Assert.AreEqual(expectedRoundedNumber, actualRoundedNumber);
        }
        [TestMethod]
        public void RoundTest3()
        {
            decimal numberUnderTest = 45.15m;
            decimal expectedRoundedNumber = 45.15m;
            decimal actualRoundedNumber = Formatters.RoundDecimal(numberUnderTest);
            Assert.AreEqual(expectedRoundedNumber, actualRoundedNumber);
        }
        [TestMethod]
        public void RoundTest4()
        {
            decimal numberUnderTest = 0.0005m;
            decimal expectedRoundedNumber = 0.00m;
            decimal actualRoundedNumber = Formatters.RoundDecimal(numberUnderTest);
            Assert.AreEqual(expectedRoundedNumber, actualRoundedNumber);
        }
        [TestMethod]
        public void RoundTest5()
        {
            decimal numberUnderTest = 123.98765m;
            decimal expectedRoundedNumber = 124.00m;
            decimal actualRoundedNumber = Formatters.RoundDecimal(numberUnderTest);
            Assert.AreEqual(expectedRoundedNumber, actualRoundedNumber);
        }

    }
}
