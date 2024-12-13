using house.Interfaces;
using house.Services.Home;
using Infrastructure;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace house
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            // Add services to the container.
            builder.Services.AddControllersWithViews();

            //1.取得組態中資料庫連線設定
            string? connectionString = builder.Configuration.GetConnectionString("NorthwindContext");

            //2.註冊EF Core的DbContext
            builder.Services.AddDbContext<NorthwindContext>(options => options.UseSqlServer(connectionString));
            builder.Services.AddInfrastructureService(builder.Configuration);
            builder.Services.AddScoped(typeof(IProductServices), typeof(ProductServices));


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

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
