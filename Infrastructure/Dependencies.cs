using ApplicationCore.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using house.Services.Home;


namespace Infrastructure
{
    public static class Dependencies
    {
        public static void AddInfrastructureService(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("NorthwindDb");
            services.AddDbContext<NorthwindContext>(options => options.UseSqlServer(connectionString));

            //看情況抽Configruation
            //services.AddScoped<ProductServices>();
        }
    }
}
