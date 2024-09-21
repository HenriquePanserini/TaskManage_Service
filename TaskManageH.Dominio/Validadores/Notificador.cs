using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManageH.Dominio.Validadores.Notifica
{
    public class Notificador
    {

        public Notificador()
        {
            Notificacoes = new List<Notificador>();
        }

        [NotMapped]
        public string NomePropriedade { get; set; }

        [NotMapped]
        public string Mensagem { get; set; }

        [NotMapped]
        public List<Notificador> Notificacoes { get; set; }

        // Método para validar strings
        public bool ValidarPropriedadeString(string valor, string nomePropriedade)
        {
            if (string.IsNullOrWhiteSpace(valor))
            {
                Notificacoes.Add(new Notificador
                {
                    Mensagem = "Campo obrigatório",
                    NomePropriedade = nomePropriedade
                });

                return false;
            }

            return true;
        }

        // Método para validar valores decimais
        public bool ValidarPropriedadeDecimal(decimal valor, string nomePropriedade)
        {
            if (valor <= 0)
            {
                Notificacoes.Add(new Notificador
                {
                    Mensagem = "O valor deve ser maior que 0",
                    NomePropriedade = nomePropriedade
                });

                return false;
            }

            return true;
        }

    }
}