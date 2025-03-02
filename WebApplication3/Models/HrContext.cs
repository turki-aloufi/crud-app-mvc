using System;
using Microsoft.EntityFrameworkCore;

namespace WebApplication3.Models
{
    public class HrContext : DbContext
    {
        public HrContext() { }
        public HrContext(DbContextOptions<HrContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured) {
                optionsBuilder.UseSqlServer("Server=TURKI\\SQLEXPRESS;Database=EmployeesDatabase;  Integrated Security=True; TrustServerCertificate=True;");
            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd(); 

                entity.Property(e => e.Name).HasMaxLength(100);
                entity.Property(e => e.Position).HasMaxLength(50);
            });
        }
    }
}
