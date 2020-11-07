using LolaFlora.Data.Base;
using Microsoft.EntityFrameworkCore;


namespace LolaFlora.Web.DBContext
{
    public class PgsqlDbContext : LolaFloraDbContext
    {
        public PgsqlDbContext(DbContextOptions<PgsqlDbContext> options) : base(options)
        {
        }
    }
}