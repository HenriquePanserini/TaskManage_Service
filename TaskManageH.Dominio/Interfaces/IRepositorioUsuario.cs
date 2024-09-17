using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManageH.Dominio.Entidades;
using TaskManageH.Dominio.Interfaces.Base;

namespace TaskManageH.Dominio.Interfaces
{
    public interface IRepositorioUsuario : IRepositorioBase<Usuario> 
    {
        Task<bool> AdicionaUsuario(string email, string senha, int idade, string celular);

        Task<bool> ExisteUsuario(string email, string senha);

        Task<bool> RetornaIdUsuario(string email);
    }
}
