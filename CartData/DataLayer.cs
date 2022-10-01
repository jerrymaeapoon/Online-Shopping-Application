using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CartData
{
    public class DataLayer
    {
        public static string fileName = $"{DateTime.Today.Date.Day.ToString()} - orders.txt";
        public static string orders = $"{DateTime.Today.Date.Day.ToString()} - price.txt";
        public static string finalcheckout = $"{DateTime.Today.Date.Day.ToString()} - finalcheckout.txt";

        public static void updateItems(bool isNewItem, List<string> itemInput)
        {
            if (isNewItem)
            {
                using (StreamWriter file = File.AppendText(fileName))
                {
                    writeItemInFile(file, itemInput);
                }
            }
            else
            {
                using (StreamWriter file = File.CreateText(fileName))
                {
                    writeItemInFile(file, itemInput);
                }
            }

        }

        internal static void writeItemInFile(StreamWriter file, List<string> itemInput)
        {
            foreach (var data in itemInput)
            {
                file.WriteLine(data);
            }
        }

        public static List<string> showItems()
        {
            List<string> dataContent = new List<string>();

            using (StreamReader sr = new StreamReader(fileName))
            {
                string line = sr.ReadLine();

                while (line != null)
                {
                    dataContent.Add(line);
                    line = sr.ReadLine();
                }

            }
            return dataContent;
        }

        public static void listingPrices(List<string> totalItem)
        {
            using (StreamWriter file = File.AppendText(orders))
            {
                writeItemInFile(file, totalItem);
            }
        }

        public static void order(List<string> totalItem)
        {
            using (StreamWriter file = File.AppendText(finalcheckout))
            {
                writeItemInFile(file, totalItem);
            }
        }

        public static void clearPrice(bool clearItem, List<string> clearItems)
        {
            if (clearItem)
            {
                using (StreamWriter file = File.CreateText(orders))
                {
                    writeItemInFile(file, clearItems);
                }
            }
        }

        public static void forPrice(bool clearItem, List<string> iprice)
        {
            if (clearItem)
            {
                using (StreamWriter file = File.CreateText(orders))
                {
                    writeItemInFile(file, iprice);
                }
            }
            else
            {
                using (StreamWriter file = File.AppendText(orders))
                {
                    writeItemInFile(file, iprice);
                }
            }
        }

        public static void RemoveCarts()
        {
            List<string> dataClear = new List<string>();
            updateItems(false, dataClear);

            List<string> removingInput = new List<string>();
            clearPrice(true, removingInput);
        }

        public static void SavingFinalOrder()
        {
            List<string> RemovingInput = new List<string>();
            clearPrice(true, RemovingInput);

            List<string> DataClear = new List<string>();
            updateItems(false, DataClear);
        }


        public static bool DeleteDataInFile(string itemToDelete)
        {
            List<string> existingItems = showItems();
            List<string> tempItems = new List<string>();

            if (existingItems.Count > 0)
            {
                foreach (var item in existingItems)
                {
                    if (!item.Contains(itemToDelete))
                    {
                        tempItems.Add(item);
                    }
                }

                File.Delete(fileName);
                updateItems(true, tempItems);
                return true;
            }
            return false;
        }
    }
}

