using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManageH.Dominio.Entidades;
using TaskManageH.Dominio.Enum;
using TaskManageH.Dominio.ViewModel;

namespace Dominio.Interfaces.InterfaceServicos
{
    public interface IServicoTarefas
    {
        Task AdicionaTarefas(Tarefas tarefas, StatusTarefa statusTarefa, PrioridadeTarefa prioridade);
        Task AtualizaTarefas(Tarefas tarefas, StatusTarefa statusTarefa, PrioridadeTarefa prioridade);
        Task<List<Tarefas>> ListarTarefasAtivas();
        Task<List<TarefasViewModel>> ListarTarefasCustom();
    }
}