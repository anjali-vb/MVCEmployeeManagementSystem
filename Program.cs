using EmployeeManagementSystem2025.Repositories;
using EmployeeManagementSystem2025.Service;
using EmployeeManagementSystem2025.Services;

namespace EmployeeManagementSystem2025
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            //register all custom services like connectionstring,repository,services
            //1 - add connection string
            var connectionString = builder.Configuration.GetConnectionString("MVCConnectionString");
            //2 - repository and service as middleware
            builder.Services.AddScoped<IEmployeeRepository, EmployeeRepositoryImpl>();
            builder.Services.AddScoped<IEmployeeService, EmployeeServiceImpl>();

            //3 - Register Authentication and Authorization --- cookie
            builder.Services.AddScoped<IUserRepository, UserRepositoryImpl>();
            builder.Services.AddScoped<IUserService, UserServiceImpl>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Logins}/{action=Login}/{id?}");

            app.Run();
        }
    }
}
