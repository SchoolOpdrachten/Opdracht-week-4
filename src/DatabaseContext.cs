
using Microsoft.EntityFrameworkCore;

public class DatabaseContext : DbContext
{
    public DbSet<Gebruiker> Gebruikers { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder b)
    {
        b.UseSqlite("Data Source=database.db");
    }

    protected override void OnModelCreating(ModelBuilder b)
    {
    }
}