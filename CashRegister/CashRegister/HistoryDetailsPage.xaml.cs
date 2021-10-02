using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CashRegister
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HistoryDetailsPage : ContentPage
    {
        HistoryItem historyItem;
        public HistoryDetailsPage(HistoryItem item)
        {
            InitializeComponent();
            historyItem = item;

            nameLabel.Text = historyItem.name;
            qtyLabel.Text = historyItem.quantity.ToString();
            dateLabel.Text = historyItem.purchaseDate.ToString();
            totalLabel.Text = historyItem.price.ToString();
        }
    }
}