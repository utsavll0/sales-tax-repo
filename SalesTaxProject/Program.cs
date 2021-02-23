using SalesTaxProject.Business;
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
            List<Item> finalItems = new List<Item>();
            foreach(string rawItem in rawListOfitems)
            {
                var descriptionCostArray = rawItem.Split(" at ");
                var shelfPrice = Decimal.Parse(descriptionCostArray[1]);
                var itemDescription = descriptionCostArray[0];
                finalItems.Add(new Item
                {
                    Description = itemDescription,
                    ShelfPrice = shelfPrice,
                    isExempted = Helper.IsExempted(itemDescription),
                    isImported = Helper.IsImported(itemDescription),
                    Tax = 0.00m,
                    Cost = 0.00m,
                });
            }
            foreach(Item item in finalItems)
            {
                item.Tax = Evaluaters.CalculateTaxForItem(item);
                item.Cost = Evaluaters.CalculateCostForItem(item);
            }
            decimal totalTax = Evaluaters.CalculateSalesTax(finalItems);
            decimal totalCost = Evaluaters.CalculateTotalCost(finalItems);
            Formatters.PrintReciept(finalItems, totalCost, totalTax);
        }
    }
}
