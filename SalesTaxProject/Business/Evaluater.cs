using SalesTaxProject.Exceptions;
using SalesTaxProject.Interface;
using SalesTaxProject.Model;
using SalesTaxProject.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SalesTaxProject.Business
{
    public class Evaluater : IEvaluator
    {
        public decimal CalculateTaxForItem(decimal shelfPrice, bool isImported, bool isExempted)
        {
            decimal tax = 0.0m;
            if (shelfPrice < 0)
            {
                throw new ShelfPriceNegetiveException($"Shelf price for was negetive");
            }
            if (isExempted == true && isImported == false)
            {
                tax = 0.00m;
            }
            else if (isExempted == true && isImported == true)
            {
                tax = shelfPrice * 5.00m / 100.00m;
            }
            else if (isImported == false)
            {
                tax = shelfPrice * 10.00m / 100.00m;
            }
            else
            {
                tax = shelfPrice * 15.00m / 100.00m;
            }
            return Helper.RoundDecimal(tax);
        }

        public decimal CalculateSum(List<decimal> list)
        {
            decimal sum = 0.00m;
            foreach(decimal number in list)
            {
                sum = sum + number;
            }
            return sum;
        }

        public decimal CalculateCost(decimal shelfPrice,decimal tax)
        {
            return shelfPrice + tax;
        }
    }
}
