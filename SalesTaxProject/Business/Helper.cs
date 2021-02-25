using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SalesTaxProject.Utils
{
    public class Helper
    {
        private static HashSet<string> ExemptedSet = new HashSet<string> { "chocolate", "book", "food", "pill", "medicine", "chips", "vegetables", "fish", "mango", "apple" };
        public static bool IsExempted(string itemDescription)
        {
            return ExemptedSet.Any(s => itemDescription.Contains(s));
        }

        public static bool IsImported(string itemDescription)
        {
            return itemDescription.ToLower().Contains("imported");
        }
        public static decimal RoundDecimal(decimal number)
        {
            return Math.Round(number / 0.05m, MidpointRounding.AwayFromZero) * 0.05m;
        }
    }
}
