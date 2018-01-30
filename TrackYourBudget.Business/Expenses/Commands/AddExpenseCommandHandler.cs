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
                _context.Add(new Expense
                {
                    Amount = command.Amount,
                    CategoryId = command.CategoryId,
                    Date = command.Date
                });

                _context.SaveChanges();
            }
        }
    }
}
