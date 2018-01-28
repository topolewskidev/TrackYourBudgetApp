using System.ComponentModel.DataAnnotations;
using TrackYourBudget.Model.Categories;

namespace TrackYourBudget.Model.Expenses
{
    public class Expense
    {
        [Key]
        public int Id { get; set; }
        public Category Category { get; set; }
    }
}
