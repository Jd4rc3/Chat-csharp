using MongoDB.Bson.Serialization.Attributes;

namespace DrivenAdapters.Mongo.Entities
{
    public class UsuarioEntity
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }

        public string Nombre { get; set; }

        public string Correo { get; set; }
    }
}