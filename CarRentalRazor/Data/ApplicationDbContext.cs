using CarRentalRazor.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRentalRazor.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options) { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<Reservation>()
            .HasOne(r => r.Customer)
            .WithMany(c => c.Reservations)
            .HasForeignKey(r => r.CustomerId);

        modelBuilder.Entity<Reservation>()
            .HasOne(r => r.Car)
            .WithMany(c => c.Reservations)
            .HasForeignKey(r => r.CarId);
        }
    }
}
