
using Microsoft.EntityFrameworkCore;

public class DatabaseContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder b)
    {
        b.UseSqlite("Data Source=database.db");
    }

    protected override void OnModelCreating(ModelBuilder b)
    {
    }
}