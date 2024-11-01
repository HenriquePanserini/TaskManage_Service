using Dominio.Interfaces.InterfaceServicos;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using TaskManageH.Aplicacao_.Aplicacao;
using TaskManageH.Aplicacao_.Interface;
using TaskManageH.Aplicacao_.Servico;
using TaskManageH.Dominio.Entidades;
using TaskManageH.Dominio.Interfaces;
using TaskManageH.Dominio.Interfaces.Base;
using TaskManageH.Infraestrutura.Repositorios;
using TaskManageH.Infraestrutura.Repositorios.Base;
using WebService.Token;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var urlCliente = "http://localhost:4200";

#region CORS config
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp",
        policy => policy.WithOrigins(urlCliente)
                        .AllowAnyHeader()
                        .AllowAnyMethod());
});
#endregion

builder.Services.AddLogging();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
             options.UseSqlServer(
                 builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddDefaultIdentity<Usuario>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<AppDbContext>();

builder.Services.AddSingleton(typeof(IRepositorioBase<>), typeof(RepositorioBase<>));
builder.Services.AddSingleton<IRepositorioTarefas, RepositorioTarefas>();
builder.Services.AddSingleton<IRepositorioUsuario, RepositorioUsuario>();

builder.Services.AddSingleton<IServicoTarefas, ServicoTarefas>();

builder.Services.AddSingleton<IAplicacaoTarefas, AplicacaoTarefas>();
builder.Services.AddSingleton<IAplicacaoUsuario, AplicacaoUsuario>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
      .AddJwtBearer(option =>
      {
          option.TokenValidationParameters = new TokenValidationParameters
          {
              ValidateIssuer = false,
              ValidateAudience = false,
              ValidateLifetime = true,
              ValidateIssuerSigningKey = true,

              ValidIssuer = "Teste.Securiry.Bearer",
              ValidAudience = "Teste.Securiry.Bearer",
              IssuerSigningKey = JwtSecurityKey.Create("Secret_Key-12345678")
          };

          option.Events = new JwtBearerEvents
          {
              OnAuthenticationFailed = context =>
              {
                  Console.WriteLine("OnAuthenticationFailed: " + context.Exception.Message);
                  return Task.CompletedTask;
              },
              OnTokenValidated = context =>
              {
                  Console.WriteLine("OnTokenValidated: " + context.SecurityToken);
                  return Task.CompletedTask;
              }
          };
      });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowAngularApp");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
