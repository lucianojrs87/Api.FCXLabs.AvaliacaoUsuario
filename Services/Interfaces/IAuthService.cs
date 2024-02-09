using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.FCXLabs.AvaliacaoUsuario.Models;

namespace Api.FCXLabs.AvaliacaoUsuario.Services.Interfaces
{
    public interface IAuthService
    {
        Task<bool> AuthenticateAsync(string username, string password);
    }
}
