using SalesTaxProject.Business;
using SalesTaxProject.Exceptions;
using SalesTaxProject.Model;
using SalesTaxProject.Utils;
using System;
using System.Collections.Generic;

namespace SalesTaxProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to reciept generator!!! Please enter the number of items which were bought...");
            int numOfItems = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Enter the items line by line...");
            Receipt receipt = new Receipt();
            try
            {
                for (int i = 0; i < numOfItems; i++)
                {
                    string description = Console.ReadLine();
                    receipt.AddItem(description);
                }
                receipt.CreateReceipt();
                string summary = receipt.GenerateReceipt();
                Console.WriteLine(summary);
            }
            catch (CostMissingException exception)
            {
                Console.WriteLine(exception.Message);
            }
            catch (ShelfPriceNegetiveException exception)
            {
                Console.WriteLine(exception.Message);
            }

        }
    }
}
