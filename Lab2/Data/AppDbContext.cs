using Lab2.Data.Configurations;
using Lab2.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab2.Data;

public class AppDbContext : DbContext
{
    public DbSet<Faculty> Faculties { get; init; }
    public DbSet<Student> Students { get; init; }
    public DbSet<University> Universities { get; init; }
    public DbSet<Speciality> Specialities { get; init; }
    

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost; Database=lab2; Username=admin; Password=postgres; Include Error Detail=True");
        optionsBuilder.EnableSensitiveDataLogging();
        optionsBuilder.EnableDetailedErrors();
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UniversityConfiguration());
        modelBuilder.ApplyConfiguration(new FacultyConfiguration());
        modelBuilder.ApplyConfiguration(new SpecialityConfiguration());
    }
}