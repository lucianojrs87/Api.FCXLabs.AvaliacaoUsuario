using Microsoft.AspNetCore.Mvc;
using Api.FCXLabs.AvaliacaoUsuario.Models;
using Api.FCXLabs.AvaliacaoUsuario.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using System.Reflection.Metadata.Ecma335;
using Api.FCXLabs.AvaliacaoUsuario.Helpers;

namespace Api.FCXLabs.AvaliacaoUsuario.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IAuthService _authService;

        public UsuarioController(IUsuarioService usuarioService, IAuthService authService)
        {
            _usuarioService = usuarioService;
            _authService = authService;
        }

        [HttpGet]
        [Route("ObterUsuarios")]
        public async Task<IActionResult> ObterUsuarios(UsuarioPesquisaRequest? filtro, bool login = false)
        {
            (List<PagedResult<Usuario>> usuariosPaginados, int totalRegistros) usuarios = await _usuarioService.ListarUsuariosPaginadosAsync(filtro);
            if (login)
                return Ok(new { Mensagem = "Usuário logado com sucesso", TotalRegistros = usuarios.totalRegistros, ListaPaginada = usuarios.usuariosPaginados });
            else
                return Ok(new { TotalRegistros = usuarios.totalRegistros, ListaPaginada = usuarios.usuariosPaginados });
        }

        [HttpGet]

        [Route("ObterUsuarioPorId")]
        public async Task<IActionResult> ObterUsuarioPorId(int id)
        {
            var usuario = await _usuarioService.ObterUsuarioPorIdAsync(id);
            if (usuario == null)
                return NotFound($"Usuário não encontrado para o Id: {id}.");

            return Ok(usuario);
        }

        [HttpPost]
        [Route("CadastrarUsuario")]
        public async Task<IActionResult> CadastrarUsuario(Usuario usuario)
        {
            try
            {
                var user = await _usuarioService.InserirUsuarioAsync(usuario);
                return Ok($"Usuário cadastrado com o Id: {user.Id}");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("EditarUsuario")]
        public async Task<IActionResult> EditarUsuario(int id, [FromBody] Usuario usuario)
        {
            try
            {
                if (id != usuario.Id)
                {
                    return BadRequest("Não é possível alterar o identificador único do usuário");
                }

                await _usuarioService.AlterarUsuarioAsync(usuario);
                return Ok("Usuário alterado com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("ExcluirUsuario")]
        public async Task<IActionResult> ExcluirUsuario(int id)
        {
            var usuario = await _usuarioService.ObterUsuarioPorIdAsync(id);
            if (usuario == null)
                return NotFound();

            await _usuarioService.ExcluirUsuarioAsync(id);
            return Ok("Usuário excluído com sucesso");
        }

        [HttpGet]
        [Route("ExportarUsuarios")]
        public async Task<IActionResult> ExportarUsuarios()
        {
            var csvData = await _usuarioService.ExportarUsuariosToCsv();
            return File(csvData, "text/csv", "usuarios.csv");
        }

        [HttpGet]
        [Route("RecuperarSenha")]
        public async Task<IActionResult> RecuperarSenha(RecuperarSenhaRequest request)
        {
            try
            {
                var usuario = await _usuarioService.RecuperarSenhaAsync(request);
                return Ok(new { Login = usuario.Login, Senha = usuario.Senha });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("ExcluirUsuarios")]
        public async Task<IActionResult> ExcluirUsuarios([FromBody] List<int> ids)
        {
            try
            {
                if (ids == null || ids.Count == 0)
                {
                    return BadRequest("Nenhum usuário selecionado para exclusão.");
                }

                await _usuarioService.ExcluirUsuariosAsync(ids);

                return Ok("Usuário(s) excluído(s) com sucesso.");
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        [HttpPut]
        [Route("Bloquear")]
        public async Task<IActionResult> BloquearUsuario(int id)
        {
            await _usuarioService.BloquearUsuarioAsync(id);
            return Ok("Usuário bloqueado com sucesso");
        }

        [HttpPut]
        [Route("Ativar")]
        public async Task<IActionResult> AtivarUsuario(int id)
        {
            await _usuarioService.AtivarUsuarioAsync(id);
            return Ok("Usuário ativado com sucesso");
        }
    }
}
