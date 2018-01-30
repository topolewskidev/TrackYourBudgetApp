using System;
using TrackYourBudget.Business.Common;

namespace TrackYourBudget.Business.Expenses.Commands
{
    public class AddExpenseCommand : ICommand
    {
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public int CategoryId { get; set; }
    }
}