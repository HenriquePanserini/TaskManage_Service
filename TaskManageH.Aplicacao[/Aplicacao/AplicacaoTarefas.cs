using Dominio.Interfaces.InterfaceServicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManageH.Aplicacao_.Interface;
using TaskManageH.Dominio.Entidades;
using TaskManageH.Dominio.Enum;
using TaskManageH.Dominio.Interfaces;

namespace TaskManageH.Aplicacao_.Aplicacao
{
    public class AplicacaoTarefas : IAplicacaoTarefas
    {

        public readonly IServicoTarefas _servicoTarefas;
        public readonly IRepositorioTarefas _repositorioTarefas;

        public AplicacaoTarefas(IServicoTarefas servicoTarefas, IRepositorioTarefas repositorioTarefas)
        {
            _repositorioTarefas = repositorioTarefas;
            _servicoTarefas = servicoTarefas;
        }

        public async Task AdicionaTarefas(Tarefas tarefas, StatusTarefa statusTarefa, PrioridadeTarefa prioridade)
        {
            await _servicoTarefas.AtualizaTarefas(tarefas, statusTarefa, prioridade);
        }

        public async Task AtualizaTarefas(Tarefas tarefas, StatusTarefa statusTarefa, PrioridadeTarefa prioridade)
        {
            await _servicoTarefas.AtualizaTarefas(tarefas, statusTarefa, prioridade);
        }

        public async Task<List<Tarefas>> ListarTarefasAtivas()
        {
            return await _servicoTarefas.ListarTarefasAtivas();
        }

        public async Task Adicionar(Tarefas Objeto)
        {
            await _repositorioTarefas.Adicionar(Objeto);
        }

        public async Task Atualizar(Tarefas Objeto)
        {
            await _repositorioTarefas.Atualizar(Objeto);
        }

        public async Task<Tarefas> BuscarPorId(int Id)
        {
            return await _repositorioTarefas.BuscarPorId(Id);
        }

        public async Task Excluir(Tarefas Objeto)
        {
            await _repositorioTarefas.Excluir(Objeto);
        }

        public async Task<List<Tarefas>> Listar()
        {
            return   await _repositorioTarefas.Listar();
        }

    }
}
