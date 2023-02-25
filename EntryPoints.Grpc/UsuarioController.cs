using AutoMapper;
using Domain.Model.Entities;
using Domain.UseCase;
using Domain.UseCase.Common;
using EntryPoints.Grpc.Dtos.Protos;
using FluentValidation;
using FluentValidation.Results;
using Grpc.Core;
using static EntryPoints.Grpc.Extensions.GrpcServiceHandler;

namespace EntryPoints.Grpc
{
    public class UsuarioController : UsuarioService.UsuarioServiceBase
    {
        private readonly IValidator<SignUpRequest> _validator;
        private readonly IManageEventsUseCase _eventsUseCase;
        private readonly IUsuarioUseCase _usuarioUseCase;
        private readonly IMapper _mapper;

        public UsuarioController(IValidator<SignUpRequest> validator, IManageEventsUseCase eventsUseCase,
            IUsuarioUseCase usuarioUseCase, IMapper mapper)
        {
            _validator = validator;
            _eventsUseCase = eventsUseCase;
            _usuarioUseCase = usuarioUseCase;
            _mapper = mapper;
        }

        public override async Task<Response> SignUp(SignUpRequest request, ServerCallContext context)
        {
            ValidationResult result = await _validator.ValidateAsync(request);

            if (!result.IsValid)
            {
                var response = new Response() { Token = "", Message = "" };
                var errorList = response.Error;
                errorList.AddRange(result.Errors.Select(e => $"{e.ErrorMessage}"));

                return response;
            }

            return await HandleRequest<SignInRequest>(async () =>
            {
                var token = await _usuarioUseCase.RegistrarUsuario(_mapper.Map<Usuario>(request));

                return new Response()
                {
                    Token = token.AccesToken,
                    Message = "Acceso autorizado"
                };
            }, _eventsUseCase);
        }

        public override async Task<Response> SignIn(SignInRequest request, ServerCallContext context)
        {
            return await HandleRequest<SignInRequest>(async () =>
            {
                var token = await _usuarioUseCase.IniciarSesion(_mapper.Map<Usuario>(request));

                return new Response() { Token = token.AccesToken, Message = "Acceso autorizado" };
            }, _eventsUseCase);
        }
    }
}