using Microsoft.EntityFrameworkCore;

namespace ProductoAPI.Models
{
    public class ProductoContext : DbContext
    {
        public ProductoContext(DbContextOptions<ProductoContext> options) : base(options){ }

        public DbSet<Producto> Productos { get; set; }
    }
}
