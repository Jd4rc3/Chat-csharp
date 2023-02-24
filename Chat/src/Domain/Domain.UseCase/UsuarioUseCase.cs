using Domain.Model.Entities;
using Domain.Model.Entities.Gateway;
using Helpers.ObjectsUtils;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UseCase
{
    public class UsuarioUseCase : IUsuarioUseCase
    {
        private readonly IAuth _auth;
        private readonly IOptions<ConfiguradorAppSettings> _configuracion;

        public UsuarioUseCase(IAuth auth, IOptions<ConfiguradorAppSettings> configuracio)
        {
            _auth = auth;
            _configuracion = configuracio;
        }

        public async Task<Token> IniciarSesion(Usuario usuario)
        {
            var usuarioVerificado = await _auth.IniciarSesion(usuario);
            return GenerarToken(usuarioVerificado);
        }

        public async Task<Token> RegistrarUsuario(Usuario nuevoUsuario)
        {
            var usuarioRegistrado = await _auth.Registrar(nuevoUsuario);
            var token = GenerarToken(usuarioRegistrado);

            return token;
        }

        private Token GenerarToken(Usuario usuario)
        {
            List<Claim> claims = new()
            {
                new Claim("correo", usuario.Correo),
                new Claim("nombre", usuario.Nombre),
                new Claim("id", usuario.Id),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuracion.Value.KeyJWT));
            var credenciales = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiracion = DateTime.UtcNow.AddDays(7);
            var token = new JwtSecurityToken(
                issuer: _configuracion.Value.ApplicationName,
                audience: "localhost",
                claims, expires: expiracion, signingCredentials: credenciales
                );
            return new Token() { AccesToken = new JwtSecurityTokenHandler().WriteToken(token) };
        }
    }
}