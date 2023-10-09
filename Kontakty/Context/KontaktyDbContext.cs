using Microsoft.EntityFrameworkCore;
namespace Kontakty.Models;

public class KontaktyDbContext : DbContext
{
    public KontaktyDbContext(DbContextOptions<KontaktyDbContext> options) : base(options) { }
    public DbSet<Kontakt> Kontakts {  get; set; } 
    public DbSet<Kategoria> Kategorias { get; set; }
    public DbSet<Podkategoria>Podkategorias { get; set; }
    public DbSet<Użytkownik> Użytkowniks { get; set; }
}
