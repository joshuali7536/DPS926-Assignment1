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
    public partial class RestockPage : ContentPage
    {
        ObservableCollection<Item> items;

        int id = -1;


        public RestockPage(ObservableCollection<Item> itemsList)
        {
            InitializeComponent();
            items = itemsList;

            myList.ItemsSource = items;
        }
        private void myList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (((ListView)sender).SelectedItem == null)
                return;

            id = (e.SelectedItem as Item).id;
        }
        private void Restock_Clicked(object sender, EventArgs e)
        {
            if (id != -1 && newQtyEntry.Text != "" && newQtyEntry.Text != null)
                if (!int.TryParse(newQtyEntry.Text, out int value))
                {
                    DisplayAlert("Error", "Please enter an integer. (No decimals)", "Ok");
                }
                else
                { 
                    items[id].quantity = items[id].quantity + Int32.Parse(newQtyEntry.Text);
                    DisplayAlert("Item restocked", "You have restocked " + Int32.Parse(newQtyEntry.Text) + " " + items[id].name + ".", "Ok");
                    newQtyEntry.Text = null;
                    myList.SelectedItem = null;
                }
            else
                DisplayAlert("Error", "Select an item and enter a quantity to add.", "Ok");
        }

        private void Cancel_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}