using Domain.UseCase.Common;
using EntryPoints.Grpc.Dtos.Protos;

namespace EntryPoints.Grpc.Extensions;

public static class GrpcServiceHandler
{
    public static async Task<Response> HandleRequest<TRequest>(
        Func<Task<Response>> handler, IManageEventsUseCase eventLogger)
        where TRequest : class
    {
        eventLogger.ConsoleInfoLog($"{typeof(TRequest)}");

        try
        {
            return await handler();
        }
        catch (Exception e)
        {
            return new Response()
            {
                Error = true,
                Message = e.Message,
                Token = ""
            };
        }
    }
}