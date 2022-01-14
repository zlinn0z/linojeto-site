using Linojeto.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linojeto.Services
{
    public class TokenService
    {
        public static string GenerateToken(Usuario usuario)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var chaveCriptografia = Encoding.ASCII.GetBytes(ChaveJWT.ChaveSecreta);
        }
    }
}
