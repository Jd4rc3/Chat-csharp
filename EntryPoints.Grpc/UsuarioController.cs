using AutoMapper;
using Domain.Model.Entities;
using Domain.UseCase;
using Domain.UseCase.Common;
using EntryPoints.Grpc.Dtos.Protos;
using static EntryPoints.Grpc.Extensions.GrpcServiceHandler;
using Grpc.Core;

namespace EntryPoints.Grpc
{
    public class UsuarioController : UsuarioService.UsuarioServiceBase
    {
        private readonly IManageEventsUseCase _eventsUseCase;
        private readonly IUsuarioUseCase _usuarioUseCase;
        private readonly IMapper _mapper;

        public UsuarioController(IManageEventsUseCase eventsUseCase, IUsuarioUseCase usuarioUseCase, IMapper mapper)
        {
            _eventsUseCase = eventsUseCase;
            _usuarioUseCase = usuarioUseCase;
            _mapper = mapper;
        }

        public override async Task<Response> SignUp(SignUpRequest request, ServerCallContext context)
        {
            return await HandleRequest<SignUpRequest>(async () =>
            {
                var token = await _usuarioUseCase.RegistrarUsuario(_mapper.Map<Usuario>(request));

                return new Response() { Token = token.AccesToken, Error = false, Message = "Acceso autorizado" };
            }, _eventsUseCase);
        }

        public override async Task<Response> SignIn(SignInRequest request, ServerCallContext context)
        {
            return await HandleRequest<SignInRequest>(async () =>
            {
                var token = await _usuarioUseCase.IniciarSesion(_mapper.Map<Usuario>(request));

                return new Response() { Token = token.AccesToken, Error = false, Message = "Acceso autorizado" };
            }, _eventsUseCase);
        }
    }
}