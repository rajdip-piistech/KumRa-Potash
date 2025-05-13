using Microsoft.EntityFrameworkCore;
using ShareExperience.Models;

namespace ShareExperience.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Story> Stories { get; set; }
    public DbSet<Comment> Comments { get; set; }
}