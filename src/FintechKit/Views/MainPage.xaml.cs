using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FintechKit.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnCardItemTapped(object sender, EventArgs args)
        {
            menuContainer.IsVisible = true;

            await myCardsContainer.TranslateTo(0, 0);
            await menuContainer.TranslateTo(menuContainer.X, myCardsContainer.Height);
            await transactionContainer.TranslateTo(transactionContainer.X, menuContainer.Y);
        }
    }
}
