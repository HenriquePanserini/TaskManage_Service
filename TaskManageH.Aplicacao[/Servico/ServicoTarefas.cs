using Dominio.Interfaces.InterfaceServicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManageH.Dominio.Entidades;
using TaskManageH.Dominio.Enum;
using TaskManageH.Dominio.Interfaces;
using TaskManageH.Dominio.Interfaces.Base;
using TaskManageH.Dominio.ViewModel;

namespace TaskManageH.Aplicacao_.Servico
{
    public class ServicoTarefas : IServicoTarefas
    {

        private readonly IRepositorioTarefas _repositorioTarefas;

        public ServicoTarefas(IRepositorioTarefas repositorioTarefas)
        {
            _repositorioTarefas = repositorioTarefas;
        }

        public async Task AdicionaTarefas(Tarefas tarefas, StatusTarefa statusTarefa, PrioridadeTarefa prioridade)
        {
            // Validação dos campos obrigatórios
            var validarTitulo = tarefas.ValidarPropriedadeString(tarefas.Titulo, "Titulo");
            var validarDescricao = tarefas.ValidarPropriedadeString(tarefas.Descricao, "Descricao");

            if (validarTitulo && validarDescricao)
            {
                // Definindo as propriedades da tarefa
                tarefas.DataCriacao = DateTime.Now;
                tarefas.DataConclusao = null; // Assume que a tarefa não está concluída ainda
                tarefas.Status = statusTarefa; // Atribui o status da tarefa passado como parâmetro
                tarefas.Prioridade = prioridade;

                // Adicionando a tarefa ao repositório
                await _repositorioTarefas.Adicionar(tarefas);
            }
        }

        public async Task AtualizaTarefas(Tarefas tarefas, StatusTarefa statusTarefa, PrioridadeTarefa prioridade)
        {
            // Validação dos campos obrigatórios
            var validarTitulo = tarefas.ValidarPropriedadeString(tarefas.Titulo, "Titulo");
            var validarDescricao = tarefas.ValidarPropriedadeString(tarefas.Descricao, "Descricao");

            if (validarTitulo && validarDescricao)
            {
                // Definindo as propriedades da tarefa
                tarefas.DataCriacao = DateTime.Now;
                tarefas.DataConclusao = null; // Assume que a tarefa não está concluída ainda
                tarefas.Status = statusTarefa; // Atribui o status da tarefa passado como parâmetro
                tarefas.Prioridade = prioridade;

                // Adicionando a tarefa ao repositório
                await _repositorioTarefas.Atualizar(tarefas);
            }
        }

        public async Task<List<Tarefas>> ListarTarefasAtivas()
        {
            return await _repositorioTarefas.ListarTarefas(n => n.Status == StatusTarefa.Pendente);
        }

        public async Task<List<TarefasViewModel>> ListarTarefasCustom()
        {
            var listarNoticiasCustom = await _repositorioTarefas.ListarTarefasCustom();

            var response = (
                    from noticia in listarNoticiasCustom
                    select new TarefasViewModel
                    {
                        Id = noticia.Id,
                        Titulo = noticia.Titulo,
                        Descricao = noticia.Descricao,
                    }     
                ).ToList();

            return response;
        }
    }
}
