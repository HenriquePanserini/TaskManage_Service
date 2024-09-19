using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManageH.Aplicacao_.Interface.Base
{
    public interface IAplicacaoBase<T> where T : class
    {
        Task Adicionar(T Objeto);
        Task Atualizar(T Objeto);
        Task Excluir(T Objeto);
        Task<T> BuscarPorId(int Id);
        Task<List<T>> Listar();
    }
}
