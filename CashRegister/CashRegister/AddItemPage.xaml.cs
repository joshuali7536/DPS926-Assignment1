using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CashRegister
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddItemPage : ContentPage
    {
        ObservableCollection<Item> items;
        public AddItemPage(ObservableCollection<Item> itemsList)
        {
            InitializeComponent();
            items = itemsList;
        }

        private void Save_Clicked(object sender, EventArgs e)
        {
            if (nameEntry.Text != null && priceEntry.Text != null && qtyEntry.Text != null)
            {
                if (nameEntry.Text != "" && priceEntry.Text != "" && qtyEntry.Text != "")
                {
                    if (nameEntry.Text.Trim() == "")
                    {
                        DisplayAlert("Error", "Please enter a name for the product.", "Ok");
                    }
                    else if (!int.TryParse(qtyEntry.Text, out int value))
                    {
                        DisplayAlert("Error", "Please enter quantity as an integer. (No decimals)", "Ok");
                    }
                    else if (int.Parse(qtyEntry.Text) < 0)
                    {
                        DisplayAlert("Error", "Please enter quantity as a positive value.", "Ok");
                    }
                    else if (!double.TryParse(priceEntry.Text, out double result))
                    {
                        DisplayAlert("Error", "Please enter price in proper formatting.", "Ok");
                    }
                    else if (double.Parse(priceEntry.Text) <= 0)
                    {
                        DisplayAlert("Error", "Please enter a positive non-zero value for price.", "Ok");
                    }
                    else
                    {
                        items.Add(new Item(nameEntry.Text, items.Count, double.Parse(priceEntry.Text), int.Parse(qtyEntry.Text)));
                        DisplayAlert("Product Added", nameEntry.Text + "(" + qtyEntry.Text + ") added. Price: $" + priceEntry.Text, "Ok");
                        Navigation.PopAsync();
                    }
                }
            }
            else
            {
                DisplayAlert("Error", "Please fill out all fields.", "Ok");
            }
        }

        private void Cancel_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}