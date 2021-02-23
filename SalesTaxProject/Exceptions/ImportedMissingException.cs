using System;
using System.Collections.Generic;
using System.Text;

namespace SalesTaxProject.Exceptions
{
    public class ImportedMissingException : Exception
    {
        public ImportedMissingException(string message) : base(message) { }

        public override string ToString()
        {
            return Message;
        }
    }
}
