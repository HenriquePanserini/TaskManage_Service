using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManageH.Dominio.Entidades;

namespace TaskManageH.Infraestrutura.Mapas
{
    internal class MapaUsuario : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            // Nomear a tabela se necessário
            builder.ToTable("Usuarios");

            // Mapeamento das propriedades
            builder.Property(u => u.Idade)
                   .HasColumnName("Idade_Usuario")
                   .GetType();

            builder.Property(u => u.Celular)
                   .HasColumnName("Celular_Usuario")
                   .HasMaxLength(15)
                   .GetType();


            builder.Property(u => u.Tipo)
                   .HasColumnName("Tipo_Usuario")
                   .GetType();

            
        }
    }
}
