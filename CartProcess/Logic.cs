using CartData;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CartProcess
{
    public class Logics
    {
        public static bool itemValidator(string ItemInput)
        {
            var itemValidator = ItemInput.ToLower();
            CartData.ItemPrice enumValue;

            if (CartData.ItemPrice.TryParse(itemValidator, out enumValue))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool savingItem(string selectedItem, int quantity)
        {
            List<string> item = new List<string>();
            List<string> total = new List<string>();
            List<string> finalItem = new List<string>();

            var itemValidator = selectedItem.ToLower();
            CartData.ItemPrice enumValue;
            if (CartData.ItemPrice.TryParse(itemValidator, out enumValue))
            {
                int itemPrice = itemAmount(quantity, (int)enumValue);
                item.Add(selectedItem + "\t\t" + quantity + "\t\t" + itemPrice);
                finalItem.Add(selectedItem + "\t\t\t" + quantity + "\t\t\t" + itemPrice);

                DataLayer.order(item);

                total.Add(itemPrice.ToString());
                DataLayer.listingPrices(total);

                List<string> dataInput = item;
                DataLayer.updateItems(true, dataInput);
                return true;
            }
            else
            {
                return false;
            }

        }
        public static string ComputingItems()
        {
            int sum = File.ReadAllLines(DataLayer.orders).Sum(x => int.Parse(x));
            string total = sum.ToString();

            return total;
        }

        public static string numberOfItems()
        {
            var LineCount = File.ReadLines(DataLayer.fileName).Count();
            string Count = LineCount.ToString();

            return Count;
        }

        public static int itemAmount(int x, int y)
        {
            return x * y;
        }

        public static void AmountToPay()
        {
            List<string> CartAmount = new List<string>();

            CartAmount.Add("Total Order Amount: " + ComputingItems());

            DataLayer.order(CartAmount);

            List<string> dataInput = CartAmount;
            DataLayer.updateItems(true, dataInput);
        }
    }
}