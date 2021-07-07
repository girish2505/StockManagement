using System;
using System.Collections.Generic;
using System.Text;

namespace StockManagement
{
    class StockManager : StockInterface
    {
        public void DisplayStocks(List<StocksUtility.Stock> stockList)
        {
            foreach (StocksUtility.Stock i in stockList)
            {
                Console.WriteLine($"Stock Value for {i.CompanyName}\nnumberOfShares={i.NumberOfShare}\nPrice={i.Price}\n");
            }
        }
        public void CalculateValueOfStock(List<StocksUtility.Stock> stockList)
        {
            foreach (StocksUtility.Stock i in stockList)
            {
                Console.WriteLine($"Stock Value for {i.CompanyName}\nnumberOfShares={i.NumberOfShare}\nPrice={i.Price}\n");
                Console.WriteLine($"Total value of {i.CompanyName} share is {i.NumberOfShare * i.Price}\n");
            }
        }
        public void CalculateValueOfAllStocks(List<StocksUtility.Stock> stockList)
        {
            int totalShare = 0;
            int valueOfCompany;
            foreach (StocksUtility.Stock i in stockList)
            {
                Console.WriteLine($"Stock Value for {i.CompanyName}\nnumberOfShares={i.NumberOfShare}\nPrice={i.Price}\n");
                valueOfCompany = i.NumberOfShare * i.Price;
                Console.WriteLine($"Total value of {i.CompanyName} share is {valueOfCompany}");
                totalShare+= valueOfCompany;

            }
            Console.WriteLine($"Total Value of all shares is {0}" + totalShare);
        }
    }
}
