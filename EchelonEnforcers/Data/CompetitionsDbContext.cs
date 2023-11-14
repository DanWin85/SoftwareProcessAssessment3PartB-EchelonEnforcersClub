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

        public DbSet<Competitions> Competitions { get; set; } = default!;

        public DbSet<EchelonEnforcers.Models.Competitions> Competitions { get; set; } = default!;
    }
}
