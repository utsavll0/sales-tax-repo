using SalesTaxProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SalesTaxProject.Business
{
    public class Evaluaters
    {
        public static decimal CalculateSalesTax(List<Item> listOfItems)
        {
            decimal totalSalesTax = listOfItems.Sum(x => x.Tax);
            return totalSalesTax;
        } 

        public static decimal CalculateTotalCost(List<Item> listOfItems)
        {
            decimal totalCost = listOfItems.Sum(x => x.Cost);
            return totalCost;
        }

        public static decimal CalculateTaxForItem(Item item)
        {
            decimal tax = 0.0m;
            if (item.isExempted == true && item.isImported == false)
            {
                tax = 0.00m;
            }
            else if (item.isExempted == true && item.isImported == true)
            {
                tax = item.ShelfPrice * 5.00m / 100.00m;
            }
            else if (item.isImported == false)
            {
                tax = item.ShelfPrice * 10.00m / 100.00m;
            }
            else
            {
                tax = (item.ShelfPrice * 15.00m / 100.00m);
            }
            return Formatters.RoundDecimal(tax);
        }

        public static decimal CalculateCostForItem(Item item)
        {
            return item.Tax + item.ShelfPrice;
        }

        public static string GetFormattedDescription(string description)
        {
            string formattedDescription = "";
            List<string> splitDescription = description.Split().ToList<string>();
            try
            {
                string importedString = splitDescription.Single(item => item.ToLower().Equals("imported"));
                splitDescription.Remove(importedString);
                formattedDescription = splitDescription[0] + " imported";
                for(int i = 1; i < splitDescription.Count; i++)
                {
                    formattedDescription = formattedDescription + $" {splitDescription[i]}";
                }
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine($"There was no imported in {description}.");
                formattedDescription = description;
            }
            return formattedDescription;
        }
    }
}
