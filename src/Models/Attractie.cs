using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

public class Attractie
{
    public Attractie(string naam)
    {
        Naam = naam;
    }
    
    [NotMapped] public readonly SemaphoreSlim Semaphore = new SemaphoreSlim(1, 1);

    [Key]
    public int Id { get; set; }
    public string Naam { get; set; }

    public async Task<bool> OnderhoudBezig(DatabaseContext d)
    {
        return true;
    }
    public async Task<bool> Vrij(DatabaseContext database, DateTimeBereik tijd)
    {
        return true;
    }
}