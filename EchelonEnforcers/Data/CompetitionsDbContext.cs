using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EchelonEnforcers.Models;
<<<<<<< HEAD
=======
using EchelonEnforcers.Models.Domain;
>>>>>>> a22c04f05efee47888f5330dceafe892c783e142

namespace EchelonEnforcers.Data
{
    public class CompetitionsDbContext : DbContext
    {
        public CompetitionsDbContext (DbContextOptions<CompetitionsDbContext> options)
            : base(options)
        {
        }

        public DbSet<EchelonEnforcers.Models.Competitions> Competitions { get; set; } = default!;
<<<<<<< HEAD
=======

        public DbSet<Tag> Tags { get; set; }
>>>>>>> a22c04f05efee47888f5330dceafe892c783e142
    }
}
