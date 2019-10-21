using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace HakatonApi.Helpers
{
    public interface IUserGeter
    {
        int GetUser(string authHeader);
    }
    public class UserGeter : PageModel, IUserGeter
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserGeter(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public int GetUser(string authHeader)
        {
            var handler2 = new JwtSecurityTokenHandler();
            authHeader = authHeader.Replace("Bearer ", "");
            var jsonToken2 = handler2.ReadToken(authHeader);
            var tokenS = handler2.ReadToken(authHeader) as JwtSecurityToken;

            int userId = int.Parse(tokenS.Claims.First(claim => claim.Type == "nameid").Value);
            return userId; 
        }
    }
}
