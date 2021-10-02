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
    public partial class HistoryPage : ContentPage
    {
        ObservableCollection<HistoryItem> histItems;
        public HistoryPage(ObservableCollection<HistoryItem> HistoryItems)
        {
            InitializeComponent();
            histItems = HistoryItems;

            myList.ItemsSource = histItems;
        }

        private void myList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Navigation.PushAsync(new HistoryDetailsPage(e.SelectedItem as HistoryItem));
        }
    }
}