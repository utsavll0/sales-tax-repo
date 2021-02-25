using System;
using System.Collections.Generic;
using System.Text;

namespace SalesTaxProject.Interface
{
    public interface IReceipt
    {
        public void AddItem(string description);
        public void CreateReceipt();
        public string GenerateReceipt();
    }
}
