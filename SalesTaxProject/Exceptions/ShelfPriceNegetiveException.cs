using System;
using System.Collections.Generic;
using System.Text;

namespace SalesTaxProject.Exceptions
{
    public class ShelfPriceNegetiveException : Exception
    {
        public ShelfPriceNegetiveException(string message) : base(message) { }

        public override string ToString()
        {
            return Message;
        }
    }
}
