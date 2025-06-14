using DamWebApp.Filtters;
using DamWebApp.Models;
using DamWebApp.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DamWebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            //Builder with default web appication setting

            // Add services to the container.Day8
            //Built in Service , already register
            //Built in service , need to register
            //builder.Services.AddControllersWithViews(
            //    options =>options.Filters.Add(new HandelErrorAttribute()));
            builder.Services.AddControllersWithViews();
            builder.Services.AddSession(option => {
                option.IdleTimeout = TimeSpan.FromMinutes(30);
            });
            //Register DbContextOption ,ITIContext
            builder.Services.AddDbContext<ITIContext>(optionBuilder => {
                optionBuilder.UseSqlServer(builder.Configuration.GetConnectionString("cs"));
            });
            builder.Services.AddIdentity<AppLicationUser, IdentityRole>(
                options =>
                {
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireDigit = false;
                    options.Password.RequiredLength = 4;
                })
                .AddEntityFrameworkStores<ITIContext>();



















            //Custom Service need to define and register
            builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();//register
            builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            builder.Services.AddScoped<ITestService, TestService>();//most common 


            var app = builder.Build();
            #region PipeLine using Cusotm Middlware
            //Component
            //inline Midddlware =>
            //app.Use(async (httpContext, next) =>
            //{
            //    //httpContext.Request.route = "GET";
            //    await httpContext.Response.WriteAsync("1) Middleware 1 \n");
            //    await next.Invoke();//call next middlware
            //    await httpContext.Response.WriteAsync("1-1) Middleware 1-1 \n");

            //});

            //app.Use(async(httpcontext, next) =>
            //{
            //    await httpcontext.Response.WriteAsync("2) Middleware 2 \n");
            //    await next.Invoke();
            //    await httpcontext.Response.WriteAsync("2-2) Middleware 2-2 \n");

            //});

            //app.Run(async (httpcontext) => {
            //    await httpcontext.Response.WriteAsync("3) Terminate \n");
            //});
            #endregion


            #region Configure the HTTP request pipeline.  using built in Middleware Day6
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();//cant read from wwwroot
            //Routing
            app.UseRouting(); //Security "Mapping"
            
            app.UseSession();

            app.UseAuthorization();
            #region Custom Route
            //NAming Converntion Route
            //app.MapControllerRoute("route1", "r1/{age:int:range(20,60)}/{name?}",
            //    new {controller="Route",action="Method1" });
            //r1/11/hamed  req.routeValue {cnotoller=roue,action="Method1" ,age=11.name=hamed}

            //app.MapControllerRoute("route1", "r1",
            //    new { controller = "Route", action = "Method1" });

            //app.MapControllerRoute("route2", "r2",
            //    new { controller="Route",action="Method2"});

            #endregion

            //Route for each controller

            //app.MapControllerRoute("Route1", "{controller=Employee}/{action=Index}/{id?}");


            //Default URl
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");// decalre Route Template ,execute
            #endregion

            app.Run();
        }
        //name
    }
}
