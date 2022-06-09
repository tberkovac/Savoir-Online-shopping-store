
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SavoirApp.Models;

/*
 * 21ed42bf-1684-4757-9ba6-abf1f1de37b1 admin2 
 * 30f6c9b9-58b1-4b5a-9838-dabd14ca7412 vip2
 * df83680c-476b-4e5a-b4e5-b5267fe54385 user2
 */
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
        public DbSet<DelivererOrders> DelivererOrders { get; set; }
        public DbSet<Wishlist> Wishlists { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>().ToTable("Items");
            modelBuilder.Entity<ItemSizes>().ToTable("ItemSizes");
            modelBuilder.Entity<Order>().ToTable("Orders");
            modelBuilder.Entity<OrderItems>().ToTable("OrderItems");
            modelBuilder.Entity<DelivererOrders>().ToTable("DelivererOrders");
            modelBuilder.Entity<Wishlist>().ToTable("Wishlists");

            base.OnModelCreating(modelBuilder);
        }
    }
}
