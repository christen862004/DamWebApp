using DamWebApp.Repository;
using Microsoft.AspNetCore.Http;

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
            builder.Services.AddControllersWithViews();

            builder.Services.AddSession(option => {
                option.IdleTimeout = TimeSpan.FromMinutes(30);
            });
            //Custom Service need to define and register
            builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();//register
            builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();


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
            app.UseRouting();
            
            app.UseSession();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            #endregion

            app.Run();
        }
        //name
    }
}
