using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TaskManageH.Dominio.Entidades;
using TaskManageH.Dominio.Enum;
using TaskManageH.Dominio.Interfaces.Base;

namespace TaskManageH.Dominio.Interfaces
{
    public interface IRepositorioTarefas : IRepositorioBase<Tarefas>
    {
        Task<List<Tarefas>> ListarTarefas(Expression<Func<Tarefas, bool>> exTarefa);

        Task<List<Tarefas>> ListarTarefasCustom();
    }
}
