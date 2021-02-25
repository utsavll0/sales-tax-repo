using SalesTaxProject.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SalesTaxProject.Interface
{
    interface IEvaluator
    {
        public decimal CalculateTaxForItem(decimal shelfPrice, bool isImported, bool isExempted);
        public decimal CalculateSum(List<decimal> list);
        public decimal CalculateCost(decimal shelfPrice, decimal tax);
    }
}
