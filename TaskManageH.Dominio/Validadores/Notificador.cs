using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManageH.Dominio.ValorObjetos;

namespace TaskManageH.Dominio.Validadores
{
    public class Notificador
    {
        private List<Notificacao> _notificacoes = new List<Notificacao>();

        public IReadOnlyCollection<Notificacao> Notificacoes => _notificacoes;

        public bool TemNotificacoes => _notificacoes.Count > 0;

        public void AdicionarNotificacao(string mensagem, string nomeCampo)
        {
            _notificacoes.Add(new Notificacao(mensagem, nomeCampo));
        }
    }
}
