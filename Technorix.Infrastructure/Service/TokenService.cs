using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Technorix.Application.Interfaces;
using Technorix.Models.Models;

namespace Technorix.Infrastructure.Service
{
    public class TokenService : ITokenService
    {
        private IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        public TokenResponse GetTokenResponse(TokenRequest tokenRequest)
        {
            throw new NotImplementedException();
        }

        public bool ValidateTokenRequest(string Token)
        {
            throw new NotImplementedException();
        }
    }
}
