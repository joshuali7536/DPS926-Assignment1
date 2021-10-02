using System;
using System.Collections.Generic;
using System.Text;

namespace CashRegister
{
    public class HistoryItem
    {
        public string name { get; set; }
        public int quantity { get; set; }
        public double price { get; set; }
        public DateTime purchaseDate { get; set; }

        public HistoryItem()
        {

        }

        public HistoryItem(string n, int qty, double p, DateTime date)
        {
            name = n;
            quantity = qty;
            price = p;
            purchaseDate = date;
        }
    }
}
