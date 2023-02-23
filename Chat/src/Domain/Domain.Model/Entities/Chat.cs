using System.Collections.Generic;

namespace Domain.Model.Entities
{
    public class Chat
    {
        public List<Usuario> Usuarios { get; set; }

        public List<Mensaje> Mensajes { get; set; }
    }
}