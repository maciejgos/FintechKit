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

        private async void OnCardItemTapped(object sender, EventArgs args)
        {
            if (isDetailView == false)
            {
                ShowControls();
                await ShowContainersAnimation();

                isDetailView = true;
            }
        }

        private async void BackButtonClicked(object sender, EventArgs e)
        {
            if (isDetailView)
            {
                isDetailView = false;
                await HideContainersAnimation();

                HideControls();

            }
        }

        private void ShowControls()
        {
            backButton.IsVisible = true;
            menuContainer.IsVisible = true;
            cardDetailContainer.IsVisible = true;
        }

        private void HideControls()
        {
            backButton.IsVisible = false;
            menuContainer.IsVisible = false;
            cardDetailContainer.IsVisible = false;
        }

        private async Task ShowContainersAnimation()
        {
            await myCardsContainer.TranslateTo(0, -(currentBalanceContainer.Height + 20), animationLength);
            await cardDetailContainer.TranslateTo(0, -(currentBalanceContainer.Height + 20), animationLength);
            await menuContainer.TranslateTo(0, -80, animationLength);
            await transactionContainer.TranslateTo(0, 100, animationLength);
            await currentBalanceContainer.FadeTo(0, animationLength);

            await myCardsContainer.FadeTo(0);
            await cardDetailContainer.FadeTo(1);
        }

        private async Task HideContainersAnimation()
        {
            await myCardsContainer.TranslateTo(0, 0, animationLength);
            await cardDetailContainer.TranslateTo(0, 0, animationLength);
            await menuContainer.TranslateTo(0, 0, animationLength);
            await transactionContainer.TranslateTo(0, 0, animationLength);
            await currentBalanceContainer.FadeTo(1, animationLength);

            await myCardsContainer.FadeTo(1);
            await cardDetailContainer.FadeTo(0);
            await backButton.FadeTo(0);
        }
    }
}
