using LolaFlora.Data.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LolaFlora.Web.DBContext
{
    public static class Extensions
    {
        public static IServiceCollection AddPgsqlDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddDbContext<PgsqlDbContext>(options =>
                {
                    options.UseNpgsql(configuration["ConnectionStrings"], o =>
                    {
                        o.MigrationsHistoryTable("EFMigrationsHistory", "Public");
                    });
                })
                .AddScoped<LolaFloraDbContext, PgsqlDbContext>();

            return services;
        }
    }
}
