using LolaFlora.Common.Interfaces;
using LolaFlora.Common.Models;
using LolaFlora.Data.Base;
using LolaFlora.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace LolaFlora.Web.Services
{
    public class CartService : BaseService<Cart>, ICartService
    {
        public CartService(LolaFloraDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<MyCart> GetAll(long customerId)
        {
            var products = await ItemSet.AsNoTracking().Where(p => p.UserId == customerId).Include(p=>p.Product).ToListAsync();
            var myCart = new MyCart()
            {
                Products = products.Select(p => p.Product).ToList(),
            };
            return myCart;
        }

        public async Task<bool> AddProduction(long? customerId, long productId)
        {
            var product = await DbContext.Set<Product>().FindAsync(productId);
            if (product != null && product.Quantity > 0)
            {
                ItemSet.Add(new Cart() { UserId = customerId, ProductId = productId });

                --product.Quantity;
                DbContext.Set<Product>().Update(product);

                return await DbContext.SaveChangesAsync() > 0;
            }
            return false;

        }

        public async Task<bool> RemoveProduction(long? customerId, long productId)
        {
            var productInCart = await ItemSet.FirstAsync(p=>p.UserId == customerId && p.ProductId == productId);
            ItemSet.Remove(productInCart);
            await DbContext.SaveChangesAsync();
            var product = await DbContext.Set<Product>().FindAsync(productId);
            ++product.Quantity;
            DbContext.Set<Product>().Update(product);
            return await DbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> RemoveAll(long customerId)
        {
            var myproductsIncart = await ItemSet.Where(p => p.UserId == customerId).ToListAsync();
            foreach (var item in myproductsIncart)
            {
                var product = await DbContext.Set<Product>().FindAsync(item.ProductId);
                ++product.Quantity;
                DbContext.Set<Product>().Update(product);
            }
            DbContext.RemoveRange(myproductsIncart);
            return await DbContext.SaveChangesAsync() > 0;
        }
    }
}
