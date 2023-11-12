using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EchelonEnforcers.Models;

namespace EchelonEnforcers.Data
{
    public class NewsDbContext : DbContext
    {
        public NewsDbContext (DbContextOptions<NewsDbContext> options)
            : base(options)
        {
        }

        public DbSet<EchelonEnforcers.Models.NewsModel> NewsModel { get; set; } = default!;
    }
}
