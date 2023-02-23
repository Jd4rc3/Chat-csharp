using Domain.Model.Entities;
using Domain.Model.Entities.Gateway;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Domain.UseCase
{
    internal class UsuarioUseCase : IUsuarioUseCase
    {
        private readonly ISignUp _signUp;

        public UsuarioUseCase(ISignUp signUp)
        {
            _signUp = signUp;
        }

        public async Task<Usuario> RegistrarUsuario(Usuario nuevoUsuario)
        {
            var usuarioRegistrado = await _signUp.registrar(nuevoUsuario);

            return usuarioRegistrado;
        }

        public Task<Object> GenerarToken(Usuario usuario)
        {
            List<Claim> claims = new List<Claim>();
        }
    }
}