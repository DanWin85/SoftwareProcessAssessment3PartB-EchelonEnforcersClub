using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EchelonEnforcers.Models.Domain;

namespace EchelonEnforcers.Data
{
    public class NewsDbContext : DbContext
    {
        public NewsDbContext (DbContextOptions<NewsDbContext> options)
            : base(options)
        {
        }

        public DbSet<EchelonEnforcers.Models.Domain.News> News { get; set; } = default!;

        public DbSet<Tag> Tags { get; set; }
    }
}
