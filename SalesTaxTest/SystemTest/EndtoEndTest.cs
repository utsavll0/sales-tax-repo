using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using SalesTaxProject.Model;

namespace SalesTaxTest.SystemTest
{
    [TestClass]
    public class EndtoEndTest
    {
        [TestMethod]
        public void Test1()
        {
            List<string> descriptions = new List<string>() { "1 imported box of chocolates at 10.00", "1 imported bottle of perfume at 47.50" };
            string expected = "1 imported box of chocolates: 10.50\n1 imported bottle of perfume: 54.65\nSales Taxes: 7.65\nTotal: 65.15";
            Receipt receipt = new Receipt();
            foreach (string description in descriptions)
            {
                receipt.AddItem(description);
            }
            receipt.CreateReceipt();
            string actual = receipt.GenerateReceipt();
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Test2()
        {
            List<string> descriptions = new List<string>() { "1 book at 12.49","1 music CD at 14.99","1 chocolate bar at 0.85" };
            string expected = "1 book: 12.49\n1 music CD: 16.49\n1 chocolate bar: 0.85\nSales Taxes: 1.50\nTotal: 29.83";
            Receipt receipt = new Receipt();
            foreach(string description in descriptions)
            {
                receipt.AddItem(description);
            }
            receipt.CreateReceipt();
            string actual = receipt.GenerateReceipt();
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Test3()
        {
            List<string> descriptions = new List<string>() { "1 imported bottle of perfume at 27.99","1 bottle of perfume at 18.99","1 packet of headache pills at 9.75","1 box of imported chocolates at 11.25" };
            string expected = "1 imported bottle of perfume: 32.19\n1 bottle of perfume: 20.89\n1 packet of headache pills: 9.75\n1 imported box of chocolates: 11.85\nSales Taxes: 6.70\nTotal: 74.68";
            Receipt receipt = new Receipt();
            foreach (string description in descriptions)
            {
                receipt.AddItem(description);
            }
            receipt.CreateReceipt();
            string actual = receipt.GenerateReceipt();
            Assert.AreEqual(expected, actual);
        }
    }
}
