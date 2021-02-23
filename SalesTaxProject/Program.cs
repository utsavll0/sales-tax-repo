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
            List<string> rawListOfitems = Formatters.ReadInput(numOfItems);
            try
            {
                List<Item> finalItems = Evaluaters.ProcessRawItems(rawListOfitems);
                List<Item> costEvaluatedItems = Evaluaters.EvaluateTaxAndCosts(finalItems);
                decimal totalTax = Evaluaters.CalculateSalesTax(finalItems);
                decimal totalCost = Evaluaters.CalculateTotalCost(finalItems);
                Formatters.PrintReciept(costEvaluatedItems, totalCost, totalTax);
            }
            catch(CostMissingException exception)
            {
                Console.WriteLine(exception.ToString());
            }
            catch(ShelfPriceNegetiveException exception)
            {
                Console.WriteLine(exception.ToString());
            }
            catch(ImportedMissingException exception)
            {
                Console.WriteLine(exception.ToString());
            }
        }
    }
}
