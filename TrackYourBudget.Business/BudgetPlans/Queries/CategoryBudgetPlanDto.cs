﻿namespace TrackYourBudget.Business.BudgetPlans.Queries
{
    public class CategoryBudgetPlanDto
    {
        public string CategoryName { get; set; }
        public decimal StartAmount { get; set; }
        public decimal SpentAmount { get; set; }
    }
}