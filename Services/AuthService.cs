using Api.FCXLabs.AvaliacaoUsuario.Interfaces;
using Api.FCXLabs.AvaliacaoUsuario.Models;
using Api.FCXLabs.AvaliacaoUsuario.Services.Interfaces;
using System.Text;

namespace Api.FCXLabs.AvaliacaoUsuario.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public AuthService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<bool> AuthenticateAsync(string login, string senha)
        {
            var user = await _usuarioRepository.ObterUsuarioPorLoginAsync(login);
            if (user != null && user.Senha == senha && user.Status == "Ativo")
                return true;

            return false;
        }
    }
}
