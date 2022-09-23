using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

public class Medewerker : Gebruiker
{
    public new int Id { get; set; }
    public Medewerker(string email) : base(email) { }

    [NotMapped] public List<Onderhoud> Doet { get; set; }
    [NotMapped] public List<Onderhoud> Coordineert { get; set; }
}