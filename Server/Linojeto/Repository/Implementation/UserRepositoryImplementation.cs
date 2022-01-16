using Linojeto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Linojeto.Repository.Implementation
{
    public class UserRepositoryImplementation : IUserRepository
    {
        private readonly LinojetoContext _contexto;

        public UserRepositoryImplementation(LinojetoContext contexto)
        {
            _contexto = contexto;
        }

        public bool HasUserByEmail(string email)
        {
            return _contexto.Usuario.Any(usuario => usuario.Email.ToLower() == email.ToLower());
        }

        public Usuario GetUserByLoginPassword(string login, string senha)
        {
            return _contexto.Usuario.FirstOrDefault(usuario => usuario.Email == login.ToLower() && usuario.Senha == senha);
        }

        public void Save(Usuario usuario)
        {
            _contexto.Usuario.Add(usuario);
            _contexto.SaveChanges();
        }
    }
}
