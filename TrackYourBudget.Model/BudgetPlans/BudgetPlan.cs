using System;
using System.ComponentModel.DataAnnotations;

namespace TrackYourBudget.Model.BudgetPlans
{
    public class BudgetPlan
    {
        [Key]
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
