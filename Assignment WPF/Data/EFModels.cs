using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_WPF.Data
{
    class EFModels
    {
        public class AppContext : DbContext
        {
            public DbSet<Category> Category { get; set; }
            public DbSet<Item> Item { get; set; }
            public DbSet<CartItems> CartItems { get; set; }
            public DbSet<Cart> Cart { get; set; }
            public DbSet<Booking> Booking { get; set; }
            public DbSet<User> User { get; set; }
            public DbSet<Payment> Payment { get; set; }
            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<Item>()
                    .HasOne(i => i.Category)
                    .WithMany(c => c.Items);

                modelBuilder.Entity<Cart>()
                    .HasMany(c => c.CartList)
                    .WithOne(l => l.Cart);

                modelBuilder.Entity<Booking>()
                    .HasOne(u => u.User)
                    .WithMany(b => b.BookingDetails);

                modelBuilder.Entity<Booking>()
                    .HasOne(i => i.Item)
                    .WithMany(b => b.BookingDetails);

                modelBuilder.Entity<Payment>()
                    .HasKey(p => new { p.PaymentId, p.UserId });


                modelBuilder.Entity<Payment>()
                    .HasOne(p => p.Booking)
                    .WithOne(b => b.Payment);

            }
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlServer(@"Server=DIT-NB1626401\SQLEXPRESS;Database=EF.CA2Assignemnt.NewDb;Trusted_Connection=True;");
            }
        }
    }
}
