using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

public class Onderhoud
{
    public int Id { get; set; }
    public List<Medewerker> Doet { get; set; }
    public List<Medewerker> Coordinaat { get; set; }
    public string Probleem { get; set; }
}