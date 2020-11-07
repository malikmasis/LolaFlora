using LolaFlora.Common.Models;
using LolaFlora.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LolaFlora.Common.Interfaces
{
    public interface IUserService
    {
        Task<AuthenticateResponse> Authenticate(AuthenticateRequest model);
        Task<List<User>> GetAll();
        Task<User> GetById(long id);
    }
}
