using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManageH.Dominio.Validadores
{
    public class ValidadorDeCampos
    {
        private readonly Notificador _notificador;

        public ValidadorDeCampos(Notificador notificador)
        {
            _notificador = notificador;
        }

        public bool ValidarStringVazia(string nome, string nomeCampo)
        {
            if(string.IsNullOrEmpty(nome) || string.IsNullOrWhiteSpace(nomeCampo))
            {
                _notificador.AdicionarNotificacao("Campo obrigatorio", nomeCampo);
                return false;
            }

            return true;
        }

        public bool ValidarNumeroNulo(decimal valor, string nomeCampo)
        {
            if (valor < 1 || string.IsNullOrWhiteSpace(nomeCampo))
            {
                _notificador.AdicionarNotificacao("Valor não pode ser 0 ou nulo", nomeCampo);
                return false;
            }

            return true;
        }
    }
}
