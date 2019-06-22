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
                menuContainer.IsVisible = true;
                await currentBalanceContainer.FadeTo(0, 10);
                await myCardsContainer.TranslateTo(0, -(currentBalanceContainer.Height + 40), animationLength);
                await menuContainer.TranslateTo(0, -100, animationLength, Easing.SinIn);
                await transactionContainer.TranslateTo(0, 100, animationLength);

                isDetailView = true;
            }
            else
            {
                await transactionContainer.TranslateTo(0, 0, animationLength);
                await menuContainer.TranslateTo(0, 0, 10);
                await currentBalanceContainer.FadeTo(1, 10);
                await myCardsContainer.TranslateTo(0, 0, animationLength);

                isDetailView = false;
            }
        }
    }
}
