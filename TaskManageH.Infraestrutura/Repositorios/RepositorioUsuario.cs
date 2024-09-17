using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManageH.Dominio.Entidades;
using TaskManageH.Dominio.Enum;
using TaskManageH.Dominio.Interfaces;
using TaskManageH.Infraestrutura.Repositorios.Base;

namespace TaskManageH.Infraestrutura.Repositorios
{
    public class RepositorioUsuario : RepositorioBase<Usuario>, IRepositorioUsuario
    {
        private readonly DbContextOptions<AppDbContext> _optionsbuilder;

        public RepositorioUsuario()
        {
            _optionsbuilder = new DbContextOptions<AppDbContext>();
        }

        public async Task<bool> AdicionaUsuario(string email, string senha, int idade, string celular)
        {

            try
            {
                using (var data = new AppDbContext(_optionsbuilder))
                {
                    await data.Usuario.AddAsync(
                          new Usuario
                          {
                              Email = email,
                              PasswordHash = senha,
                              Idade = idade,
                              Celular = celular,
                              Tipo = TipoUsuario.Colaborador
                          });

                    await data.SaveChangesAsync();

                }
            }
            catch (Exception)
            {
                return false;
            }


            return true;

        }

        public async Task<bool> ExisteUsuario(string email, string senha)
        {
            try
            {
                using (var data = new AppDbContext(_optionsbuilder))
                {
                    return await data.Usuario.
                          Where(u => u.Email.Equals(email) && u.PasswordHash.Equals(senha))
                          .AsNoTracking()
                          .AnyAsync();

                }
            }
            catch (Exception)
            {
                return false;
            }


        }

        public Task<bool> RetornaIdUsuario(string email)
        {
            throw new NotImplementedException();
        }
    }
}
