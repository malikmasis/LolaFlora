using LolaFlora.Common.Models;
using LolaFlora.Data.Entities;
using System.Collections.Generic;

namespace LolaFlora.Common.Interfaces
{
    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        IEnumerable<User> GetAll();
        User GetById(long id);
    }
}
