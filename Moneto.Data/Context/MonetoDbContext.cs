using Microsoft.EntityFrameworkCore;
using Moneto.Domain.Entities;

namespace Moneto.Data.Context;

public partial class MonetoDbContext : DbContext {
    public MonetoDbContext()
    {
    }

    public MonetoDbContext(DbContextOptions<MonetoDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(MonetoDbContext).Assembly);
        OnModelCreatingPartial(modelBuilder);

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

}