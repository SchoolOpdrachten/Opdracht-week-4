using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

public class Gebruiker
{
    public int Id { get; set; }    
    public string Email { get; set; }

    public Gebruiker(string email)
    {
        Email = email;
    }
}