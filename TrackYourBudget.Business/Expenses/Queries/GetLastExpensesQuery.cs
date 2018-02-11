using System;
using System.Collections.Generic;
using System.Linq;
using TrackYourBudget.DataAccess;

namespace TrackYourBudget.Business.Expenses.Queries
{
    public class GetLastExpensesQuery : IGetLastExpensesQuery
    {
        private readonly ApplicationContext _context;

        public GetLastExpensesQuery(ApplicationContext context)
        {
            _context = context;
        }

        public IList<ExpenseDto> Get()
        {
            using (_context)
            {
                return _context.Expenses
                    .OrderByDescending(e => e.Date)
                    .Take(20)
                    .Select(e => new ExpenseDto
                    {
                        CategoryName = e.CategoryBudgetPlan.Category.Name,
                        Date = e.Date,
                        Amount = e.Amount
                    })
                    .ToList();
            }
        }
    }
}