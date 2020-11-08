using LolaFlora.Common.Models;
using System.Threading.Tasks;

namespace LolaFlora.Common.Interfaces
{
    public interface ICartService
    {
        Task<MyCart> GetAll(long customerId);
        Task<bool> AddProduction(long? customerId, long productId);
        Task<bool> RemoveProduction(long? customerId, long productId);
        Task<bool> RemoveAll(long customerId);

    }
}
