using System.Threading.Tasks;
using Domain.Model.Entities;

namespace Domain.UseCase
{
    public interface IUsuarioUseCase
    {
        Task<Usuario> RegistrarUsuario(Usuario nuevoUsuario);
    }
}