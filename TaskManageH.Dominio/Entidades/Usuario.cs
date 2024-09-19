using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManageH.Dominio.Enum;

namespace TaskManageH.Dominio.Entidades
{
    public class Usuario : IdentityUser
    {
       
        public int Idade { get; set; }
        public string Celular { get; set; }
        public TipoUsuario? Tipo { get; set; }
    }
}
