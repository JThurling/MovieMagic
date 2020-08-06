using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options) : base(options)
        {
        }

        public DbSet<Movies> Movies { get; set; }
        public DbSet<Users> Users { get; set; }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderedItems> OrderItems { get; set; }
    }
}
