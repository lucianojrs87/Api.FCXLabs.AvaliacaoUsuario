using Api.FCXLabs.AvaliacaoUsuario.Helpers;
using Api.FCXLabs.AvaliacaoUsuario.Models;

namespace Api.FCXLabs.AvaliacaoUsuario.Interfaces
{
    public interface IUsuarioRepository
    {
        #region Consultas
        Task<Usuario> ObterUsuarioPorIdAsync(int id);
        Task<Usuario> ObterUsuarioPorLoginAsync(string login);
        Task<List<Usuario>> ObterUsuariosAsync(UsuarioPesquisaRequest filtro);
        Task<Usuario> ObterUsuarioPorCpfLoginAsync(string cpf, string login);
        Task<(List<PagedResult<Usuario>>, int totalRegistros)> ListarUsuariosPaginadosAsync(UsuarioPesquisaRequest filtro);
        #endregion

        #region Instruções de banco
        Task<Usuario> InserirUsuarioAsync(Usuario usuario);
        Task<bool> AlterarUsuarioAsync(Usuario usuario);
        Task<bool> ExcluirUsuarioAsync(int id);
        #endregion
    }
}