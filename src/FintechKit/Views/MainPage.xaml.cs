using System;
using System.ComponentModel;
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

        protected override void OnAppearing()
        {
            base.OnAppearing();

            backButton.Clicked += BackButton_Clicked;
        }

        private async void BackButton_Clicked(object sender, EventArgs e)
        {
            Console.WriteLine("Back button clicked...");

            if (isDetailView)
            {
                isDetailView = false;
                await HideContainersAnimation();

                HideControls();
            }
        }

        private async void OnCardItemTapped(object sender, EventArgs args)
        {
            if (isDetailView == false)
            {
                ShowControls();
                await ShowContainersAnimation();

                isDetailView = true;
            }
        }

        private void ShowControls()
        {
            //backButton.IsVisible = true;
            //menuContainer.IsVisible = true;
            //cardDetailContainer.IsVisible = true;
        }

        private void HideControls()
        {
            //backButton.IsVisible = false;
            //menuContainer.IsVisible = false;
            //cardDetailContainer.IsVisible = false;
        }

        private async Task ShowContainersAnimation()
        {
            await currentBalanceContainer.FadeTo(0, 250, Easing.SinOut);
            await backButton.FadeTo(1, 250, Easing.SinIn);

            await myCardsContainer.FadeTo(0);
            myCardsContainer.IsVisible = false;

            await cardDetailContainer.FadeTo(1, 250, Easing.CubicInOut);
            await cardDetailContainer.TranslateTo(0, -(currentBalanceContainer.Height + 20), animationLength, Easing.SinIn);
            await menuContainer.TranslateTo(0, -80, animationLength, Easing.SinIn);

            await transactionContainer.TranslateTo(0, 100, 250, Easing.SinOut);

            transactionsHeaderLabel.Text = "Transactions";
            await viewAllButton.FadeTo(0);
        }

        private async Task HideContainersAnimation()
        {
            await myCardsContainer.TranslateTo(0, 0, animationLength);

            await menuContainer.TranslateTo(0, 0, animationLength);
            await cardDetailContainer.TranslateTo(0, 0, animationLength);
            await backButton.FadeTo(0);

            await transactionContainer.TranslateTo(0, 0, animationLength);
            await currentBalanceContainer.FadeTo(1, animationLength);

            myCardsContainer.IsVisible = true;

            await myCardsContainer.FadeTo(1);
            await cardDetailContainer.FadeTo(0);

            transactionsHeaderLabel.Text = "Today";
            await viewAllButton.FadeTo(1);
        }
    }
}
