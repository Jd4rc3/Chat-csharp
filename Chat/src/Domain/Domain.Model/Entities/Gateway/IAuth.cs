using System;
using System.Security.AccessControl;
using System.Threading.Tasks;

namespace Domain.Model.Entities.Gateway
{
    public interface IAuth
    {
        Task<Usuario> Registrar(Usuario usuario);

        Task<Usuario> IniciarSesion(Usuario usuario);
    }
}