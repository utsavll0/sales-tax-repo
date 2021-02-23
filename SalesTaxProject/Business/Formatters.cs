using SalesTaxProject.Exceptions;
using SalesTaxProject.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SalesTaxProject.Business
{
    public class Formatters
    {
        public static List<string> ReadInput(int noOfItems)
        {
            List<string> items = new List<string>();
            for(int i = 0; i < noOfItems; i++)
            {
                items.Add(Console.ReadLine());
            }
            return items;
        }
        public static void PrintReciept(List<Item> listOfItems, decimal totalCost, decimal salesTax)
        {
            foreach(Item item in listOfItems)
            {
                string description = "";
                try
                {
                    description = item.isImported ? Evaluaters.GetFormattedDescription(item.Description) : item.Description;
                }
                catch(ImportedMissingException exception)
                {
                    throw new ImportedMissingException(exception.ToString());
                }
                Console.WriteLine($"{description} : {item.Cost}");
            }
            Console.WriteLine($"Sales Taxes: {salesTax}");
            Console.WriteLine($"Total: {totalCost}");
        }
        public static decimal RoundDecimal(decimal number)
        {
            return Math.Round(number / 0.05m, MidpointRounding.AwayFromZero) * 0.05m;
        }
    }
}
