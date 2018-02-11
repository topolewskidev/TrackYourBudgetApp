using System;
using System.Linq;
using TrackYourBudget.DataAccess;

namespace TrackYourBudget.Business.BudgetPlans.Queries
{
    public class GetCurrentBudgetPlansWithCategoriesQuery : IGetCurrentBudgetPlansWithCategoriesQuery
    {
        private readonly ApplicationContext _context;

        public GetCurrentBudgetPlansWithCategoriesQuery(ApplicationContext context)
        {
            _context = context;
        }

        public BudgetPlanWithCategoriesDto Get()
        {
            var currentDate = DateTime.Today;

            using (_context)
            {
                var budgetPlan = _context.BudgetPlans
                    .Where(p =>
                        p.StartDate <= currentDate &&
                        p.EndDate >= currentDate)
                    .Select(p => new BudgetPlanWithCategoriesDto
                    {
                        StartDate = p.StartDate,
                        EndDate = p.EndDate,
                        Categories = p.Categories
                            .Select(c => new CategoryBudgetPlanDto
                            {
                                CategoryName = c.Category.Name,
                                StartAmount = c.StartAmount,
                                SpentAmount = c.Expenses.Sum(expense => expense.Amount),
                            })
                            .ToList()
                    })
                    .Single();

                foreach (var category in budgetPlan.Categories)
                {
                    category.RemainingAmount = category.StartAmount - category.SpentAmount;
                    category.SpentAmountPercentage = (int) (category.SpentAmount / category.StartAmount * 100);
                }

                budgetPlan.DaysProgressPercentage = CalculateDaysProgressPercentage(budgetPlan);

                return budgetPlan;
            }
        }

        private int CalculateDaysProgressPercentage(BudgetPlanWithCategoriesDto budgetPlan)
        {
            var currentDate = DateTime.Today;
            var budgetPlanLength = (budgetPlan.EndDate - budgetPlan.StartDate).TotalDays;
            var daysProgress = (currentDate - budgetPlan.StartDate).TotalDays;

            return (int) (daysProgress / budgetPlanLength * 100);
        }
    }
}