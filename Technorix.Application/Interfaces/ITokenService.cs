using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Technorix.Models.Models;

namespace Technorix.Application.Interfaces
{
    public interface ITokenService
    {
        TokenResponse GetTokenResponse(TokenRequest tokenRequest);
        bool ValidateTokenRequest(string Token);
    }
}
