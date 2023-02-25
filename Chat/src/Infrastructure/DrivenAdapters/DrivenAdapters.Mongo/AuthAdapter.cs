using credinet.exception.middleware.models;
using Domain.Model.Entities;
using Domain.Model.Entities.Gateway;
using DrivenAdapters.Mongo.Entities;
using MongoDB.Driver;
using System.Threading.Tasks;
using AutoMapper;

namespace DrivenAdapters.Mongo
{
    public class AuthAdapter : IAuth
    {
        private readonly IMapper _mapper;
        private readonly IMongoCollection<UsuarioEntity> _collection;

        public AuthAdapter(IContext context, IMapper mapper)
        {
            _mapper = mapper;
            _collection = context.Usuarios;
        }

        public async Task<Usuario> Registrar(Usuario usuario)
        {
            if (await ObtenerUsuarioPorEmail(usuario.Correo) != null)
            {
                throw new BusinessException("Usuario se encuentra registrado", 400);
            }

            var nuevoUsuario = _mapper.Map<UsuarioEntity>(usuario);
            nuevoUsuario.Clave = HashPassword(usuario.Clave);
            await _collection.InsertOneAsync(nuevoUsuario);

            return _mapper.Map<Usuario>(nuevoUsuario);
        }

        public async Task<Usuario> IniciarSesion(Usuario usuario)
        {
            var usuarioEntity = await ObtenerUsuarioPorEmail(usuario.Correo);
            if (usuarioEntity is null)
                throw new BusinessException($"El usuario con correo {usuario.Correo} no se encuentra registrado", 400);
            if (!VerifyPassword(usuario.Clave, usuarioEntity.Clave))
                throw new BusinessException("Usuario o contraseña incorectos", 401);

            return _mapper.Map<Usuario>(usuarioEntity);
        }

        private string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        private bool VerifyPassword(string password, string hash)
        {
            return BCrypt.Net.BCrypt.Verify(password, hash);
        }

        private async Task<UsuarioEntity> ObtenerUsuarioPorEmail(string email)
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