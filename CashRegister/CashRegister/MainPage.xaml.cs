using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CashRegister
{
    public partial class MainPage : ContentPage
    {
        string qtyText = "";
        double price = 0;
        double total = 0;
        int quantity = 0;
        int id = -1;

        ObservableCollection<Item> items = new ObservableCollection<Item>
            {
                new Item("Hat", 0, 6.99, 21),
                new Item("Shirt", 1, 14.99, 14),
                new Item("Pants", 2, 17.99, 8),
                new Item("Necklace", 3, 25.99, 12),
                new Item("Gloves", 4, 10.99, 31)
            };

        ObservableCollection<HistoryItem> HistoryItems = new ObservableCollection<HistoryItem>();
        public MainPage()
        {
            InitializeComponent();

            

            myList.ItemsSource = items;
        }

        private void myList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (((ListView)sender).SelectedItem == null)
                return;

            typeLabel.Text = (e.SelectedItem as Item).name.ToString();
            price = (e.SelectedItem as Item).price;
            quantity = (e.SelectedItem as Item).quantity;
            id = (e.SelectedItem as Item).id;

            if (qtyText != "")
            {
                total = price * Int32.Parse(qtyText);
                totalLabel.Text = total.ToString();
            }
        }

        private void numButton_Clicked(object sender, EventArgs e)
        {
            string number = ((Button)sender).BindingContext as string;

            if (qtyLabel.Text == "Quantity")
            {
                qtyLabel.Text = "";
            }

            qtyText = qtyLabel.Text + number;
            qtyLabel.Text = qtyText;

            if (price != 0)
            {
                total = price * Int32.Parse(qtyText);
                totalLabel.Text = total.ToString();
            }
            else
                totalLabel.Text = "Total";
        }

        private void clearTotal(object sender, EventArgs e)
        {
            qtyText = "";
            qtyLabel.Text = "Quantity";
            totalLabel.Text = "Total";
        }

        private void backspace_Clicked(object sender, EventArgs e)
        {
            if (qtyText != "")
            {
                qtyText = qtyText.Remove(qtyText.Length - 1, 1);
                qtyLabel.Text = qtyText;
                if (qtyText == "")
                {
                    qtyLabel.Text = "Quantity";
                    totalLabel.Text = "Total";
                }
                else
                {
                    if (price != 0)
                    {
                        total = price * Int32.Parse(qtyText);
                        totalLabel.Text = total.ToString();
                    }
                }
            }
        }

        private void purchaseClicked(object sender, EventArgs e)
        {
            if (qtyText != "" && typeLabel.Text != "Type")
            {
                if (quantity < Int32.Parse(qtyText))
                {
                    DisplayAlert("Quantity Error", "Not enough items in stock.", "Ok");
                }
                else if (Int32.Parse(qtyText) == 0)
                {
                    DisplayAlert("Quantity Error", "Enter a non-zero amount.", "Ok");
                }
                else
                {
                    if (id != -1)
                    {
                        quantity = quantity - Int32.Parse(qtyText);
                        items[id].quantity = quantity;

                        HistoryItems.Add(new HistoryItem(items[id].name, Int32.Parse(qtyText), (Int32.Parse(qtyText) * items[id].price), DateTime.Now));

                        DisplayAlert("Purchase Made", "Purchased " + Int32.Parse(qtyText) + " " + items[id].name + ".", "Ok");

                        qtyText = "";
                        qtyLabel.Text = "Quantity";
                        totalLabel.Text = "Total";
                        typeLabel.Text = "Type";
                        price = 0;
                        myList.SelectedItem = null;
                    }
                }
            }
            else
                DisplayAlert("Error", "Please select an item and enter a quantity.", "Ok");
        }

        private void managerMenu_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ManagerPage(items, HistoryItems));
        }
        
    }
}
