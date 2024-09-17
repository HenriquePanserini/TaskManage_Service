using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManageH.Dominio.ValorObjetos;

public class Notificacao
{
    [NotMapped]
    public string NomeCampo { get; set; }
    [NotMapped]
    public string Mensagem { get; private set; }

    public Notificacao(string mensagem, string nomeCampo)
    {
        Mensagem = mensagem;
        NomeCampo = nomeCampo;
    }
}