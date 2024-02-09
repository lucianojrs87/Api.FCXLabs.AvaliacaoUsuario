using Api.FCXLabs.AvaliacaoUsuario.Interfaces;
using Api.FCXLabs.AvaliacaoUsuario.Models;
using Api.FCXLabs.AvaliacaoUsuario.Services.Interfaces;
using System.Text;
using Api.FCXLabs.AvaliacaoUsuario.Helpers;
namespace Api.FCXLabs.AvaliacaoUsuario.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        #region Consultas
        public async Task<(List<PagedResult<Usuario>>, int totalRegistros)> ListarUsuariosPaginadosAsync(UsuarioPesquisaRequest filtro)
        {
            return await _usuarioRepository.ListarUsuariosPaginadosAsync(filtro);
        }

        public async Task<Usuario> ObterUsuarioPorIdAsync(int id)
        {
            return await _usuarioRepository.ObterUsuarioPorIdAsync(id);
        }

        public async Task<Usuario> RecuperarSenhaAsync(RecuperarSenhaRequest recuperarSenhaRequest)
        {
            var usuarioExistente = await _usuarioRepository.ObterUsuarioPorCpfLoginAsync(recuperarSenhaRequest.CPF, recuperarSenhaRequest.Login);

            if (usuarioExistente != null)
                return usuarioExistente;
            else
                throw new Exception("Dados pessoais incorretos. Por favor, verifique o CPF e o nome fornecidos.");
        }
        #endregion

        #region Instruções de Alteração de Dados
        public async Task<Usuario> InserirUsuarioAsync(Usuario usuario)
        {
            return await _usuarioRepository.InserirUsuarioAsync(usuario);
        }

        public async Task<bool> AlterarUsuarioAsync(Usuario usuario)
        {
            return await _usuarioRepository.AlterarUsuarioAsync(usuario);
        }

        public async Task<bool> ExcluirUsuarioAsync(int id)
        {
            return await _usuarioRepository.ExcluirUsuarioAsync(id);
        }

        public async Task ExcluirUsuariosAsync(List<int> ids)
        {
            foreach (var id in ids)
            {
                await _usuarioRepository.ExcluirUsuarioAsync(id);
            }
        }

        public async Task BloquearUsuarioAsync(int usuarioId)
        {
            var usuario = await _usuarioRepository.ObterUsuarioPorIdAsync(usuarioId);
            if (usuario != null)
            {
                usuario.Status = "Bloqueado";
                await _usuarioRepository.AlterarUsuarioAsync(usuario);
            }
        }

        public async Task AtivarUsuarioAsync(int usuarioId)
        {
            var usuario = await _usuarioRepository.ObterUsuarioPorIdAsync(usuarioId);
            if (usuario != null)
            {
                usuario.Status = "Ativo";
                await _usuarioRepository.AlterarUsuarioAsync(usuario);
            }
        }

        #endregion

        #region Exportação de arquivo
        public async Task<byte[]> ExportarUsuariosToCsv()
        {
            var usuarios = await _usuarioRepository.ObterUsuariosAsync(new UsuarioPesquisaRequest());

            // Constrói o conteúdo do arquivo CSV
            var csvContent = new StringBuilder();
            csvContent.AppendLine("Id,Nome,Login,Email,Telefone,CPF,DataNascimento,NomeMae,Status,DataInclusao,DataAlteracao");
            foreach (var usuario in usuarios)
            {
                csvContent.AppendLine($"{usuario.Id},{usuario.Nome},{usuario.Login},{usuario.Email},{usuario.Telefone},{usuario.CPF},{usuario.DataNascimento},{usuario.NomeMae},{usuario.Status},{usuario.DataInclusao},{usuario.DataAlteracao}");
            }

            // Converte o conteúdo CSV para um array de bytes
            return Encoding.UTF8.GetBytes(csvContent.ToString());
        }
        #endregion
    }
}
