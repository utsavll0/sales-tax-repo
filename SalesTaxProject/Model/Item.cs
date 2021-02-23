using System;
using System.Collections.Generic;
using System.Text;

namespace SalesTaxProject.Model
{
    public class Item
    {
        public string Description { get; set; }
        public Decimal ShelfPrice { get; set; }
        public bool isExempted { get; set; }
        public bool isImported { get; set; }
        public Decimal Tax { get; set; }
        public Decimal Cost { get; set; }
    }
}
