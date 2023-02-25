using Grpc.Core;
using Grpc.Core.Interceptors;

namespace EntryPoints.Grpc.Validations;

public class SignUpInterceptor : Interceptor
{
    public override async Task<TResponse> UnaryServerHandler<TRequest, TResponse>(TRequest request,
        ServerCallContext context,
        UnaryServerMethod<TRequest, TResponse> continuation)
    {
        return await continuation(request, context);
    }
}