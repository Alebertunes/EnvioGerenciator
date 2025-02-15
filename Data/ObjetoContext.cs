using Microsoft.EntityFrameworkCore;
using EnviGerenciator.Model;

namespace EnviGerenciator.Data;
public class ObjetoContext : DbContext
{

    public ObjetoContext(DbContextOptions<ObjetoContext> options) : base(options)
    {
        
    }

    public DbSet<Filial> filiais {get; set;}
    public DbSet<Objeto> objetos {get; set;}
}