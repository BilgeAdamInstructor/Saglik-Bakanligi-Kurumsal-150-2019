using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace WebApii
{
    public class TokenAuthenticationService : Repository<TokenRequest>, IAuthenticationService
    {
        private readonly IUserManagementService _userManagementService;
        private readonly IOptions<TokenManagement> _tokenManagement;
        private DataContext dataContext;
        public TokenAuthenticationService(DataContext dataContext) : base(dataContext)
        {
            this.dataContext = dataContext; 
        }
       
        public bool IsAuthenticated(TokenRequest tokenRequest, out string token)
        {
            token = null;

            if(!_userManagementService.IsValidUser(tokenRequest.Username,tokenRequest.Password))
            {
                return false;
            }

            var claims = new[]
            {
                new Claim(ClaimTypes.Name,tokenRequest.Username)
            };
            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_tokenManagement.Value.Secret));
            SigningCredentials credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
             
            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(_tokenManagement.Value.Issuer,
                _tokenManagement.Value.Audience, 
                claims,  
                expires: DateTime.Now.AddMinutes(_tokenManagement.Value.AccessExpiration), 
                signingCredentials:credentials);
            token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            return true;    
        }
    }
}
