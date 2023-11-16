using Microsoft.EntityFrameworkCore;
using EchelonEnforcers.Models;

namespace EchelonEnforcers.Data
{
    public class CompetitionsDbContext : DbContext
    {
        public CompetitionsDbContext (DbContextOptions<CompetitionsDbContext> options)
            : base(options)
        {
        }

        public DbSet<CompetitionsModel> CompetitionsModel { get; set; } = default!;
    }
}
