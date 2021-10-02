using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Text;

namespace CashRegister
{
    public class Item : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private int _quantity;

        public string name { get; set; }
        public int id { get; set; }
        public double price { get; set; }
        public int quantity { 
            get { return _quantity;  }
            set
            {
                if (value == _quantity)
                    return;
                _quantity = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs(nameof(quantity)));
            }
        }


        public Item()
        {

        }

        public Item(string itemName, int itemId, double itemPrice, int itemQty)
        {
            name = itemName;
            id = itemId;
            price = itemPrice;
            quantity = itemQty;
        }

        
    }
}
