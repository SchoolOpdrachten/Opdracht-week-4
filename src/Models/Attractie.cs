using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

public class Attractie
{
    public Attractie(string naam)
    {
        Naam = naam;
    }

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