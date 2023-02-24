using Domain.Model.Entities;
using System;
using System.Threading.Tasks;

namespace Domain.UseCase
{
    public interface IUsuarioUseCase
    {
        Task<Token> RegistrarUsuario(Usuario nuevoUsuario);

        Task<Token> IniciarSesion(Usuario usuario);
    }
}