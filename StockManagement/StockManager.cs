using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace StockManagement
{
    class StockManager : StockInterface
    {

        private static LinkedList<string> transactionsDone = new LinkedList<string>();
        private static LinkedList<string> transactionsDateTime = new LinkedList<string>();
        public void DisplayStocks(List<StocksUtility.Stocks> stockList)
        {

            foreach (StocksUtility.Stocks i in stockList)
            {
                Console.WriteLine($"Name ={i.name}\nVolume={i.numberOfShare}\nPrice={i.price}\n");
            }
        }
        public void DisplayStocks(LinkedList<StocksUtility.UserStocks> stockList)
        {
            foreach (StocksUtility.UserStocks i in stockList)
            {
                Console.WriteLine($"Shareholder name = {i.shareholder}\nName ={i.name}\nVolume={i.numberOfShare}\nPrice={i.price}\n");
            }
        }
        public void CalculateValueOfEachStock(List<StocksUtility.Stocks> stockList)
        {
            foreach (StocksUtility.Stocks i in stockList)
            {
                Console.WriteLine($"Name ={i.name}\nVolume={i.numberOfShare}\nPrice={i.price}\n");
                Console.WriteLine($"Total value of {i.name} share is {i.numberOfShare * i.price}\n");

            }
        }
        public void CalculateValueOfAllStocks(List<StocksUtility.Stocks> stockList)
        {
            int totalShareOfCompanies = 0;
            int valueOfEachCompany;
            foreach (StocksUtility.Stocks i in stockList)
            {
                Console.WriteLine($"Name ={i.name}\nVolume={i.numberOfShare}\nPrice={i.price}\n");
                valueOfEachCompany = i.numberOfShare * i.price;
                Console.WriteLine($"Total value of {i.name} share is {valueOfEachCompany}");
                totalShareOfCompanies += valueOfEachCompany;

            }
            Console.WriteLine($"Total Value of all shares is {totalShareOfCompanies}");
        }
        public void CalculateValueOfEachStock(List<StocksUtility.UserStocks> stockList)
        {
            foreach (StocksUtility.UserStocks i in stockList)
            {
                Console.WriteLine($"Shareholder name = {i.shareholder}\nName ={i.name}\nVolume={i.numberOfShare}\nPrice={i.price}\n");
                Console.WriteLine($"Total value of {i.name} share is {i.numberOfShare * i.price}\n");

            }
        }
        public void CalculateValueOfAllStocks(List<StocksUtility.UserStocks> stockList)
        {
            int totalShareOfCompanies = 0;
            int valueOfEachCompany;
            foreach (StocksUtility.UserStocks i in stockList)
            {
                Console.WriteLine($"Shareholder name = {i.shareholder}\nName ={i.name}\nVolume={i.numberOfShare}\nPrice={i.price}\n");
                valueOfEachCompany = i.numberOfShare * i.price;
                Console.WriteLine($"Total value of {i.name} share is {valueOfEachCompany}");
                totalShareOfCompanies += valueOfEachCompany;

            }
            Console.WriteLine($"Total Value of all shares is {totalShareOfCompanies}");
        }
       
        public void BuyStocks(string jsonFilePathOfStocks)
        {
            DateTime aDate = DateTime.Now;
            string transactions = string.Empty;
            StocksUtility utilityOfStockList = JsonConvert.DeserializeObject<StocksUtility>(File.ReadAllText(jsonFilePathOfStocks));

            DisplayStocks(utilityOfStockList.stockList);
            Console.WriteLine("Enter your name:");
            string nameOfPerson = Console.ReadLine();
            Console.WriteLine("Enter the name of the stock you want to buy:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter how many volumes you want to buy:");
            int volume = Convert.ToInt32(Console.ReadLine());
            bool check = CheckAvailablity(name, volume, utilityOfStockList.stockList);
            if (check)
            {

                StocksUtility.Stocks result = utilityOfStockList.stockList.Find(item => item.name.Equals(name));
                result.numberOfShare -= volume;
                Console.WriteLine(result.numberOfShare);
                StocksUtility.UserStocks user = new StocksUtility.UserStocks();
                user.name = name;
                user.numberOfShare = volume;
                user.price = result.price;
                user.shareholder = nameOfPerson;
                if (CheckExists(utilityOfStockList.userStockList, user.name, user.shareholder))
                {
                    foreach (StocksUtility.UserStocks i in utilityOfStockList.userStockList)
                    {
                        if (i.name.Equals(name) && i.numberOfShare >= volume && i.shareholder.Equals(nameOfPerson))
                        {
                            i.numberOfShare += user.numberOfShare;
                        }
                    }

                }
                else
                {
                    utilityOfStockList.userStockList.AddLast(user);
                    
                }

                File.WriteAllText(jsonFilePathOfStocks, JsonConvert.SerializeObject(utilityOfStockList));
                transactions = $"{nameOfPerson} ---> Transaction Done on Buying {user.name} of volume = {user.numberOfShare} , worth = {user.numberOfShare * user.price} ";
                transactionsDone.AddLast(transactions);
                transactionsDateTime.AddLast(transactions + "at " + aDate.ToString("dddd, dd MMMM yyyy HH:mm:ss"));
                Console.WriteLine($"{nameOfPerson} Succesfully purchased {user.name} of volume = {user.numberOfShare} , worth = {user.numberOfShare * user.price} ");
            }
            else
            {
                Console.WriteLine(" Stock Not available");
            }


        }
        //sell stocks
        public void SellStocks(string jsonFilePathOfStocks)
        {
            DateTime aDate = DateTime.Now;
            string transactions = string.Empty;
            StocksUtility utilityOfStockList = JsonConvert.DeserializeObject<StocksUtility>(File.ReadAllText(jsonFilePathOfStocks));

            //Display stocks
            Console.WriteLine("Enter your name:");
            string nameOfPerson = Console.ReadLine();
            foreach (StocksUtility.UserStocks i in utilityOfStockList.userStockList)
            {
                if (i.shareholder.Equals(nameOfPerson))
                {
                    Console.WriteLine($"Shareholder name = {i.shareholder}\nName ={i.name}\nVolume={i.numberOfShare}\nPrice={i.price}\n***********");
                }
            }
            Console.WriteLine("Enter the name of the stock:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter how many no.of shares:");
            int volume = Convert.ToInt32(Console.ReadLine());
            bool check = CheckAvailablity(name, volume, utilityOfStockList.userStockList, nameOfPerson);
            if (check)
            {
                StocksUtility.Stocks user = new StocksUtility.Stocks();
                foreach (StocksUtility.UserStocks i in utilityOfStockList.userStockList)
                {
                    if (i.name.Equals(name) && i.numberOfShare >= volume && i.shareholder.Equals(nameOfPerson))
                    {
                        i.numberOfShare -= volume;
                        user.price = i.price;
                    }
                }
                user.name = name;
                user.numberOfShare = volume;

                if (CheckExists(utilityOfStockList.stockList, user.name))
                {
                    StocksUtility.Stocks res = utilityOfStockList.stockList.Find(item => item.name.Equals(user.name));
                    res.numberOfShare += user.numberOfShare;
                }
                else
                {
                    utilityOfStockList.stockList.Add(user);
                }

                File.WriteAllText(jsonFilePathOfStocks, JsonConvert.SerializeObject(utilityOfStockList));
                transactions = $"{nameOfPerson} --->Transaction Done on Selling {user.name} of volume = {user.numberOfShare} , worth = {user.numberOfShare * user.price} ";
                Console.WriteLine($"{nameOfPerson} Succesfully sold {user.name} of volume = {user.numberOfShare} , worth = {user.numberOfShare * user.price} ");
                transactionsDateTime.AddLast(transactions + "at " + aDate.ToString("dddd, dd MMMM yyyy HH:mm:ss"));
                transactionsDone.AddLast(transactions);


            }
            else
            {
                Console.WriteLine("Stocks Not available for selling");
            }
        }
        //checking for transaction done or not
        public void PrintReport()
        {

            if (transactionsDone.Count > 0)
            {
                Console.WriteLine("Transaction");
                foreach (string i in transactionsDateTime)
                {
                    Console.WriteLine(i);
                }
            }
            else
            {
                Console.WriteLine("No Transaction");
            }
        }

       //checking Availability
        public bool CheckAvailablity(string nameOfStock, int volumeOfStock, List<StocksUtility.Stocks> stockList)
        {
            StocksUtility.Stocks result = stockList.Find(item => item.name.Equals(nameOfStock));
            if (result.name.Equals(nameOfStock) && result.numberOfShare >= volumeOfStock)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool CheckAvailablity(string nameOfStock, int volumeOfStock, LinkedList<StocksUtility.UserStocks> stockList, string nameOfPerson)
        {
            foreach (StocksUtility.UserStocks i in stockList)
            {
                if (i.name.Equals(nameOfStock) && i.numberOfShare >= volumeOfStock && i.shareholder.Equals(nameOfPerson))
                {
                    return true;
                }
            }
            return false;
        }
       //method for verify whether stock is exist or not
        public bool CheckExists(LinkedList<StocksUtility.UserStocks> stockList, string name, string nameOfPerson)
        {
            foreach (StocksUtility.UserStocks i in stockList)
            {
                if (i.name.Equals(name) && i.shareholder.Equals(nameOfPerson))
                {
                    return true;
                }
            }
            return false;
        }
       
        public bool CheckExists(List<StocksUtility.Stocks> stockList, string name)
        {
            foreach (StocksUtility.Stocks i in stockList)
            {
                if (i.name.Equals(name))
                {
                    return true;
                }
            }
            return false;
        }
    }
}