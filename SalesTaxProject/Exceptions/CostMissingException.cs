using System;
using System.Collections.Generic;
using System.Text;

namespace SalesTaxProject.Exceptions
{
    public class CostMissingException : Exception
    {
        public CostMissingException(string message) : base(message) { }

        public override string ToString()
        {
            return Message;
        }
    }
}
