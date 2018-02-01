using System.Linq;
using TrackYourBudget.Business.Common;
using TrackYourBudget.DataAccess;
using TrackYourBudget.Model.Expenses;

namespace TrackYourBudget.Business.Expenses.Commands
{
    public class AddExpenseCommandHandler : ICommandHandler<AddExpenseCommand>
    {
        private readonly ApplicationContext _context;

        public AddExpenseCommandHandler(ApplicationContext context)
        {
            _context = context;
        }

        public void Handle(AddExpenseCommand command)
        {
            using (_context)
            {
                var categoryBudgetPlanId = _context.CategoryBudgetPlans
                    .Where(plan => 
                        plan.CategoryId == command.CategoryId &&
                        plan.BudgetPlan.StartDate <= command.Date &&
                        plan.BudgetPlan.EndDate >= command.Date)
                    .Select(plan => plan.Id)
                    .Single();

                _context.Add(new Expense
                {
                    Amount = command.Amount,
                    CategoryBudgetPlanId = categoryBudgetPlanId,
                    Date = command.Date
                });

                _context.SaveChanges();
            }
        }
    }
}
