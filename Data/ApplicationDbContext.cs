using Microsoft.EntityFrameworkCore;
using Software_Modelling_Technologies.Models;

namespace Software_Modelling_Technologies.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Project> Projects => Set<Project>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Project>(entity =>
        {
            entity.Property(project => project.Title).HasMaxLength(150).IsRequired();
            entity.Property(project => project.Author).HasMaxLength(100).IsRequired();
            entity.Property(project => project.Description).HasMaxLength(2000).IsRequired();
            entity.Property(project => project.TechnologyStack).HasMaxLength(300).IsRequired();
            entity.Property(project => project.Status).HasMaxLength(50).IsRequired();
            entity.Property(project => project.RepositoryUrl).HasMaxLength(500);
        });
    }
}
