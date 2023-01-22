using Microsoft.EntityFrameworkCore;

namespace Aflevering1.MVC.Models
{
    public class ItemDbContext : DbContext
    {
        public ItemDbContext(DbContextOptions<ItemDbContext> options) : base(options) { }
        public DbSet<Item> Items { get; set; }
        public DbSet<Placement> Placements { get; set; }
        public DbSet<Unit> Units { get; set; }
    }
}
