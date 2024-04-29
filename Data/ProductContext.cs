using BasketballStore.Models;
using Microsoft.EntityFrameworkCore;

namespace BasketballStore.Data
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        {

        }

        public DbSet<BasketballStore.Models.Product> Products { get; set; } = default!;
        public DbSet<BasketballStore.Models.Cart> Carts { get; set; } = default!;
        public DbSet<BasketballStore.Models.CartItem> CartItems { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(new
                Product
            {
                ProductId = 1,
                Name = "Lakers Jersey",
                Price = 75.00,
                Description = "Los Angeles Lakers Home Jersery 24",
                ImageUrl = "No Image available",
            },
            new Product
            {
                ProductId = 2,
                Name = "Lakers Jersey",
                Price = 75.00,
                Description = "Los Angeles Lakers Away Jersery 24",
                ImageUrl = "No Image available",
            },
            new Product
            {
                ProductId = 3,
                Name = "Clippers Jersey",
                Price = 75.00,
                Description = "Los Angeles Clippers Home Jersery 24",
                ImageUrl = "No Image available",
            },
            new Product
            {
                ProductId = 4,
                Name = "Clippers Jersey",
                Price = 75.00,
                Description = "Los Angeles Clippers Away Jersery 24",
                ImageUrl = "No Image available",
            },
            new Product
            {
                ProductId = 5,
                Name = "Lakers Cap",
                Price = 30.00,
                Description = "Los Angeles Lakers Cap 24",
                ImageUrl = "No Image available",
            },
            new Product
            {
                ProductId = 6,
                Name = "Clippers Cap",
                Price = 30.00,
                Description = "Los Angeles Clippers Cap 24",
                ImageUrl = "No Image available",
            }
                );
        }

    }
}
