using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskManageH.Dominio.Entidades;

namespace KaskataDDD.Infrastructure.Data.Mappings
{
    public class TarefaMap : IEntityTypeConfiguration<Tarefas>
    {
        public void Configure(EntityTypeBuilder<Tarefas> builder)
        {
            // Nome da tabela
            builder.ToTable("Tarefas");

            // Chave primária
            builder.HasKey(t => t.Id);

            // Mapeamento das propriedades
            builder.Property(t => t.Id)
                .HasColumnName("Id")
                .IsRequired();

            builder.Property(t => t.Titulo)
                .HasColumnName("Titulo")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(t => t.Descricao)
                .HasColumnName("Descricao")
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(t => t.Prioridade)
                .IsRequired()
                .HasConversion<int>(); // Mapeando o enum para o banco como int

            builder.Property(t => t.Status)
                .HasColumnName("Status")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(t => t.DataCriacao)
                .HasColumnName("DataCriacao")
                .HasColumnType("datetime")
                .IsRequired();

            builder.Property(t => t.DataConclusao)
                .HasColumnName("DataConclusao")
                .HasColumnType("datetime");

            builder.Property(t => t.Prazo)
                .HasColumnName("Prazo")
                .HasColumnType("datetime")
                .IsRequired();

            // Mapeamento da chave estrangeira
            builder.Property(t => t.UsuarioId)
                .HasColumnName("UserId")
                .IsRequired();

            // Configurando o relacionamento com a entidade User
            builder.HasOne(t => t.Usuario)
                .WithMany()
                .HasForeignKey(t => t.UsuarioId)
                .OnDelete(DeleteBehavior.Restrict); // Define como será o comportamento de deleção
        }
    }
}
