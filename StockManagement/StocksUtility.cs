using System;
using System.Collections.Generic;
using System.Text;

namespace StockManagement
{
    class StocksUtility
    {
        public List<Stock> StockList { get; set; }

        public class Stock
        {
            public String CompanyName { get; set; }
            public int NumberOfShare { get; set; }
            public int Price { get; set; }
        }
    }
}
