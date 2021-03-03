using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pedidos.Repository
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            var fileName = Directory.GetCurrentDirectory() + $"/../Pedidos.Api/appsettings.{environmentName}.json";
            
            var configuration = new ConfigurationBuilder().AddJsonFile(fileName).Build();
            var connectionString = configuration.GetConnectionString("Pedidos");

            var configuration1 = new ConfigurationBuilder().AddJsonFile(fileName).Build();
            var connectionString1 = configuration1.GetConnectionString("Pedidos1");

            var builder = new DbContextOptionsBuilder<AppDbContext>();
            builder.UseNpgsql(connectionString);

            var builder1 = new DbContextOptionsBuilder<AppDbContext>();
            builder1.UseSqlServer(connectionString1);

            return new AppDbContext(builder1.Options);
        }
    }
}
