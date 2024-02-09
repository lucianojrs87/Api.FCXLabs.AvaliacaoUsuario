using Microsoft.AspNetCore.Mvc;
using Api.FCXLabs.AvaliacaoUsuario.Models;
using Api.FCXLabs.AvaliacaoUsuario.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using System.Reflection.Metadata.Ecma335;

namespace Api.FCXLabs.AvaliacaoUsuario.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginRequest autenticacao)
        {
            // Verificar as credenciais do usuário
            if (await _authService.AuthenticateAsync(autenticacao.Login, autenticacao.Senha))
            {
                var filtro = new UsuarioPesquisaRequest();
                return RedirectToAction("ObterUsuarios", "Usuario", new { filtro, login = true});
            }

            else
                return Unauthorized("Credenciais inválidas para acessar o sistema");
        }
    }
}
