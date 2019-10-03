using CbMobile.Database;
using CbMobile.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using CbMobile.Application.Helpers;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using CbMobile.Domain.Models;

namespace CbMobile.Application.Service
{
    public class AccountAppService : IAccountAppService
    {
        private ApplicationDbContext _dbContext;
        private readonly AppSettings _appSettings;
        public AccountAppService(
            ApplicationDbContext dbContext,
            IOptions<AppSettings> appSettings)
        {
            _dbContext = dbContext;
            _appSettings = appSettings.Value;
        }
        public string Authenicate(string userName, string passWord)
        {
            var user = _dbContext
                        .Accounts
                        .SingleOrDefault(x => x.Username == userName && x.Password == passWord);
            if (user == null)
            {
                return null;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Username.ToString()),
                    new Claim(ClaimTypes.Role, user.Role)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);
            //user.Password = null;

            return user.Token;
        }

        public ClaimsPrincipal GetPrincipal(string token)
        {
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            JwtSecurityToken jwtToken = (JwtSecurityToken)tokenHandler.ReadToken(token);
            if (jwtToken == null)
                return null;
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            TokenValidationParameters parameters = new TokenValidationParameters()
            {
                RequireExpirationTime = true,
                ValidateIssuer = false,
                ValidateAudience = false,
                IssuerSigningKey = new SymmetricSecurityKey(key)
            };
            SecurityToken securityToken;
            ClaimsPrincipal principal = tokenHandler.ValidateToken(token,
                  parameters, out securityToken);
            return principal;
        }
        public object GetAccountByToken(string token)
        {
            string username = null;
            string roles = null;
            ClaimsPrincipal principal = GetPrincipal(token);
            if (principal == null)
                return null;
            ClaimsIdentity identity = null;
            try
            {
                identity = (ClaimsIdentity)principal.Identity;
            }
            catch (NullReferenceException)
            {
                return null;
            }
            Claim usernameClaim = identity.FindFirst(ClaimTypes.Name);
            Claim roleClaim = identity.FindFirst(ClaimTypes.Role);
            username = usernameClaim.Value;
            roles = roleClaim.Value;
            List<string> ls = new List<string>();
            ls.Add(username);
            return new
            {
                roles = ls,
                name = roles,
                introduction = "I am a super administrator",
                avatar = "https://wpimg.wallstcn.com/f778738c-e4f8-4870-b634-56703b4acafe.gif",
            };
        }
        public object Logout()
        {
            return new
            {
                data = "success"
            };
        }
    }
}
