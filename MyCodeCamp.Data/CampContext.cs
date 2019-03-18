using Microsoft.EntityFrameworkCore;
using MyCodeCamp.Data.Entities;
using System;

namespace MyCodeCamp.Data
{
    public class CampContext : DbContext
    {

        public CampContext(DbContextOptions<CampContext> options) : base(options)
        {

        }

        public DbSet<Camp> Camps { get; set; }

        public DbSet<Speaker> Speakers { get; set; }

        public DbSet<Talk> Talks { get; set; }

        public DbSet<CampUser> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Camp>()
              .Property(c => c.Moniker)
              .IsRequired();

            builder.Entity<Camp>()
              .Property(c => c.RowVersion)
              .ValueGeneratedOnAddOrUpdate()
              .IsConcurrencyToken();

            builder.Entity<Speaker>()
              .Property(c => c.RowVersion)
              .ValueGeneratedOnAddOrUpdate()
              .IsConcurrencyToken();

            builder.Entity<Talk>()
              .Property(c => c.RowVersion)
              .ValueGeneratedOnAddOrUpdate()
              .IsConcurrencyToken();
        }
    }
}
