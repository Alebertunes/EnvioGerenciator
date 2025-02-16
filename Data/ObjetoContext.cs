using Microsoft.EntityFrameworkCore;
using EnviGerenciator.Model;

namespace EnviGerenciator.Data;
public class ObjetoContext : DbContext
{

    public ObjetoContext(DbContextOptions<ObjetoContext> options) : base(options)
    {

    }

    public DbSet<Filial> filiais { get; set; }
    public DbSet<Objeto> objetos { get; set; }
    public DbSet<Remessa> remessas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Remessa>()
            .HasMany(r => r.Objetos)
            .WithOne(o => o.Remessa)
            .HasForeignKey(o => o.RemessaId);

        modelBuilder.Entity<Filial>().
            HasMany(f => f.Remessas).
            WithOne(r => r.Filial).
            HasForeignKey(r => r.FilialId);
    }
}