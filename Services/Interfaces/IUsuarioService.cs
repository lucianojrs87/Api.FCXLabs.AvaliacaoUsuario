using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.FCXLabs.AvaliacaoUsuario.Helpers;
using Api.FCXLabs.AvaliacaoUsuario.Models;

namespace Api.FCXLabs.AvaliacaoUsuario.Services.Interfaces
{
    public interface IUsuarioService
    {
        #region Consultas

        Task<Usuario> ObterUsuarioPorIdAsync(int id);
        Task<(List<PagedResult<Usuario>>, int totalRegistros)> ListarUsuariosPaginadosAsync(UsuarioPesquisaRequest filtro);
        Task<Usuario> RecuperarSenhaAsync(RecuperarSenhaRequest recuperarSenhaRequest);

        #endregion

        #region Instruções de alteração de Dados

        Task<Usuario> InserirUsuarioAsync(Usuario usuario);
        Task<bool> AlterarUsuarioAsync(Usuario usuario);
        Task<bool> ExcluirUsuarioAsync(int id);
        Task ExcluirUsuariosAsync(List<int> ids);
        Task BloquearUsuarioAsync(int usuarioId);
        Task AtivarUsuarioAsync(int usuarioId);

        #endregion

        #region Exportação de Arquivos

        Task<byte[]> ExportarUsuariosToCsv();

        #endregion
    }
}
