using Microsoft.EntityFrameworkCore;

namespace RestaurantAPI.Models
{
    public class RestaurantDbContext:DbContext
    {
        public RestaurantDbContext(DbContextOptions<RestaurantDbContext> options) : base(options)
        {


        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure cascading delete
            modelBuilder.Entity<OrderMasters>()
                .HasMany(o => o.OrderDetails)
                .WithOne()
                .HasForeignKey(od => od.OrderMasterId)
                .OnDelete(DeleteBehavior.Cascade);
        }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<FoodItems> FoodItems { get; set; }
        public DbSet<OrderMasters> OrderMasters { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
    }
}
