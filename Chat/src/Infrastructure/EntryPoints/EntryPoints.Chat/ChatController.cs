using EntryPoints.Chat.Dtos.Protos;
using Grpc.Core;
using Microsoft.AspNetCore.Authorization;

namespace EntryPoints.Chat;

[Authorize]
public class ChatController : ChatService.ChatServiceBase
{
    public override Task<Mensaje> Enviar(Mensaje request, ServerCallContext context)
    {
        var v = context.GetHttpContext().User.Claims.Where(c => c.Type == "id").FirstOrDefault().Value;

        request.Fecha = DateTime.UtcNow.ToString("yyyy-MM-dd hh:mm");
        
        return Task.FromResult(request);
    }
}