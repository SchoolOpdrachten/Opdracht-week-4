
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

    public async Task<bool> Boek(Gast gast, Attractie attractie, DateTimeBereik datum)
    {
        if (gast == null || attractie == null || datum == null) return false;

        await attractie.Semaphore.WaitAsync();
        using var transaction = Database.BeginTransaction();
        try
        {
            if (!await attractie.Vrij(this, datum)) return false;

            var reservering = new Reservering
            {
                Gast = gast,
                Attractie = attractie,
                Tijd = datum
            };
            gast.Credits--;

            gast.Reserveringen.Add(reservering);
            Reserveringen.Add(reservering);
            await SaveChangesAsync();
            transaction.Commit();

        }
        finally { attractie.Semaphore.Release(); }
        return true;
    }
}