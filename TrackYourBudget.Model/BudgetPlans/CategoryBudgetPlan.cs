using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TrackYourBudget.Model.Categories;
using TrackYourBudget.Model.Expenses;

namespace TrackYourBudget.Model.BudgetPlans
{
    public class CategoryBudgetPlan
    {
        [Key]
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int BudgetPlanId { get; set; }
        public BudgetPlan BudgetPlan { get; set; }
        public decimal StartAmount { get; set; }
        public ISet<Expense> Expenses { get; set; }
    }
}