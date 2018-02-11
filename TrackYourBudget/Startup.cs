using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.Webpack;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using TrackYourBudget.Business.BudgetPlans.Queries;
using TrackYourBudget.Business.Categories.Queries;
using TrackYourBudget.Business.Common;
using TrackYourBudget.Business.Expenses.Commands;
using TrackYourBudget.Business.Users.Helpers;
using TrackYourBudget.Business.Users.Queries;
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

            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<ApplicationSettingsProvider>(appSettingsSection);

            var appSettings = appSettingsSection.Get<ApplicationSettingsProvider>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            services.AddAuthentication(x =>
                {
                    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });

            services.AddTransient<IGetAllCategoriesQuery, GetAllCategoriesQuery>();
            services.AddTransient<ICommandHandler<AddExpenseCommand>, AddExpenseCommandHandler>();
            services.AddTransient<IGetCurrentBudgetPlansWithCategoriesQuery, GetCurrentBudgetPlansWithCategoriesQuery>();
            services.AddTransient<IIsUserLogInDataValidQuery, IsUserLogInDataValidQuery>();
            services.AddTransient<IGetUserIdByUserNameQuery, GetUserIdByUserNameQuery>();
            services.AddTransient<IUserTokenGenerator, UserTokenGenerator>();
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

            app.UseAuthentication();

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
