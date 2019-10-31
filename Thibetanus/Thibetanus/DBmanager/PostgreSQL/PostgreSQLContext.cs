using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thibetanus.DBModels.PostgreSQL;

namespace Thibetanus.DBmanager.PostgreSQL
{
    class PostgreSQLContext : DbContext
    {
         protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Host=localhost;Database=test;Username=postgres;Password=2622365;KeepAlive=300");

        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Skill> Skill { get; set; }
        public DbSet<Staff> Staff { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Salon> Salons { get; set; }
        public DbSet<Servcie> Services { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Location>()
                  .HasIndex(m => m.Code)
                  .IsUnique();
            modelBuilder.Entity<Manager>()
                 .HasIndex(m => m.Code)
                 .IsUnique();
            modelBuilder.Entity<Salon>()
                .HasIndex(m => m.Code)
                .IsUnique();
            modelBuilder.Entity<Servcie>()
                .HasIndex(m => m.Code)
                .IsUnique();
        }
    }
}