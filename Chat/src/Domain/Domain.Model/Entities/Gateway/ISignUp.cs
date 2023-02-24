using System;
using System.Security.AccessControl;
using System.Threading.Tasks;

namespace Domain.Model.Entities.Gateway
{
    public interface ISignUp
    {
        Task<Usuario> Registrar(Usuario usuario);
    }
}