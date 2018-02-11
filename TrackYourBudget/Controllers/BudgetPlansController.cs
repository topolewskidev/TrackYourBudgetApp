using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TrackYourBudget.Business.BudgetPlans.Queries;

namespace TrackYourBudget.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class BudgetPlansController : Controller
    {
        private readonly IGetCurrentBudgetPlansWithCategoriesQuery _getCurrentBudgetPlansWithCategoriesQuery;

        public BudgetPlansController(IGetCurrentBudgetPlansWithCategoriesQuery getCurrentBudgetPlansWithCategoriesQuery)
        {
            _getCurrentBudgetPlansWithCategoriesQuery = getCurrentBudgetPlansWithCategoriesQuery;
        }

        [HttpGet("current")]
        public BudgetPlanWithCategoriesDto GetCurrentBudgetPlan()
        {
            var currentBudgetPlan = _getCurrentBudgetPlansWithCategoriesQuery.Get();
            return currentBudgetPlan;
        }
    }
}