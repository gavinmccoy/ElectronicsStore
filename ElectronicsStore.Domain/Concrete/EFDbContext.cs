using ElectronicsStore.Domain.Entities;
using System.Data.Entity;

namespace ElectronicsStore.Domain.Concrete
{
    // context class for associating the model with the database
    public class EFDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
    }
}