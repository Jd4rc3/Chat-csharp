using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model.Entities;
using Domain.Model.Entities.Gateway;
using DrivenAdapters.Mongo.Entities;
using MongoDB.Driver;

namespace DrivenAdapters.Mongo
{
    public class SignUp : ISignUp
    {
        private readonly IMongoCollection<UsuarioEntity> _collection;

        public SignUp(IContext context)
        {
            _collection = context.Usuarios;
        }

        public async Task<Usuario> registrar(Usuario usuario)
        {
            await _collection.InsertOneAsync(new UsuarioEntity() { Correo = usuario.Correo, Nombre = usuario.Nombre });

            return usuario;
        }
    }
}