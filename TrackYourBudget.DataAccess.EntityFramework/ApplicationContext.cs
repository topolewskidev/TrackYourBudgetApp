using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using TrackYourBudget.Model.Categories;
using TrackYourBudget.Model.Expenses;

namespace TrackYourBudget.DataAccess
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Expense> Expenses { get; set; }
    }
}
