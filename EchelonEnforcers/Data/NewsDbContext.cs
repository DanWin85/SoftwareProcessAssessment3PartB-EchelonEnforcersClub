using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
<<<<<<< HEAD
using EchelonEnforcers.Models;
=======
using EchelonEnforcers.Models.Domain;
>>>>>>> a22c04f05efee47888f5330dceafe892c783e142

namespace EchelonEnforcers.Data
{
    public class NewsDbContext : DbContext
    {
        public NewsDbContext (DbContextOptions<NewsDbContext> options)
            : base(options)
        {
        }

<<<<<<< HEAD
        public DbSet<EchelonEnforcers.Models.NewsModel> NewsModel { get; set; } = default!;
=======
        public DbSet<EchelonEnforcers.Models.Domain.News> News { get; set; } = default!;

        public DbSet<Tag> Tags { get; set; }
>>>>>>> a22c04f05efee47888f5330dceafe892c783e142
    }
}
