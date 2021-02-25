using SalesTaxProject.Exceptions;
using SalesTaxProject.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SalesTaxProject.Model
{
    public class Item
    {
        public string Description { get; set; }
        public Decimal ShelfPrice { get; set; }
        public bool IsExempted { get; set; }
        public bool IsImported { get; set; }
        public Decimal Tax { get; set; }
        public Decimal Cost { get; set; }

        public Item(string description)
        {
            var descriptionCostArray = description.Split(" at ");
            try
            {
                decimal shelfPrice = Decimal.Parse(descriptionCostArray[1]);
                string itemDescription = descriptionCostArray[0];
                IsImported = Helper.IsImported(itemDescription);
                ShelfPrice = shelfPrice;
                IsExempted = Helper.IsExempted(itemDescription);
                Tax = 0.00m;
                Cost = 0.00m;
                Description = IsImported ? FormateDescription(itemDescription) : itemDescription;
            }
            catch (IndexOutOfRangeException)
            {
                throw new CostMissingException($"For {description}, cost was missing");
            }
        }

        private string FormateDescription(string description)
        {
            string formattedDescription = "";
            List<string> splitDescription = description.Split().ToList<string>();
            try
            {
                string importedString = splitDescription.Single(item => item.ToLower().Equals("imported"));
                splitDescription.Remove(importedString);
                formattedDescription = splitDescription[0] + " imported";
                for (int i = 1; i < splitDescription.Count; i++)
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
        public override bool Equals(object obj)
        {
            Item I = (Item)obj;
            return Description == I.Description && ShelfPrice == I.ShelfPrice && IsExempted == I.IsExempted && IsImported == I.IsImported && Tax == I.Tax && Cost == I.Cost;
        }

    }
}
