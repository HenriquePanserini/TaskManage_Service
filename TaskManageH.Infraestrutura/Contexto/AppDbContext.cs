using KaskataDDD.Infrastructure.Data.Mappings;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TaskManageH.Dominio.Entidades;
using TaskManageH.Infraestrutura.Mapas;

public class AppDbContext : IdentityDbContext<Usuario>
{
    public AppDbContext(DbContextOptions<AppDbContext> opcoes) : base(opcoes)
    {
    }

    public DbSet<Tarefas> Tarefas { get; set; }
    public DbSet<Usuario> Usuario { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(ObterStringConexao());
            base.OnConfiguring(optionsBuilder);
        }
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Aplicar o mapeamento da classe separada
        modelBuilder.ApplyConfiguration(new MapaUsuario());
        // Aplicando o mapeamento da entidade Tarefa
        modelBuilder.ApplyConfiguration(new TarefaMap());
    }

    public string ObterStringConexao()
    {
        string strcon = "Data Source=DESKTOP-JDDJMQ9\\SQLEXPRESS;Initial Catalog=TaskManage_2024;Trusted_Connection=True";
        return strcon;
    }
}