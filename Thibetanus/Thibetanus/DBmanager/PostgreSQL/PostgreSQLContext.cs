﻿using System;
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
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<StaffOrder> StaffOrders { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Salon> Salons { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<SalonService> SalonServices { get; set; }
        public DbSet<Assets> Assets { get; set; }
        public DbSet<Custom> Customs { get; set; }
        public DbSet<ServiceGroup> ServiceGroups { get; set; }
        public DbSet<StaffServiceTime> StaffServiceTimes { get; set; }
        public DbSet<StaffBookTime> StaffBookTimes { get; set; }

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
            modelBuilder.Entity<ServiceGroup>()
                .HasIndex(m => new { m.Code, m.ShowIndex })
                .IsUnique();
            modelBuilder.Entity<Service>()
                .HasIndex(m => m.Code)
                .IsUnique();
            modelBuilder.Entity<Staff>()
               .HasIndex(m => m.Code)
               .IsUnique();
            modelBuilder.Entity<StaffServiceTime>()
                 .HasIndex(m => m.Code)
                 .IsUnique();
        }
    }
}