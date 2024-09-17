﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TaskManageH.Dominio.Entidades;
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

        public async Task<List<Tarefas>> ListarNoticias(Expression<Func<Tarefas, bool>> exTarefa)
        {
            using (var data = new AppDbContext(_optionsbuilder))
            {
                return await data.Tarefas.Where(exTarefa).AsNoTracking().ToListAsync();
            }
        }
    }
}
