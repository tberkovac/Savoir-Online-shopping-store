using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SavoirApp.Models;
using Microsoft.EntityFrameworkCore;


namespace SavoirApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Item> Items { get; set; }
        public DbSet<ItemSizes> ItemSizes { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItems> OrderItems { get; set; }
        public DbSet<RegisteredUser> RegisteredUsers { get; set; }
        public DbSet<RegisteredUserOrders> RegisteredUserOrders { get; set; }
        public DbSet<VIPUser> VIPUsers { get; set; }
        public DbSet<VIPUserOrders> VIPUserOrders { get; set; }
        public DbSet<Wishlist> Wishlists { get; set; }
        public DbSet<Deliverer> Deliverers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>().ToTable("Items");
            modelBuilder.Entity<ItemSizes>().ToTable("ItemSizes");
            modelBuilder.Entity<Order>().ToTable("Orders");
            modelBuilder.Entity<OrderItems>().ToTable("OrderItems");
            modelBuilder.Entity<RegisteredUser>().ToTable("RegisteredUsers");
            modelBuilder.Entity<RegisteredUserOrders>().ToTable("RegisteredUserOrders");
            modelBuilder.Entity<VIPUser>().ToTable("VIPUsers");
            modelBuilder.Entity<VIPUserOrders>().ToTable("VIPUserOrders");
            modelBuilder.Entity<Wishlist>().ToTable("Wishlists");
            modelBuilder.Entity<Deliverer>().ToTable("Deliverers");

            base.OnModelCreating(modelBuilder);
        }
    }
}
