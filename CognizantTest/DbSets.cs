using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using CognizantTest.DataEntities;

namespace CognizantTest
{
    public class DbSets : DbContext
    {
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Model> Models { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder contextOptionsBuilder)
        {
            contextOptionsBuilder.UseSqlServer("Server=MSI\\SQLEXPRESS;DataBase = CognizantTest; User ID=sa;Password=sa;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Warehouse>().HasIndex(u => u.OuterId).IsUnique();
            modelBuilder.Entity<Warehouse>().HasIndex(u => u.Name).IsUnique();
            modelBuilder.Entity<Vehicle>().HasIndex(u => u.OuterId).IsUnique();
            modelBuilder.Entity<Brand>().HasIndex(u => u.Name).IsUnique();
            modelBuilder.Entity<Model>().HasIndex(u => u.Name).IsUnique();
        }
    }
}
