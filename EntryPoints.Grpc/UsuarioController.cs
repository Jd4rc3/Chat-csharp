using EntryPoints.Grpc.Dtos.Protos;
using Grpc.Core;

namespace EntryPoints.Grpc
{
    public class UsuarioController : UsuarioService.UsuarioServiceBase
    {
        public override Task<Response> SignUp(SignUpRequest request, ServerCallContext context)
        {
            throw new NotImplementedException();
        }
    }
}