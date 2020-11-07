using LolaFlora.Data.Base;
using LolaFlora.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace LolaFlora.Web.DBContext
{
    public class PgsqlDbContext : LolaFloraDbContext
    {
        public PgsqlDbContext(DbContextOptions<PgsqlDbContext> options) : base(options)
        {
        }

        public static void EnsureCreated(IServiceProvider provider)
        {
            var context = provider.GetService<PgsqlDbContext>();
            context.Database.Migrate();
            try
            {
                context.Database.OpenConnection();

                User test = Test;
                context.Users.Add(test);
                context.SaveChanges();
            }
            finally
            {
                context.Database.CloseConnection();
            }
        }
    }
}