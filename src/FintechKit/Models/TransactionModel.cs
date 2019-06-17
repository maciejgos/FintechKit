using System;

namespace FintechKit.Models
{
    public class TransactionModel
    {
        public string Icon { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public double Amount { get; set; }
    }
}
