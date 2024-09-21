using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManageH.Aplicacao_.DTO;
using TaskManageH.Aplicacao_.Interface;
using TaskManageH.Dominio.Entidades;
using TaskManageH.Dominio.Validadores;
using TaskManageH.Dominio.Validadores.Notifica;

namespace TaskManageH.WebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefasController : ControllerBase
    {
        private readonly IAplicacaoTarefas _aplicacaoTarefas;

        public TarefasController(IAplicacaoTarefas aplicacaoTarefas)
        {
            _aplicacaoTarefas = aplicacaoTarefas;
        }

        [Authorize]
        [Produces("application/json")]
        [HttpGet("/api/taregas/List")]
        public async Task<List<Tarefas>> ListarTarefas()
        {
            return await _aplicacaoTarefas.ListarTarefasAtivas();        
        }

        [Authorize]
        [Produces("application/json")]
        [HttpPost("/api/tarefas/Adding")]
        public async Task<List<Notificador>> AdicionaTarefas(TarefasDTO tarefasDTO)
        {
            var tarefas = new Tarefas();
            tarefas.Titulo = tarefasDTO.Titulo;
            tarefas.Descricao = tarefasDTO.Descricao;
            tarefas.Prazo = tarefasDTO.Prazo;
            tarefas.Prioridade = tarefasDTO.Prioridade;
            tarefas.Status = tarefasDTO.Status;
            tarefas.UsuarioId = await RetornarIdUsuarioLogado();

            await _aplicacaoTarefas.AdicionaTarefas(tarefas, tarefas.Status, tarefas.Prioridade);

            return tarefas.Notificacoes;

        }

        [Authorize]
        [Produces("application/json")]
        [HttpPut("/api/tarefas/Update")]
        public async Task<List<Notificador>> AtualizarTarefas(TarefasDTO tarefasDTO)
        {
            var tarefas = await _aplicacaoTarefas.BuscarPorId(tarefasDTO.IdTarefa) ;
            tarefas.Titulo = tarefasDTO.Titulo;
            tarefas.Descricao = tarefasDTO.Descricao;
            tarefas.Prazo = tarefasDTO.Prazo;
            tarefas.Prioridade = tarefasDTO.Prioridade;
            tarefas.Status = tarefasDTO.Status;
            tarefas.UsuarioId = await RetornarIdUsuarioLogado();

            await _aplicacaoTarefas.AdicionaTarefas(tarefas, tarefas.Status, tarefas.Prioridade);

            return tarefas.Notificacoes;

        }

        [Authorize]
        [Produces("application/json")]
        [HttpDelete("/api/tarefas/Delete")]
        public async Task<List<Notificador>> DeletarTarefas(TarefasDTO tarefasDTO)
        {
            var tarefas = await _aplicacaoTarefas.BuscarPorId(tarefasDTO.IdTarefa);

            await _aplicacaoTarefas.Excluir(tarefas);

            return tarefas.Notificacoes;

        }

        [Authorize] 
        [Produces("application/json")]
        [HttpGet("/api/tarefas/BuscarPorId/{id}")]
        public async Task<Tarefas> BuscarTarefaPorId(TarefasDTO tarefasDTO)
        {
            var tarefas = await _aplicacaoTarefas.BuscarPorId(tarefasDTO.IdTarefa);

            return tarefas;
        }


        private async Task<string> RetornarIdUsuarioLogado()
        {
            if (User != null)
            {
                var idUsuario = User.FindFirst("idUsuario");
                return idUsuario.Value;
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
