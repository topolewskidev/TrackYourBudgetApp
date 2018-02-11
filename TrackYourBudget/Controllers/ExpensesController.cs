using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TrackYourBudget.Business.Common;
using TrackYourBudget.Business.Expenses.Commands;
using TrackYourBudget.Business.Expenses.Queries;

namespace TrackYourBudget.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class ExpensesController : Controller
    {
        private readonly ICommandHandler<AddExpenseCommand> _addExpenseCommandHandler;
        private readonly IGetLastExpensesQuery _getLastExpensesQuery;

        public ExpensesController(
            ICommandHandler<AddExpenseCommand> addExpenseCommandHandler,
            IGetLastExpensesQuery getLastExpensesQuery)
        {
            _addExpenseCommandHandler = addExpenseCommandHandler;
            _getLastExpensesQuery = getLastExpensesQuery;
        }

        [HttpPost]
        public void Add([FromBody] AddExpenseCommand command)
        {
            _addExpenseCommandHandler.Handle(command);
        }

        [HttpGet("last")]
        public IList<ExpenseDto> GetLastExpenses()
        {
            return _getLastExpensesQuery.Get();
        }
    }
}