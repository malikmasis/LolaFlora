using LolaFlora.Data.Base;
using Microsoft.EntityFrameworkCore;

namespace LolaFlora.Web.Services
{
    public class BaseService<T> where T : BaseEntity, new()
    {
        protected readonly DbSet<T> ItemSet;
        protected readonly LolaFloraDbContext DbContext;

        public BaseService(LolaFloraDbContext dbContext)
        {
            DbContext = dbContext;
            ItemSet = dbContext.Set<T>();
        }
    }
}
