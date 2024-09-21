using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManageH.Dominio.Enum;

namespace TaskManageH.Aplicacao_.DTO
{
    public class TarefasDTO
    {
        public int IdTarefa { get; set; }
        public string? Titulo { get; set; }
        public string? Descricao { get; set; }
        public DateTime? Prazo { get; set; }
        public PrioridadeTarefa Prioridade { get; set; }
        public StatusTarefa Status { get; set; }
        public string? IdUser { get; set; }
    }
}
