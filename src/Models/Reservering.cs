using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
public class Reservering
{
    public int Id { get; set; }
    public DateTimeBereik Tijd { get; set; }
}