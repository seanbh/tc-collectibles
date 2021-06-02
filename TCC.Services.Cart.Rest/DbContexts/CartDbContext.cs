using Microsoft.EntityFrameworkCore;
using TCC.Services.Cart.Rest.Entities;

namespace TCC.Services.Cart.Rest.DbContexts
{
    public class CartDbContext : DbContext
    {
        public DbSet<Entities.Cart> Carts { get; set; }

        public DbSet<CartLine>  CartLines { get; set; }

        public DbSet<Product> Products { get; set; }

        public CartDbContext(DbContextOptions<CartDbContext> options) : base(options)
        {
        
        }
    }
}
