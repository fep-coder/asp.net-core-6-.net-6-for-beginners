using Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Core.Infrastructure
{
        public class DataContext : DbContext
        {
                public DataContext(DbContextOptions<DataContext> options) : base(options) { }

                public DbSet<Product> Products { get; set; }
                public DbSet<Category> Categories { get; set; }
                public DbSet<Core.Models.User> User { get; set; }
        }
}
