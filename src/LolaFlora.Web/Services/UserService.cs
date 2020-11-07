using LolaFlora.Common.Interfaces;
using LolaFlora.Common.Models;
using LolaFlora.Data.Base;
using LolaFlora.Data.Entities;
using LolaFlora.Web.AppSettings;
using LolaFlora.Web.Exceptions;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;

namespace LolaFlora.Web.Services
{
    public class UserService : IUserService
    {
        private readonly LolaFloraDbContext _dbContext;

        private readonly JwtOption _jwtOption;

        public UserService(LolaFloraDbContext dbContext, IOptions<JwtOption> jwtOptionSetting)
        {
            _dbContext = dbContext;
            _jwtOption = jwtOptionSetting.Value;
        }

        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            var user = _dbContext.Set<User>().SingleOrDefault(x => x.Username == model.Username && x.Password == model.Password);

            if (user == null)
            {
                throw new AuthException("Username or password is valid");
            }

            var token = generateJwtToken();

            return new AuthenticateResponse(user, token);
        }

        public IEnumerable<User> GetAll()
        {
            return _dbContext.Set<User>();
        }

        public User GetById(long id)
        {
            //preffered the explicit - for more - go to Readme.md
            object[] obj = new object[1] {id};
            return _dbContext.Set<User>().Find(obj);
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
