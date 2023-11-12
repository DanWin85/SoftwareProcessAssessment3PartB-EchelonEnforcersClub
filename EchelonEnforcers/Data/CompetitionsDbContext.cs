using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public DbSet<EchelonEnforcers.Models.Competitions> Competitions { get; set; } = default!;
    }
}
