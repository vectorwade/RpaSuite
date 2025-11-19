using Microsoft.EntityFrameworkCore;
using Project.Domain.Entities;
using System.Collections.Generic;
using System.Reflection.Emit;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    public DbSet<Processo> Processos => Set<Processo>();

    protected override void OnModelCreating(ModelBuilder b)
    {
        b.Entity<Processo>(e =>
        {
            e.ToTable("Processos");
            e.HasKey(x => x.Id);
            e.Property(x => x.Numero).HasMaxLength(50).IsRequired();
            e.Property(x => x.Status).HasMaxLength(20).IsRequired();
        });
    }
}
