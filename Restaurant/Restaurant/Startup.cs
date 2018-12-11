using BusinessLogic;
using DAL;
using DAL.RepositoryPattern;
using DAL.RepositoryPattern.Context;
using DAL.RepositoryPattern.Entities;
using DAL.RepositoryPattern.IdentityEntities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Restaurant.Features.Alerts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Restaurant
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddTransient<IRestaurantRepository<Menu>, RestaurantRepository<Menu>>();
            services.AddTransient<IRestaurantRepository<Table>, RestaurantRepository<Table>>();
            services.AddTransient<IRestaurantRepository<Branch>, RestaurantRepository<Branch>>();
            services.AddTransient<IRestaurantRepository<User>, RestaurantRepository<User>>();
            services.AddTransient<IRestaurantRepository<Reserve>, RestaurantRepository<Reserve>>();
            services.AddTransient<IBusinessLogic, Logic>();

            services.AddDbContext<AppIdentityDbContext>(options =>
                        options.UseLazyLoadingProxies()
                        .UseSqlServer(Configuration["Data:RestaurantIdentityDb:ConnectionString"])
                        ,ServiceLifetime.Transient);

            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<AppIdentityDbContext>()
                .AddDefaultTokenProviders();

            services.AddHttpContextAccessor();
            services.AddScoped<AlertService>();

            services.AddAuthentication()
                .AddCookie(options =>
                {
                    options.LoginPath = "/Account/Login";
                    options.LogoutPath = "/Account/Logout";
                    options.ForwardAuthenticate = "/Home/Index";
                });

            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddSessionStateTempDataProvider();

            services.AddSession();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            app.UseDeveloperExceptionPage();
            app.UseDatabaseErrorPage();
            app.UseBrowserLink();
            app.UseStatusCodePages();

            app.UseAuthentication();

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseSession();

            app.UseMvc(route =>
            {
                route.MapRoute("default", "{Controller=Home}/{Action=Index}/{id?}");
            });

            //IdentitySeedData.EnsurePopulated(app);
            //OnStartupCall.DeleteReservations(app);
        }
    }
}
