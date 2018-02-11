using System.Collections.Generic;

namespace TrackYourBudget.Business.Expenses.Queries
{
    public interface IGetLastExpensesQuery
    {
        IList<ExpenseDto> Get();
    }
}
