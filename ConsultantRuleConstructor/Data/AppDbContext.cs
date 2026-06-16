using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using ConsultantRuleConstructor.Entities;

namespace ConsultantRuleConstructor.Data
{
    internal class AppDbContext : DbContext
    {
        public DbSet<Rule> Rules => Set<Rule>();
        public DbSet<Document> Documents => Set<Document>();
        public DbSet<Guide> Guides => Set<Guide>();
        public DbSet<Organization> Organizations => Set<Organization>();
        public DbSet<Profile> Profiles => Set<Profile>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=RuleConstructor.db");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Guide>()
                .HasMany(d => d.Organizations);
        }
    }
}
