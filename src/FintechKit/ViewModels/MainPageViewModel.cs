using System;
using System.Collections.Generic;
using System.Linq;
using FintechKit.Models;
using MvvmHelpers;

namespace FintechKit.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        private double currentBalance;
        private IList<CardModel> cards;
        private IList<TransactionModel> transactions;
        private IList<MenuModel> menu;

        public double CurrentBalance { get => currentBalance; set => SetProperty(ref currentBalance, value); }

        public IList<CardModel> Cards { get => cards; set => SetProperty(ref cards, value); }

        public IList<TransactionModel> Transactions { get => transactions; set => SetProperty(ref transactions, value); }

        public IList<MenuModel> Menu { get => menu; set => SetProperty(ref menu,value); }

        public MainPageViewModel()
        {
            Cards = new List<CardModel>
            {
                new CardModel
                {
                    Icon = "",
                    Title = "Mastercard Debit",
                    Number = "5104938325466428",
                    Balance = 74059.25
                },
                new CardModel
                {
                    Icon = "",
                    Title = "Visa",
                    Number = "4916172089076204",
                    Balance = 89059.25
                },
            };

            CurrentBalance = Cards.Sum(c => c.Balance);

            Transactions = new List<TransactionModel>
            {
                new TransactionModel
                {
                    Icon = "",
                    Title = "Steak House",
                    Date = DateTime.Today,
                    Amount = -78.25
                },
                new TransactionModel
                {
                    Icon = "",
                    Title = "NY Tennis Club",
                    Date = DateTime.Today.AddDays(-1),
                    Amount = -100.54
                },
                new TransactionModel
                {
                    Icon = "",
                    Title = "Burger House",
                    Date = DateTime.Today,
                    Amount = -50.25
                }
            };

            Menu = new List<MenuModel>
            {
                new MenuModel
                {
                    Title = "Transfer"
                },
                new MenuModel
                {
                    Title = "Card details"
                },
                new MenuModel
                {
                    Title = "Set limits"
                },
                new MenuModel
                {
                    Title = "Change PIN"
                },
                new MenuModel
                {
                    Title = "Block"
                }
            };
        }
    }
}
