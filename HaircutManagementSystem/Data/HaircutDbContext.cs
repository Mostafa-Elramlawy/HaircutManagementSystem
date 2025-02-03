using Microsoft.EntityFrameworkCore;
using HaircutManagementSystem.Models; // Namespace for your models

namespace HaircutManagementSystem.Data
{
    public class HaircutDbContext : DbContext
    {
        public HaircutDbContext(DbContextOptions<HaircutDbContext> options)
            : base(options)
        {
        }

        // DbSet properties for your entities
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Barber> Barbers { get; set; }
        public DbSet<Service> Services { get; set; }

        // Optional: Customize the EF Core behavior using Fluent API
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Example: Customize table names or relationships
            modelBuilder.Entity<Customer>().ToTable("Customers");
            modelBuilder.Entity<Appointment>().ToTable("Appointments");
            modelBuilder.Entity<Barber>().ToTable("Barbers");
            modelBuilder.Entity<Service>().ToTable("Services");

            // Example: Define relationships
            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Barber) // Appointment has one Barber
                .WithMany(b => b.Appointments) // Barber can have many Appointments
                .HasForeignKey(a => a.BarberId);

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Customer) // Appointment has one Customer
                .WithMany(c => c.Appointments) // Customer can have many Appointments
                .HasForeignKey(a => a.CustomerId);
        }
    }
}

