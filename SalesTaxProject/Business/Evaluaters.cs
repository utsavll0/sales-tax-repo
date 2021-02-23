using SalesTaxProject.Exceptions;
using SalesTaxProject.Model;
using SalesTaxProject.Utils;
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
            if(item.ShelfPrice < 0)
            {
                throw new ShelfPriceNegetiveException($"Shelf price for {item.Description} was negetive");
            }
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
                throw new ImportedMissingException($"There was no imported in \"{description}\"");
            }
            return formattedDescription;
        }

        public static List<Item> ProcessRawItems(List<string> rawItems)
        {
            List<Item> processedItems = new List<Item>(); 
            foreach(string rawItem in rawItems)
            {
                decimal shelfPrice = 0.00m;
                string itemDescription = "";
                var descriptionCostArray = rawItem.Split(" at ");
                try
                {
                    shelfPrice = Decimal.Parse(descriptionCostArray[1]);
                    itemDescription = descriptionCostArray[0];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new CostMissingException($"For {rawItem}, cost was missing");
                }
                processedItems.Add(new Item
                {
                    Description = itemDescription,
                    ShelfPrice = shelfPrice,
                    isExempted = Helper.IsExempted(itemDescription),
                    isImported = Helper.IsImported(itemDescription),
                    Tax = 0.00m,
                    Cost = 0.00m,
                });
            }
            return processedItems;
        }

        public static List<Item> EvaluateTaxAndCosts(List<Item> items)
        {
            try
            {
                foreach (Item item in items)
                {
                    item.Tax = Evaluaters.CalculateTaxForItem(item);
                    item.Cost = Evaluaters.CalculateCostForItem(item);
                }
                return items;
            }
            catch(ShelfPriceNegetiveException exception)
            {
                throw new CostMissingException(exception.Message);
            }
        }
    }
}
