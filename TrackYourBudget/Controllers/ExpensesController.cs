using Microsoft.AspNetCore.Mvc;
using TrackYourBudget.DataAccess;
using TrackYourBudget.Model.Expenses;

namespace TrackYourBudget.Controllers
{
    [Route("api/[controller]")]
    public class ExpensesController : Controller
    {
        private readonly ApplicationContext _applicationContext;

        public ExpensesController(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        [HttpPost]
        public void Add([FromBody] Expense expense)
        {
            _applicationContext.Expenses.Add(expense);
            _applicationContext.SaveChanges();
        }
    }
}