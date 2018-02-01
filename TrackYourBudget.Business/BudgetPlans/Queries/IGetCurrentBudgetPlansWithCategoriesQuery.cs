namespace TrackYourBudget.Business.BudgetPlans.Queries
{
    public interface IGetCurrentBudgetPlansWithCategoriesQuery
    {
        BudgetPlanWithCategoriesDto Get();
    }
}
