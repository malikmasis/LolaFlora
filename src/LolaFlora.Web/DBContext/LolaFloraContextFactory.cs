
using LolaFlora.Data.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace LolaFlora.Web.DBContext
{
    public class LolaFloraContextFactory : IDesignTimeDbContextFactory<LolaFloraDbContext>
    {
        public LolaFloraDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var connectionString = configuration.GetValue<string>("ConnectionStrings");

            var optionsBuilder = new DbContextOptionsBuilder<PgsqlDbContext>();
            optionsBuilder.UseNpgsql(connectionString);
            return new PgsqlDbContext(optionsBuilder.Options);
        }
    }
}
