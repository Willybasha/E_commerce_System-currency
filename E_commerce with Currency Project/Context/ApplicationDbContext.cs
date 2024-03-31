using System.Collections.Generic;
using System.Reflection.Emit;
using E_commerce_System_currency.ConfiguringModels;
using E_commerce_System_currency.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace E_commerce_System_currency.Context
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> option) : base(option)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Order>().HasMany(o => o.Items).WithMany(p => p.Orders).UsingEntity<Order_details>(
                j => j.HasOne(op => op.Item).WithMany(p => p.Order_details).HasForeignKey(op => op.ItemId),
                j => j.HasOne(op => op.Order).WithMany(o => o.Order_details).HasForeignKey(op => op.OrderId),
                j => j.HasKey(op => new { op.ItemId, op.OrderId }));

            modelBuilder.ApplyConfiguration(new ItemsConfigure());
            modelBuilder.ApplyConfiguration(new UOMConfigure());
        }


        public DbSet<Order> Orders { get; set; }
        public DbSet<Item> Items { get; set; }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<UOMeasure> UOMeasures { get; set; }


    }
}