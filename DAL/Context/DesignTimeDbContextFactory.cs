using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using DAL.Context;

namespace CarFest.DAL.Context
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(@Directory.GetCurrentDirectory() + "/../CarFest.API/appsettings.json")
                .Build();
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
            var connectioString = configuration.GetConnectionString("DatabaseConnection");
            builder.UseSqlServer(connectioString);
            builder.EnableDetailedErrors();
            builder.EnableSensitiveDataLogging();
            return new ApplicationDbContext(builder.Options);
        }
    }
}
