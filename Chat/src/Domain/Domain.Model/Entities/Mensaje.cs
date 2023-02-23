using System;

namespace Domain.Model.Entities
{
    public class Mensaje
    {
        public DateTime FechaDeEnvio { get; set; }

        public string Contenido { get; set; }
    }
}