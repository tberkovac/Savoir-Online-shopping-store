
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SavoirApp.Models;


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
        public DbSet<RegisteredUserOrders> RegisteredUserOrders { get; set; }
        public DbSet<User> VIPUsers { get; set; }
        public DbSet<VIPUserOrders> VIPUserOrders { get; set; }
        public DbSet<Wishlist> Wishlists { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>().ToTable("Items");
            modelBuilder.Entity<ItemSizes>().ToTable("ItemSizes");
            modelBuilder.Entity<Order>().ToTable("Orders");
            modelBuilder.Entity<OrderItems>().ToTable("OrderItems");
            modelBuilder.Entity<RegisteredUserOrders>().ToTable("RegisteredUserOrders");
            modelBuilder.Entity<User>().ToTable("VIPUsers");
            modelBuilder.Entity<VIPUserOrders>().ToTable("VIPUserOrders");
            modelBuilder.Entity<Wishlist>().ToTable("Wishlists");

            base.OnModelCreating(modelBuilder);
        }
    }
}
