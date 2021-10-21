using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options) {  }

        public DbSet<Basket> Baskets { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<BasketItem> BasketItens { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<BasketItem>(b => b.HasKey(aa => new { aa.BasketId, aa.ProductId }));

            builder.Entity<BasketItem>()
                .HasOne(b => b.Basket)
                .WithMany(p => p.Products)
                .HasForeignKey(fk => fk.BasketId);

            builder.Entity<BasketItem>()
                .HasOne(p => p.Product)
                .WithMany(b => b.Baskets)
                .HasForeignKey(fk => fk.ProductId);
        }
    }
}
