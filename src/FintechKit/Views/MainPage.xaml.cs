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

        private void BackButton_Clicked(object sender, EventArgs e)
        {
            Console.WriteLine("Back button clicked...");

            if (isDetailView)
            {
                isDetailView = false;
                HideContainersAnimation();
            }
        }

        private void OnCardItemTapped(object sender, EventArgs args)
        {
            if (isDetailView == false)
            {
                ShowDetails();

                isDetailView = true;
            }
        }

        private void OnTransactionDetail_Tapped(object sender, EventArgs args)
        {
            Device.InvokeOnMainThreadAsync(async () =>
            {
                await currentBalanceContainer.FadeTo(0);
                currentBalanceContainer.IsVisible = false;

                backButton.IsVisible = true;
                await backButton.FadeTo(1);

                transactionDetailView.IsVisible = true;
                await transactionDetailView.FadeTo(1);
            });
        }

        private void ShowDetails()
        {
            Device.InvokeOnMainThreadAsync(async () =>
            {
                await Task.WhenAll(
                    currentBalanceContainer.FadeTo(0, animationLength),
                    myCardsContainer.TranslateTo(0, -80, animationLength),
                    cardDetailContainer.TranslateTo(0, -80, animationLength),
                    myCardsContainer.FadeTo(0, animationLength),
                    backButton.FadeTo(1, animationLength),
                    cardDetailContainer.FadeTo(1, animationLength),
                    menuContainer.FadeTo(1, animationLength),
                    menuContainer.TranslateTo(0, -100, animationLength),
                    transactionContainer.TranslateTo(0, 100, animationLength));

                // TODO: How to handle size of container???
                myCardsContainer.IsVisible = false;
            });
        }

        private void HideContainersAnimation()
        {
            Device.InvokeOnMainThreadAsync(async () =>
            {
                // TODO: How to handle size of container???
                myCardsContainer.IsVisible = true;

                await Task.WhenAll(
                    currentBalanceContainer.FadeTo(1, animationLength),
                    myCardsContainer.TranslateTo(0, 0, animationLength),
                    myCardsContainer.FadeTo(1, animationLength),
                    backButton.FadeTo(0, animationLength),
                    cardDetailContainer.FadeTo(0, animationLength),
                    menuContainer.FadeTo(0, animationLength),
                    menuContainer.TranslateTo(0, -200, animationLength),
                    transactionContainer.TranslateTo(0, 0, animationLength));
            });
        }
    }
}
