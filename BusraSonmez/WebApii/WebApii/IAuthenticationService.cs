using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApii 
{
    public interface IAuthenticationService:IRepository<TokenRequest>
    {
        bool IsAuthenticated(TokenRequest tokenRequest, out string token); 
    }
}
