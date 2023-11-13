using Microsoft.EntityFrameworkCore;


namespace EchelonEnforcers.Data
{
    public class NewsDbContext : DbContext
    {
        public NewsDbContext (DbContextOptions<NewsDbContext> options)
            : base(options)
        {
        }

        public DbSet<EchelonEnforcers.Models.NewsModel> NewsModel { get; set; } = default!;

        public DbSet<EchelonEnforcers.Models.NewsModel> News { get; set; } = default!;

       
    }
}
