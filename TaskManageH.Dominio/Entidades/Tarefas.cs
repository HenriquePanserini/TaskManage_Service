using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManageH.Dominio.Entidades
{
    public class Tarefas
    {
        public int Id { get; set; } // Identificador único
        public string Titulo { get; set; } // Título da tarefa
        public string Descricao { get; set; } // Descrição detalhada da tarefa
        public int Prioridade { get; set; } // Nível de prioridade (1 a 5, por exemplo)
        public string Status { get; set; } // Status (Ex: "Pendente", "Em Progresso", "Concluída")
        public DateTime DataCriacao { get; set; } // Data de criação da tarefa
        public DateTime? DataConclusao { get; set; } // Data de conclusão da tarefa (pode ser nula)
        public DateTime Prazo { get; set; } // Prazo final da tarefa

        // Chave estrangeira para o usuário
        public string UsuarioId { get; set; } // Chave estrangeira (assumindo que a chave de User é uma string)
        public Usuario Usuario { get; set; } // Navegação da relação com a entidade User
    }
}
