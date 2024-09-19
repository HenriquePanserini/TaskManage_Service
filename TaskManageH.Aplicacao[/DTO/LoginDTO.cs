using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManageH.Aplicacao_.DTO
{
    public class LoginDTO
    {
        public string? email { get; set; }
        public string? senha { get; set; }
        public int idade { get; set; }
        public string? celular { get; set; }
    }
}
