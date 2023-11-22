
using Microsoft.EntityFrameworkCore;
using EchelonEnforcers.Models;


namespace EchelonEnforcers.Data
{
    public class NewsDbContext : DbContext
    {
        public NewsDbContext (DbContextOptions<NewsDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<NewsModel> NewsModel { get; set; } = default!;
    }
}
