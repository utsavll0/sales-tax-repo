﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SalesTaxProject.Utils
{
    public class Helper
    {
        private static HashSet<string> ExemptedSet = new HashSet<string> { "chocolate", "book", "food", "pill", "medicine", "chips", "vegetables", "fish", "mango", "apple" };
        public static bool IsExempted(string ItemDescription)
        {
            return ExemptedSet.Any(s => ItemDescription.Contains(s));
        }

        public static bool IsImported(string ItemDescription)
        {
            return ItemDescription.ToLower().Contains("imported");
        }
    }
}