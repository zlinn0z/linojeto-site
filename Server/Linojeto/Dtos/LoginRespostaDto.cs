using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Linojeto.Dtos
{
    public class LoginRespostaDto
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string Token { get; set; }
    }
}
