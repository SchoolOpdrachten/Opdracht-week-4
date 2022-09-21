using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

public class Medewerker : Gebruiker
{
    public int Id { get; set; }
    public Medewerker(string email) : base(email) {}

    public List<Medewerker> Doet { get; set; }
    public List<Medewerker> Coordinaat { get; set; }
}