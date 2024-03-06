using Di2P2Eval.Models;
using Microsoft.EntityFrameworkCore;

namespace Di2P2Eval.DbContext;

public class AppDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Event>? Events { get; set; }
}
