using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManageH.Aplicacao_.Interface.Base;
using TaskManageH.Dominio.Entidades;
using TaskManageH.Dominio.Enum;

namespace TaskManageH.Aplicacao_.Interface
{
    public interface IAplicacaoTarefas : IAplicacaoBase<Tarefas>
    {
        Task AdicionaTarefas(Tarefas tarefas, StatusTarefa statusTarefa, PrioridadeTarefa prioridade);
        Task AtualizaTarefas(Tarefas tarefas, StatusTarefa statusTarefa, PrioridadeTarefa prioridade);
        Task<List<Tarefas>> ListarTarefasAtivas();
    }
}
