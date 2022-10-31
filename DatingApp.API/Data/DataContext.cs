using Microsoft.EntityFrameworkCore;
using DatingApp.API.Data.Entities;

namespace DatingApp.API.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }

    public DbSet<User> AppUsers { get; set; }
}