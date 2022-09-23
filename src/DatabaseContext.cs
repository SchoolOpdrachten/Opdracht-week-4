
using Microsoft.EntityFrameworkCore;

public class DatabaseContext : DbContext
{
    public DbSet<Gebruiker> Gebruikers { get; set; }
    public DbSet<Medewerker> Medewerkers { get; set; }
    public DbSet<Gast> Gasten { get; set; }
    public DbSet<Onderhoud> Onderhouds { get; set; }
    public DbSet<Reservering> Reserveringen { get; set; }
    public DbSet<Attractie> Attracties { get; set; }
    public DbSet<Onderhoud> Onderhoud { get; internal set; }

    protected override void OnConfiguring(DbContextOptionsBuilder b)
    {
        b.UseSqlite("Data Source=database.db");
    }

    protected override void OnModelCreating(ModelBuilder b)
    {
        // b.Entity<Gast>().HasData(
        //     new Gast("mike@hhs.nl") { Credits = 100, GeboorteDatum = DateTime.Now, EersteBezoek = DateTime.Now },
        //     new Gast("gast@hhs.nl") { Credits = 100, GeboorteDatum = DateTime.Now, EersteBezoek = DateTime.Now },
        //     new Gast("gast2@hhs.nl") { Credits = 100, GeboorteDatum = DateTime.Now, EersteBezoek = DateTime.Now }
        // );
        // b.Entity<Medewerker>().HasData(
        //     new Medewerker("medewerker@hhs.nl") { Id = 1 },
        //     new Medewerker("medewerker2@hhs.nl") { Id = 2 },
        //     new Medewerker("medewerker3@hhs.nl") { Id = 3 }
        // );
    }

    public async Task<bool> Boek(Gast gast, Attractie attractie, DateTimeBereik datum)
    {
        if (gast == null || attractie == null|| datum == null) return false;

        var reservering = new Reservering
        {
            Gast = gast,
            Attractie = attractie,
            Tijd = datum
        };

        gast.Reserveringen.Add(reservering);
        Reserveringen.Add(reservering);
        await SaveChangesAsync();

        return true;
    }
}