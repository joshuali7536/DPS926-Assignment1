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
    public partial class ManagerPage : ContentPage
    {
        ObservableCollection<Item> mp_items;
        ObservableCollection<HistoryItem> mp_HistoryItems;
        public ManagerPage(ObservableCollection<Item> items, ObservableCollection<HistoryItem> HistoryItems)
        {
            InitializeComponent();
            mp_items = items;
            mp_HistoryItems = HistoryItems;
        }

        private void History_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new HistoryPage(mp_HistoryItems));
        }

        private void Restock_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RestockPage(mp_items));
        }

        private void Add_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddItemPage(mp_items));
        }
    }
}