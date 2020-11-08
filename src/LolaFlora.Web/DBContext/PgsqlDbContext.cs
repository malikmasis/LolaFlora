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

                if (context.Users.Find(new object[1] { Test.Id }) == null)
                {
                    User test = Test;
                    context.Users.Add(test);
                    context.SaveChanges();
                }

                if (context.Categories.Find(new object[1] { Tech.Id }) == null)
                {
                    context.Categories.Add(Tech);
                    context.SaveChanges();
                }

                if (context.Products.Find(new object[1] { AsusLaptop.Id }) == null)
                {
                    context.Products.Add(AsusLaptop);
                    context.SaveChanges();
                }
            }
            finally
            {
                context.Database.CloseConnection();
            }
        }
    }
}