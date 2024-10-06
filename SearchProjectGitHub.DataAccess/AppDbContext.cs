using Microsoft.EntityFrameworkCore;
using SearchProjectGitHub.DataAccess.Models;

namespace SearchProjectGitHub.DataAccess;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<SearchResult> SearchResults { get; set; } = null!;
}
