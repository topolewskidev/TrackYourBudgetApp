using System;

namespace TrackYourBudget.Business.Expenses.Queries
{
    public class ExpenseDto
    {
        public string CategoryName { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
    }
}