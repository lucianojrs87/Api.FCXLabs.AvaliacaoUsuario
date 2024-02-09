using Api.FCXLabs.AvaliacaoUsuario.Interfaces;
using Api.FCXLabs.AvaliacaoUsuario.Models;

namespace Api.FCXLabs.AvaliacaoUsuario.Repositories
{
    using Api.FCXLabs.AvaliacaoUsuario.Helpers;
    using Api.FCXLabs.AvaliacaoUsuario.Seeds;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    namespace SeuNamespace
    {
        public class UsuarioRepository : IUsuarioRepository
        {
            private readonly List<Usuario> _usuarios;

            public UsuarioRepository(List<Usuario> usuarios)
            {
                _usuarios = usuarios;
            }

            #region Consultas

            public async Task<List<Usuario>> ObterUsuariosAsync(UsuarioPesquisaRequest filtro)
            {
                var query = _usuarios.AsQueryable();

                if (filtro is not null)
                {
                    if (!string.IsNullOrEmpty(filtro.Nome))
                        query = query.Where(u => u.Nome.Contains(filtro.Nome));

                    if (!string.IsNullOrEmpty(filtro.CPF))
                        query = query.Where(u => u.CPF == filtro.CPF);

                    if (!string.IsNullOrEmpty(filtro.Login))
                        query = query.Where(u => u.Login == filtro.Login);

                    if (!string.IsNullOrEmpty(filtro.Status))
                        query = query.Where(u => u.Status == filtro.Status);

                    if (filtro.DataNascimento != null)
                        query = query.Where(u => u.DataNascimento == filtro.DataNascimento);

                    if (filtro.DataInclusao != null)
                        query = query.Where(u => u.DataInclusao == filtro.DataInclusao);

                    if (filtro.DataAlteracao != null)
                        query = query.Where(u => u.DataAlteracao == filtro.DataAlteracao);
                }
                else
                {
                    filtro = new UsuarioPesquisaRequest();
                }

                var usuarios = await Task.FromResult(query.ToList());

                return usuarios;
            }

            public async Task<(List<PagedResult<Usuario>>, int totalRegistros)> ListarUsuariosPaginadosAsync(UsuarioPesquisaRequest filtro)
            {
                var query = _usuarios.AsQueryable();

                if (filtro is not null)
                {
                    if (!string.IsNullOrEmpty(filtro.Nome))
                        query = query.Where(u => u.Nome.IndexOf(filtro.Nome, StringComparison.OrdinalIgnoreCase) >= 0);

                    if (!string.IsNullOrEmpty(filtro.CPF))
                        query = query.Where(u => u.CPF == filtro.CPF);

                    if (!string.IsNullOrEmpty(filtro.Login))
                        query = query.Where(u => u.Login == filtro.Login);

                    if (!string.IsNullOrEmpty(filtro.Status))
                        query = query.Where(u => u.Status == filtro.Status);
                    else
                        query = query.Where(u => u.Status == "Ativo");

                    if (filtro.DataNascimento != null)
                        query = query.Where(u => u.DataNascimento == filtro.DataNascimento);

                    if (filtro.FaixaEtariaMinima != null)
                    {
                        var dataNascimentoMinima = DateTime.Today.AddYears(-filtro.FaixaEtariaMinima.Value);
                        query = query.Where(u => u.DataNascimento <= dataNascimentoMinima);
                    }

                    if (filtro.FaixaEtariaMaxima != null)
                    {
                        var dataNascimentoMaxima = DateTime.Today.AddYears(-filtro.FaixaEtariaMaxima.Value - 1);
                        query = query.Where(u => u.DataNascimento > dataNascimentoMaxima);
                    }
                }
                else
                {
                    filtro = new UsuarioPesquisaRequest();
                    query = query.Where(u => u.Status == "Ativo");
                }

                // Calcula o total de registros e o número total de páginas
                var totalRegistros = await Task.FromResult(query.Count());
                var numeroTotalPaginas = (int)Math.Ceiling((double)totalRegistros / filtro.TamanhoPagina);

                var paginas = new List<PagedResult<Usuario>>();

                // Itera sobre cada página e adiciona os registros correspondentes à lista de páginas
                for (int pagina = 1; pagina <= numeroTotalPaginas; pagina++)
                {
                    var registrosPagina = await Task.FromResult(query.Skip((pagina - 1) * filtro.TamanhoPagina)
                                                                     .Take(filtro.TamanhoPagina)
                                                                     .ToList());

                    paginas.Add(new PagedResult<Usuario>(registrosPagina, pagina));
                }

                return (paginas, totalRegistros);
            }

            public async Task<Usuario> ObterUsuarioPorLoginAsync(string login)
            {
                return await Task.FromResult(_usuarios.FirstOrDefault(u => u.Login == login));
            }

            public async Task<Usuario> ObterUsuarioPorCpfLoginAsync(string cpf, string login)
            {
                return await Task.FromResult(_usuarios.FirstOrDefault(u => u.CPF == cpf && u.Login == login));
            }

            public async Task<Usuario> ObterUsuarioPorIdAsync(int id)
            {
                return await Task.FromResult(_usuarios.FirstOrDefault(u => u.Id == id));
            }

            #endregion

            #region Instruções de alteração de Dados
            public async Task<Usuario> InserirUsuarioAsync(Usuario usuario)
            {
                var erros = await ValidarUsuarioAsync(usuario);

                int proximoId = _usuarios.Any() ? _usuarios.Max(u => u.Id) + 1 : 1;

                usuario.Id = proximoId;
                usuario.DataInclusao = DateTime.Now;
                usuario.DataAlteracao = DateTime.Now;
                _usuarios.Add(usuario);
                return await Task.FromResult(usuario);
            }

            public async Task<bool> AlterarUsuarioAsync(Usuario usuario)
            {
                await ValidarUsuarioAsync(usuario, true);

                var usuarioExistente = _usuarios.FirstOrDefault(u => u.Id == usuario.Id);
                if (usuarioExistente == null)
                    return false;

                usuarioExistente.Nome = usuario.Nome;
                usuarioExistente.Email = usuario.Email;
                usuarioExistente.NomeMae = usuario.NomeMae;
                usuarioExistente.Telefone = usuario.Telefone;
                usuarioExistente.DataNascimento = usuario.DataNascimento;
                usuarioExistente.CPF = usuario.CPF;
                usuarioExistente.Status = usuario.Status;

                usuarioExistente.DataAlteracao = DateTime.Now;

                return await Task.FromResult(true);
            }
            public async Task<bool> ExcluirUsuarioAsync(int id)
            {
                var usuarioExistente = _usuarios.FirstOrDefault(u => u.Id == id);
                if (usuarioExistente == null)
                    return false;

                //Aplica a exclusão lógica
                usuarioExistente.Status = "Inativo";
                usuarioExistente.DataAlteracao = DateTime.Now;

                return await Task.FromResult(true);
            }
            #endregion

            #region Validações

            private async Task<List<string>> ValidarUsuarioAsync(Usuario usuario, bool isEdicao = false)
            {
                var mensagensErro = new List<string>();

                usuario.CPF = Utils.FormatarCPF(usuario.CPF);

                if (ValidarCPF(usuario.CPF) is false)
                    mensagensErro.Add("CPF inválido");

                if (_usuarios.Any(u => u.Email == usuario.Email && (!isEdicao || u.Id != usuario.Id)))
                    mensagensErro.Add("Email já está sendo usado por outro usuário; ");

                // Verifica se já existe um usuário com o mesmo CPF
                if (_usuarios.Any(u => u.CPF == usuario.CPF && (!isEdicao || u.Id != usuario.Id)))
                    mensagensErro.Add("CPF já está sendo usado por outro usuário;");

                // Verifica se já existe um usuário com o mesmo login
                if (_usuarios.Any(u => u.Login == usuario.Login && (!isEdicao || u.Id != usuario.Id)))
                    mensagensErro.Add("Login já está sendo usado por outro usuário; ");

                if (mensagensErro.Any())
                {
                    // Se houver mensagens de erro, lança uma exceção contendo a lista de mensagens
                    throw new Exception($"Erros de validação: {string.Join("", mensagensErro)}");
                }

                return await Task.FromResult(mensagensErro);
            }

            public static bool ValidarCPF(string cpf)
            {
                // Remover caracteres não numéricos do CPF
                cpf = new string(cpf.Where(char.IsDigit).ToArray());

                // Verifica se o CPF possui 11 dígitos
                if (cpf.Length != 11)
                    return false;

                // Verifica se todos os dígitos do CPF são iguais
                if (cpf.Distinct().Count() == 1)
                    return false;

                // Calcula o primeiro dígito verificador
                int soma = 0;
                for (int i = 0; i < 9; i++)
                    soma += int.Parse(cpf[i].ToString()) * (10 - i);
                int resto = soma % 11;
                int digitoVerificador1 = resto < 2 ? 0 : 11 - resto;

                // Verifica se o primeiro dígito verificador está correto
                if (int.Parse(cpf[9].ToString()) != digitoVerificador1)
                    return false;

                // Calcula o segundo dígito verificador
                soma = 0;
                for (int i = 0; i < 10; i++)
                    soma += int.Parse(cpf[i].ToString()) * (11 - i);
                resto = soma % 11;
                int digitoVerificador2 = resto < 2 ? 0 : 11 - resto;

                // Verifica se o segundo dígito verificador está correto
                if (int.Parse(cpf[10].ToString()) != digitoVerificador2)
                    return false;

                // CPF válido
                return true;
            }

            #endregion
        }
    }
}
