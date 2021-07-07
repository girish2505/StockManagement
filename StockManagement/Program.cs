using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace StockManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            StockManager stockManager = new StockManager();
            Console.WriteLine("Welcome to Stock Management Program!");
            string jsonFilePath = @"C:\Users\giris\source\repos\StockManagement\StockManagement\Stocks.json";
            StocksUtility utility = JsonConvert.DeserializeObject<StocksUtility>(File.ReadAllText(jsonFilePath));


            Console.WriteLine("1.Open Stocks \n2.Calculate value of stock \n3.Calculate Total value of stocks\n4.Exit\n");
            switch (Convert.ToInt32(Console.ReadLine()))
            {
                case 1:
                    stockManager.DisplayStocks(utility.StockList);
                    break;
                case 2:
                    stockManager.CalculateValueOfStock(utility.StockList);
                    break;
                case 3:
                    stockManager.CalculateValueOfAllStocks(utility.StockList);
                    break;
                case 4:
                    Console.WriteLine("Exit");
                    break;
            }
        }
    }
}