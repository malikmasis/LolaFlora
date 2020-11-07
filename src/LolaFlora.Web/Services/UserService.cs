using LolaFlora.Common.Interfaces;
using LolaFlora.Common.Models;
using LolaFlora.Data.Base;
using LolaFlora.Data.Entities;
using LolaFlora.Web.AppSettings;
using LolaFlora.Web.Exceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Threading.Tasks;

namespace LolaFlora.Web.Services
{
    public class UserService : BaseService<User>, IUserService
    {
        private readonly JwtOption _jwtOption;

        public UserService(LolaFloraDbContext dbContext, IOptions<JwtOption> jwtOptionSetting) : base(dbContext)
        {
            _jwtOption = jwtOptionSetting.Value;
        }

        public async Task<AuthenticateResponse> Authenticate(AuthenticateRequest model)
        {
            var user = await ItemSet.SingleOrDefaultAsync(x => x.Username == model.Username && x.Password == model.Password);

            if (user == null)
            {
                throw new AuthException("Username or password is valid");
            }

            var token = generateJwtToken();

            return new AuthenticateResponse(user, token);
        }

        public async Task<List<User>> GetAll()
        {
            var result = await ItemSet.AsNoTracking().ToListAsync();
            result.ForEach(p => p.Password = null);
            return result;
        }

        public async Task<User> GetById(long id)
        {
            //preffered the explicit - for more - go to Readme.md
            object[] obj = new object[1] { id };
            return await ItemSet.FindAsync(obj);
        }

        private string generateJwtToken()
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOption.Key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_jwtOption.Issuer, _jwtOption.Issuer, null,
                                             expires: DateTime.Now.AddMinutes(120), signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
