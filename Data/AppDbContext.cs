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
            // Определяем папку, где лежит сам код проекта
            var projectPath = AppDomain.CurrentDomain.BaseDirectory;

            // Формируем жесткий путь к одному файлу базы данных
            var dbPath = Path.Combine(projectPath, "RuleConstructor.db");

            Console.WriteLine(dbPath);

            optionsBuilder.UseSqlite($"Data Source={dbPath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Profile>().HasMany(p => p.RequiredDocuments).WithMany();
            modelBuilder.Entity<Guide>().HasMany(g => g.Organizations).WithMany();

            base.OnModelCreating(modelBuilder);
        }
    }
}
