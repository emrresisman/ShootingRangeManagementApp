using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ShootingRangeManagementApp.EFCore.Context;
using ShootingRangeManagementApp.Core.Stores;
using ShootingRangeManagementApp.Core.Interfaces;
using ShootingRangeManagementApp.Core.UnitOfWork;
using ShootingRangeManagementApp.Models.Entities;
using ShootingRangeManagementApp.Core.DailyGiro;
using ShootingRangeManagementApp.Core.StocksRepository;
using ShootingRangeManagementApp.Core.BillsRepository;
using ShootingRangeManagementApp.Core.StorePartners;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNet.Identity;
using Owin;
using AutoMapper;
using ShootingRangeManagementApp.Core.Mapping;
using ShootingRangeManagementApp.Core.UsersRepository;

namespace ShootingRangeManagementApp
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddDbContext<StoreContext>(opt =>
            {
                opt.UseSqlServer("server=.; database=StoreDb; integrated security=true");
            });
            
            services.AddControllersWithViews();
            services.AddScoped<IStoreRepository, StoreRepository>();
            services.AddScoped<IStockRepository, StockRepository>();
            services.AddScoped<IDailyGiroRepository, DailyGiroRepository>();
            services.AddScoped<IBillRepository, BillRepository>();
            services.AddScoped<IStorePartnerRepository, StorePartnerRepository>();
            services.AddScoped<IUserRepository, UserRepository >() ;
            services.AddScoped<UnitOfWork>();
            services.AddIdentity<AppUser, AppRole>(opt=> {
                opt.Password.RequireDigit = false;
                opt.Password.RequireUppercase = false;
                opt.Password.RequireNonAlphanumeric = false;
                opt.Lockout.MaxFailedAccessAttempts = 10;
            }).AddEntityFrameworkStores<StoreContext>();
            
            services.ConfigureApplicationCookie(opt =>
            {
                opt.Cookie.HttpOnly = true;
                opt.Cookie.SameSite = SameSiteMode.Strict;
                opt.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
                opt.Cookie.Name = "Cookie";
                opt.ExpireTimeSpan = TimeSpan.FromDays(25);
                opt.LoginPath = new PathString("/User/SignIn");
            });

            var configuration = new MapperConfiguration(opt =>
              {
                  opt.AddProfile(new DailyStoreGiroProfile());
              });
            var mapper = configuration.CreateMapper();
            services.AddSingleton(mapper);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, StoreContext dbContext)
        {
            try
            {
                dbContext.Database.Migrate();
            }
            catch
            {

            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "node_modules")),
                RequestPath="/node_modules"
            });
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{Controller}/{Action}/{id?}",
                    defaults:new {Controller="Home",Action="Index"}
                    );
            });

 
            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/", async context =>
            //    {
            //        await context.Response.WriteAsync("Hello World!");
            //    });
            //});
        }
       
    }
}
