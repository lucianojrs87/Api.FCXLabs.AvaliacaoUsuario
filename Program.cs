using Api.FCXLabs.AvaliacaoUsuario.Interfaces;
using Api.FCXLabs.AvaliacaoUsuario.Models;
using Api.FCXLabs.AvaliacaoUsuario.Repositories.SeuNamespace;
using Api.FCXLabs.AvaliacaoUsuario.Seeds;
using Api.FCXLabs.AvaliacaoUsuario.Services;
using Api.FCXLabs.AvaliacaoUsuario.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Api de Cadastro de Usuários", Version = "v1" });
});

var usuarios = UsuarioSeeds.Inicializar();

builder.Services.AddSingleton<List<Usuario>>(usuarios);

#region Services

builder.Services.AddSingleton<IUsuarioService, UsuarioService>();
builder.Services.AddSingleton<IAuthService, AuthService>();

#endregion

#region Repositories

builder.Services.AddSingleton<IUsuarioRepository, UsuarioRepository>();

#endregion

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api de Cadastro de Usuários V1");
    });
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();