using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManageH.Aplicacao_.DTO
{
    public class TarefasDTO
    {
        public int IdTarefa { get; set; }
        public string? Titulo { get; set; }
        public string? Descricao { get; set; }
        public int Prioridade { get; set; }
        public string? IdUser { get; set; }
    }
}
