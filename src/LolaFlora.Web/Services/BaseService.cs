using LolaFlora.Data.Base;
using Microsoft.EntityFrameworkCore;

namespace LolaFlora.Web.Services
{
    public class BaseService<T> where T : BaseEntity, new()
    {
        protected readonly DbSet<T> ItemSet;

        public BaseService(LolaFloraDbContext dbContext)
        {
            ItemSet = dbContext.Set<T>();
        }
    }
}
