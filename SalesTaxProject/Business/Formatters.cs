using SalesTaxProject.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SalesTaxProject.Business
{
    class Formatters
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
                Console.WriteLine($"{item.Description} : {item.Cost}");
            }
            Console.WriteLine($"Sales Taxes: {salesTax}");
            Console.WriteLine($"Total: {totalCost}");
        }
        public static decimal RoundDecimal(decimal number)
        {
            return Math.Round(number / 0.05m, 0) * 0.05m;
        }
    }
}
