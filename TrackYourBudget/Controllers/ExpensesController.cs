using Microsoft.AspNetCore.Mvc;
using TrackYourBudget.Business.Common;
using TrackYourBudget.Business.Expenses.Commands;

namespace TrackYourBudget.Controllers
{
    [Route("api/[controller]")]
    public class ExpensesController : Controller
    {
        private readonly ICommandHandler<AddExpenseCommand> _addExpenseCommandHandler;

        public ExpensesController(ICommandHandler<AddExpenseCommand> addExpenseCommandHandler)
        {
            _addExpenseCommandHandler = addExpenseCommandHandler;
        }

        [HttpPost]
        public void Add([FromBody] AddExpenseCommand command)
        {
            _addExpenseCommandHandler.Handle(command);
        }
    }
}