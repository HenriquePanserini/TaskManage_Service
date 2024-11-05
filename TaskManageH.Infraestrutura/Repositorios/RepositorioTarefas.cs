using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TaskManageH.Dominio.Entidades;
using TaskManageH.Dominio.Enum;
using TaskManageH.Dominio.Interfaces;
using TaskManageH.Infraestrutura.Repositorios.Base;

namespace TaskManageH.Infraestrutura.Repositorios
{
    public class RepositorioTarefas : RepositorioBase<Tarefas>, IRepositorioTarefas
    {
        private readonly DbContextOptions<AppDbContext> _optionsbuilder;

        public RepositorioTarefas()
        {
            _optionsbuilder = new DbContextOptions<AppDbContext>();
        }

        public async Task<List<Tarefas>> ListarTarefas(Expression<Func<Tarefas, bool>> exTarefa)
        {
            using (var data = new AppDbContext(_optionsbuilder))
            {
                return await data.Tarefas.Where(exTarefa).AsNoTracking().ToListAsync();
            }
        }

        public Task<List<Tarefas>> ListarTarefasCustom()
        {
            using (var data = new AppDbContext(_optionsbuilder))
            {
                var listaTarefas = ( from tarefas in data.Tarefas
                                     join usuario in data.Usuario
                                     on tarefas.UsuarioId equals usuario.Id
                                     select new Tarefas
                                     {
                                         Id = tarefas.Id,
                                         Descricao = tarefas.Descricao,
                                         Titulo = tarefas.Titulo,
                                         DataConclusao = tarefas.DataConclusao,
                                         DataCriacao = tarefas.DataCriacao,
                                         Usuario = usuario
                                         
                                     }
                                     ).AsNoTracking().ToListAsync();

                return listaTarefas;
            }
        }
    }
}
