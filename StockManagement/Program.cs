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

            string jsonFilePathOfStocks = @"C:\Users\giris\source\repos\StockManagement\StockManagement\Stocks.json";


           
            while (true)
            {
                StocksUtility utilityOfStockList = JsonConvert.DeserializeObject<StocksUtility>(File.ReadAllText(jsonFilePathOfStocks));
                Console.WriteLine("Please Select the Options shown Below\n");

                Console.WriteLine("1.Open Stocks \n2.Calculate value stock \n3.Calculate Total value of stocks\n4.Buy Stocks\n5.Sell Stocks\n6.Print Report\n7.Exit");
                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case 1:
                        stockManager.DisplayStocks(utilityOfStockList.stockList);
                        stockManager.DisplayStocks(utilityOfStockList.userStockList);
                        break;
                    case 2:
                        stockManager.CalculateValueOfEachStock(utilityOfStockList.stockList);
                        break;
                    case 3:
                        stockManager.CalculateValueOfAllStocks(utilityOfStockList.stockList);
                        break;
                    case 4:
                        stockManager.BuyStocks(jsonFilePathOfStocks);
                        break;
                    case 5:
                        stockManager.SellStocks(jsonFilePathOfStocks);
                        break;
                    case 6:
                        stockManager.PrintReport();
                        break;
                    case 7:
                        Console.WriteLine("Exit");
                        return;

                }
            }
        }
    }
}