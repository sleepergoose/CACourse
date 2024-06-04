using Microsoft.EntityFrameworkCore;
using PackIt.Domain.Entities;

namespace PackIt.Infrastructure.EF.Contexts;

internal sealed class WriteDbContext : DbContext
{
    public DbSet<PackingList> PackingLists { get; set; }

    public WriteDbContext(DbContextOptions<ReadDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("packing");
        base.OnModelCreating(modelBuilder);
    }
}
