using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

public class Gast : Gebruiker
{
    public new int Id { get; set; }
    public int Credits { get; set; }
    public DateTime GeboorteDatum { get; set; }
    public DateTime EersteBezoek { get; set; }

    public Gast? Begeleid { get; set; }
    public List<Reservering>? Reserveringen { get; set; }
    public Attractie? HeeftFavorieteAttractie { get; set; }

    public Gast(string email) : base(email) {}  
    
}