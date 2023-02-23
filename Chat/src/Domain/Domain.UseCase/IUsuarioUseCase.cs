using Domain.Model.Entities;
using System;
using System.Threading.Tasks;

namespace Domain.UseCase
{
    public interface IUsuarioUseCase
    {
        Task<Object> RegistrarUsuario(Usuario nuevoUsuario);
    }
}