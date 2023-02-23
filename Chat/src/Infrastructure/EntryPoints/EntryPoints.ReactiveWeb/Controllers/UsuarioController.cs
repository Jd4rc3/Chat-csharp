using Domain.Model.Entities;
using Domain.Model.Interfaces;
using Domain.UseCase;
using EntryPoints.ReactiveWeb.Base;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EntryPoints.ReactiveWeb.Controllers
{
    /// <summary>
    /// EntityController
    /// </summary>
    ///
    [ApiController]
    [Produces("application/json")]
    [ApiVersion("1.0")]
    [Route("api/[controller]")]
    public class UsuarioController : AppControllerBase<UsuarioController>
    {
        private readonly IUsuarioUseCase _useCase;

        public UsuarioController(IManageEventsUseCase eventsService, IUsuarioUseCase usecase) : base(eventsService)
        {
            _useCase = usecase;
        }

        [HttpPost]
        public async Task<IActionResult> SignUp([FromBody] Usuario usuario)
        => await HandleRequest(async () =>
        {
            return await _useCase.RegistrarUsuario(usuario);
        }, "Usuario autenticado");
    }
}