using Microsoft.EntityFrameworkCore;
using TrackYourBudget.Model.BudgetPlans;
using TrackYourBudget.Model.Categories;
using TrackYourBudget.Model.Expenses;
using TrackYourBudget.Model.Users;

namespace TrackYourBudget.DataAccess
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<BudgetPlan> BudgetPlans { get; set; }
        public DbSet<CategoryBudgetPlan> CategoryBudgetPlans { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
