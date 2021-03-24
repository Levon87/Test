using Domain;
using Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EFData
{
    public class DataContext : IdentityDbContext<AppUser>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Office> Offices { get; set; }
        public DbSet<OfficeUsers> OfficeUsers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<OfficeUsers>()
                .HasKey(bc => new { bc.UserId, bc.OfficeId });
            modelBuilder.Entity<OfficeUsers>()
                .HasOne(bc => bc.User)
                .WithMany(b => b.OfficeUsers)
                .HasForeignKey(bc => bc.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<OfficeUsers>()
                .HasOne(bc => bc.Office)
                .WithMany(c => c.OfficeUsers)
                .HasForeignKey(bc => bc.OfficeId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}