using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManageH.Dominio.ViewModel
{
    public class TarefasViewModel
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public int Prioridade { get; set; }
        public int Status { get; set; }
        public string Prazo { get; set; }
        public string DataCriacao { get; set; }
        public string Usuario { get; set; }


    }
}
