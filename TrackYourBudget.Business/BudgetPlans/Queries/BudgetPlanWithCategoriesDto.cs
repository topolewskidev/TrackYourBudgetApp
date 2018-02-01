using System;
using System.Collections.Generic;

namespace TrackYourBudget.Business.BudgetPlans.Queries
{
    public class BudgetPlanWithCategoriesDto
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public IList<CategoryBudgetPlanDto> Categories { get; set; }
    }
}