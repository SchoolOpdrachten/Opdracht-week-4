using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

public class Medewerker : Gebruiker
{
    public new int Id { get; set; }
    public Medewerker(string email) : base(email) {}

    public List<Onderhoud> Doet { get; set; }
    public List<Onderhoud> Coordinaat { get; set; }
}