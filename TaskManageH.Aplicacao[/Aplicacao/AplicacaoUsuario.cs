using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManageH.Aplicacao_.Interface;
using TaskManageH.Dominio.Interfaces;

namespace TaskManageH.Aplicacao_.Aplicacao
{
    public class AplicacaoUsuario : IAplicacaoUsuario
    {
        public readonly IRepositorioUsuario _repositorioUsuario;
        
        public AplicacaoUsuario(IRepositorioUsuario repositorioUsuario)
        {
            _repositorioUsuario = repositorioUsuario;
        }

        public async Task<bool> AdicionaUsuario(string email, string senha, int idade, string celular)
        {
            return await _repositorioUsuario.AdicionaUsuario(email, senha, idade, celular);
        }

        public async Task<bool> ExisteUsuario(string email, string senha)
        {
            return await _repositorioUsuario.ExisteUsuario(email, senha);
        }

        public async Task<string> ReturnIdUsuario(string email)
        {
            return await _repositorioUsuario.RetornaIdUsuario(email);
        }
    }
}
