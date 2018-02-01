using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TrackYourBudget.Business.BudgetPlans.Queries;
using TrackYourBudget.Business.Categories.Queries;
using TrackYourBudget.Business.Common;
using TrackYourBudget.Business.Expenses.Commands;
using TrackYourBudget.DataAccess;

namespace TrackYourBudget
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            var connectionString = Configuration.GetConnectionString("ApplicationConnection");
            services.AddDbContext<ApplicationContext>(builder => builder.UseSqlServer(connectionString));

            services.BuildServiceProvider().GetService<ApplicationContext>().Database.Migrate();

            services.AddTransient<IGetAllCategoriesQuery, GetAllCategoriesQuery>();
            services.AddTransient<ICommandHandler<AddExpenseCommand>, AddExpenseCommandHandler>();
            services.AddTransient<IGetCurrentBudgetPlansWithCategoriesQuery, GetCurrentBudgetPlansWithCategoriesQuery>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebpackDevMiddleware(new WebpackDevMiddlewareOptions
                {
                    HotModuleReplacement = true
                });
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");

                routes.MapSpaFallbackRoute(
                    name: "spa-fallback",
                    defaults: new { controller = "Home", action = "Index" });
            });
        }
    }
}
