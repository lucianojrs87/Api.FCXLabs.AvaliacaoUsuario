using Api.FCXLabs.AvaliacaoUsuario.Interfaces;
using Api.FCXLabs.AvaliacaoUsuario.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.FCXLabs.AvaliacaoUsuario.Seeds
{

    public static class UsuarioSeeds
    {
        public static List<Usuario> Inicializar()
        {
            var usuarios = new List<Usuario>
            {
                #region Inserção de users fakes para testes
                new Usuario
                {
                    Id = 1,
                    Nome = "Usuário 1",
                    Login = "usuario1",
                    Senha = "senha1",
                    Email = "joao@exemplo.com",
                    Telefone = "123456789",
                    CPF = "12345678910",
                    DataNascimento = new DateTime(1990, 1, 1),
                    NomeMae = "Mãe 1",
                    Status = "Ativo",
                    DataInclusao = DateTime.Now,
                    DataAlteracao = DateTime.Now
                },
                new Usuario
                {
                    Id = 2,
                    Nome = "Usuário 2",
                    Login = "usuario2",
                    Senha = "senha2",
                    Email = "exemplo2@example.com",
                    Telefone = "987654321",
                    CPF = Helpers.Utils.GerarCPF(),
                    DataNascimento = new DateTime(1995, 5, 5),
                    NomeMae = "Mãe 2",
                    Status = "Ativo",
                    DataInclusao = DateTime.Now,
                    DataAlteracao = DateTime.Now
                },
                new Usuario
                {
                    Id = 3,
                    Nome = "Usuário 3",
                    Login = "usuario3",
                    Senha = "senha3",
                    Email = "usuario3@example.com",
                    Telefone = "123456789",
                    CPF = Helpers.Utils.GerarCPF(),
                    DataNascimento = new DateTime(1980, 3, 15),
                    NomeMae = "Mãe 3",
                    Status = "Ativo",
                    DataInclusao = DateTime.Now,
                    DataAlteracao = DateTime.Now
                },
                new Usuario
                {
                    Id = 4,
                    Nome = "Usuário 4",
                    Login = "usuario4",
                    Senha = "senha4",
                    Email = "usuario4@example.com",
                    Telefone = "987654321",
                    CPF = Helpers.Utils.GerarCPF(),
                    DataNascimento = new DateTime(1975, 7, 20),
                    NomeMae = "Mãe 4",
                    Status = "Ativo",
                    DataInclusao = DateTime.Now,
                    DataAlteracao = DateTime.Now
                },
                new Usuario
                {
                    Id = 5,
                    Nome = "Usuário 5",
                    Login = "usuario5",
                    Senha = "senha5",
                    Email = "usuario5@example.com",
                    Telefone = "123456789",
                    CPF = Helpers.Utils.GerarCPF(),
                    DataNascimento = new DateTime(1992, 10, 10),
                    NomeMae = "Mãe 5",
                    Status = "Ativo",
                    DataInclusao = DateTime.Now,
                    DataAlteracao = DateTime.Now
                },
                new Usuario
                {
                    Id = 6,
                    Nome = "Usuário 6",
                    Login = "usuario6",
                    Senha = "senha6",
                    Email = "usuario6@example.com",
                    Telefone = "987654321",
                    CPF = Helpers.Utils.GerarCPF(),
                    DataNascimento = new DateTime(1988, 8, 25),
                    NomeMae = "Mãe 6",
                    Status = "Ativo",
                    DataInclusao = DateTime.Now,
                    DataAlteracao = DateTime.Now
                },
                new Usuario
                {
                    Id = 7,
                    Nome = "Usuário 7",
                    Login = "usuario7",
                    Senha = "senha7",
                    Email = "usuario7@example.com",
                    Telefone = "123456789",
                    CPF = Helpers.Utils.GerarCPF(),
                    DataNascimento = new DateTime(1997, 12, 5),
                    NomeMae = "Mãe 7",
                    Status = "Ativo",
                    DataInclusao = DateTime.Now,
                    DataAlteracao = DateTime.Now
                },
                new Usuario
                {
                    Id = 8,
                    Nome = "Usuário 8",
                    Login = "usuario8",
                    Senha = "senha8",
                    Email = "usuario8@example.com",
                    Telefone = "987654321",
                    CPF = Helpers.Utils.GerarCPF(),
                    DataNascimento = new DateTime(1977, 4, 30),
                    NomeMae = "Mãe 8",
                    Status = "Ativo",
                    DataInclusao = DateTime.Now,
                    DataAlteracao = DateTime.Now
                },
                new Usuario
                {
                    Id = 9,
                    Nome = "Usuário 9",
                    Login = "usuario9",
                    Senha = "senha9",
                    Email = "usuario9@example.com",
                    Telefone = "123456789",
                    CPF = Helpers.Utils.GerarCPF(),
                    DataNascimento = new DateTime(1985, 6, 12),
                    NomeMae = "Mãe 9",
                    Status = "Ativo",
                    DataInclusao = DateTime.Now,
                    DataAlteracao = DateTime.Now
                },
                new Usuario
                {
                    Id = 10,
                    Nome = "Usuário 10",
                    Login = "usuario10",
                    Senha = "senha10",
                    Email = "usuario10@example.com",
                    Telefone = "987654321",
                    CPF = Helpers.Utils.GerarCPF(),
                    DataNascimento = new DateTime(1998, 9, 8),
                    NomeMae = "Mãe 10",
                    Status = "Ativo",
                    DataInclusao = DateTime.Now,
                    DataAlteracao = DateTime.Now
                },
                new Usuario
                {
                    Id = 11,
                    Nome = "Usuário 11",
                    Login = "usuario11",
                    Senha = "senha11",
                    Email = "usuario11@example.com",
                    Telefone = "123456789",
                    CPF = Helpers.Utils.GerarCPF(),
                    DataNascimento = new DateTime(1994, 2, 28),
                    NomeMae = "Mãe 11",
                    Status = "Ativo",
                    DataInclusao = DateTime.Now,
                    DataAlteracao = DateTime.Now
                }
#endregion
            };

            return usuarios;
        }
    }
}

