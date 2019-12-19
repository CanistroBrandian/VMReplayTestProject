using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WMReplayTestProject.DAL.Entities;

namespace WMReplayTestProject.DAL.Context
{
    public class EFContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public DbSet<Article> Articles { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Category> Categories { get; set; }

        public EFContext(DbContextOptions<EFContext> options)
             : base(options)
        {
            Database.EnsureCreated();

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           base.OnModelCreating(modelBuilder);
            modelBuilder
                .Entity<Category>()
    .HasOne(e => e.Article)
    .WithOne(a => a.Category)
    .HasForeignKey<Article>(a => a.CategoryId);
        }

    }
}
