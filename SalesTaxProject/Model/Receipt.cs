using SalesTaxProject.Business;
using SalesTaxProject.Exceptions;
using SalesTaxProject.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SalesTaxProject.Model
{
    public class Receipt
    {
        public List<Item> items;
        decimal totalCost;
        decimal salesTax;
        private readonly IEvaluator evaluater;

        public Receipt()
        {
            items = new List<Item>();
            totalCost = 0.00m;
            salesTax = 0.00m;
            evaluater = new Evaluater();
        }
        public void AddItem(string description)
        {
            try
            {
                Item item = new Item(description);
                items.Add(item);
            }
            catch (CostMissingException)
            {
                throw new CostMissingException($"For \"{description}\", cost was missing");
            }
        }
        public void CreateReceipt()
        {
            try
            {
                CalculateTaxForAllItems();
                CalculateCostForAllItems();
                CalculateSalesTax();
                CalculateTotalCost();
            }
            catch (ShelfPriceNegetiveException exception)
            {
                throw new ShelfPriceNegetiveException(exception.Message);
            }
        }
        
        public string GenerateReceipt()
        {
            string receipt = "";
            foreach(Item item in items)
            {
                receipt = receipt + ($"{item.Description}: {item.Cost}\n");
            }
            receipt = receipt + $"Sales Taxes: {salesTax}\n";
            receipt = receipt + $"Total: {totalCost}";
            return receipt;
        }
        private void CalculateTaxForAllItems()
        {
            foreach(Item item in items)
            {
                try
                {
                    decimal shelfPrice = item.ShelfPrice;
                    bool isImported = item.IsImported;
                    bool isExempted = item.IsExempted; 
                    decimal tax = evaluater.CalculateTaxForItem(shelfPrice,isImported,isExempted);
                    item.Tax = tax;
                }
                catch (ShelfPriceNegetiveException)
                {
                    throw new ShelfPriceNegetiveException($"Shelf price for {item.Description} was negetive");
                }
            }
        }
        private void CalculateCostForAllItems()
        {
            foreach(Item item in items)
            {
                decimal shelfPrice = item.ShelfPrice;
                decimal tax = item.Tax;
                decimal cost = evaluater.CalculateCost(shelfPrice, tax);
                item.Cost = cost;
            }
        }
        private void CalculateSalesTax()
        {
            List<decimal> listOfTax = new List<decimal>();
            foreach (Item item in items)
            {
                listOfTax.Add(item.Tax);
            }
            salesTax = evaluater.CalculateSum(listOfTax);
        }
        private void CalculateTotalCost()
        {
            List<decimal> listOfCost = new List<decimal>();
            foreach (Item item in items)
            {
                listOfCost.Add(item.Cost);
            }
            totalCost = evaluater.CalculateSum(listOfCost);
        }
    }
}
