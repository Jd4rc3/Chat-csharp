using Domain.Model.Entities;
using Domain.UseCase;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EntryPoints.ReactiveWeb.Controllers
{
    [Controller]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioUseCase _useCase;

        public UsuarioController(IUsuarioUseCase useCase)
        {
            _useCase = useCase;
        }

        [HttpPost]
        public async Task<IActionResult> SignUp([FromBody] Usuario usuario)
        {
            return Ok(await _useCase.RegistrarUsuario(usuario));
        }
    }
}