using EFCore_ExecuteDelete.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFCore_ExecuteDelete.Data;

public class AppDbContext : DbContext
{
    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Animal> Animais { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
         "Data Source=Desktop-dk57unp\\SQLEXPRESS;Initial Catalog=APetsDB;Integrated Security=True;TrustServerCertificate=True;")
         .LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //shadow property
        modelBuilder.Entity<Animal>()
            .Property<int>("ClienteId");
    }
}
