using Microsoft.EntityFrameworkCore;
using Polaris.Api.Models;

namespace Polaris.Api.DataLayer;

public class PolarisDbContext : DbContext
{
    public PolarisDbContext(DbContextOptions<PolarisDbContext> options) : base(options)
    {
    }


    public DbSet<Exercise> Exercises { get; set; }
    public DbSet<ExerciseType> ExerciseTypes { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Points> Points { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Exercise>()
            .HasOne(e => e.ExerciseType)
            .WithMany()
            .HasForeignKey(e => e.ExerciseTypeId);

        modelBuilder.Entity<Points>()
            .HasKey(p => new { p.ExerciseId, p.UserId });

        modelBuilder.Entity<Points>()
            .HasOne(p => p.Exercise)
            .WithMany(e => e.Points)
            .HasForeignKey(p => p.ExerciseId);

        modelBuilder.Entity<Points>()
            .HasOne(p => p.User)
            .WithMany(u => u.Points)
            .HasForeignKey(p => p.UserId);
    }
}