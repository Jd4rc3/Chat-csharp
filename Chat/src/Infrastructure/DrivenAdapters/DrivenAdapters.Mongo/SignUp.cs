using credinet.exception.middleware.models;
using Domain.Model.Entities;
using Domain.Model.Entities.Gateway;
using DrivenAdapters.Mongo.Entities;
using MongoDB.Driver;
using System.Threading.Tasks;
using AutoMapper;

namespace DrivenAdapters.Mongo
{
    public class SignUp : ISignUp
    {
        private readonly IMapper _mapper;
        private readonly IMongoCollection<UsuarioEntity> _collection;

        public SignUp(IContext context, IMapper mapper)
        {
            _mapper = mapper;
            _collection = context.Usuarios;
        }

        public async Task<Usuario> Registrar(Usuario usuario)
        {
            if (await ObtenerUsuario(usuario.Correo) != null)
            {
                throw new BusinessException("Usuario se encuentra registrado", 400);
            }

            var nuevoUsuario = _mapper.Map<UsuarioEntity>(usuario);
            await _collection.InsertOneAsync(nuevoUsuario);

            return _mapper.Map<Usuario>(nuevoUsuario);
        }

        private async Task<UsuarioEntity> ObtenerUsuario(string email)
        {
            var cursor = await _collection.FindAsync(FiltroEmail(email));
            return cursor.FirstOrDefault();
        }

        private FilterDefinition<UsuarioEntity> FiltroEmail(string email)
        {
            var filtro = Builders<UsuarioEntity>.Filter;
            return filtro.Eq(user => user.Correo, email);
        }
    }
}