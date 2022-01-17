using Linojeto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Linojeto.Repository
{
    public interface IUserRepository 
    {
        public void Save(Usuario usuario);
        bool HasUserByEmail(string email);
        Usuario GetUserByLoginPassword(string login, string senha);
    }
}
