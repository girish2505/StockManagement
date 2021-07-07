using System;
using System.Collections.Generic;
using System.Text;

namespace StockManagement
{
    interface StockInterface
    { 
     public void DisplayStocks(List<StocksUtility.Stock> stockList);
    public void CalculateValueOfStock(List<StocksUtility.Stock> stockList);
    public void CalculateValueOfAllStocks(List<StocksUtility.Stock> stockList);

    }
}
