using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace FintechKit.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        private uint animationLength = 600;
        private bool isDetailView;

        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnCardItemTapped(object sender, EventArgs args)
        {
            if (isDetailView == false)
            {
                backButton.IsVisible = true;
                menuContainer.IsVisible = true;
                cardDetailContainer.IsVisible = true;
                var r = myCardsContainer.TranslateTo(0, -(currentBalanceContainer.Height + 20), animationLength);
                var t = cardDetailContainer.TranslateTo(0, -(currentBalanceContainer.Height + 20), animationLength);
                var s = menuContainer.TranslateTo(0, -80, animationLength);
                var e = transactionContainer.TranslateTo(0, 100, animationLength);
                await currentBalanceContainer.FadeTo(0, animationLength);

                await myCardsContainer.FadeTo(0);
                await cardDetailContainer.FadeTo(1);


                isDetailView = true;
            }
            else
            {
                transactionContainer.TranslateTo(0, 0, animationLength);
                menuContainer.TranslateTo(0, 0, animationLength);
                await currentBalanceContainer.FadeTo(1, 10);
                myCardsContainer.TranslateTo(0, 0, animationLength);

                isDetailView = false;
            }
        }
    }
}
