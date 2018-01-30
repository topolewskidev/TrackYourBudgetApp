using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TrackYourBudget.Model.Categories;

namespace TrackYourBudget.Model.Expenses
{
    public class Expense
    {
        [Key]
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
    }
}
