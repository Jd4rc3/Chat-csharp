using Domain.Model.Entities;
using Domain.Model.Entities.Gateway;
using Helpers.ObjectsUtils;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UseCase
{
    internal class UsuarioUseCase : IUsuarioUseCase
    {
        private readonly ISignUp _signUp;
        private readonly IOptions<ConfiguradorAppSettings> _configuracion;

        public UsuarioUseCase(ISignUp signUp, IOptions<ConfiguradorAppSettings> configuracio)
        {
            _signUp = signUp;
            _configuracion = configuracio;
        }

        public async Task<Object> RegistrarUsuario(Usuario nuevoUsuario)
        {
            var usuarioRegistrado = await _signUp.registrar(nuevoUsuario);
            var token = GenerarToken(usuarioRegistrado);

            return token;
        }

        private Object GenerarToken(Usuario usuario)
        {
            List<Claim> claims = new List<Claim>()
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
            return new { Token = token };
        }
    }
}