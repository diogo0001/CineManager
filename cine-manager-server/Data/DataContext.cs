using CineManager.Models;
using Microsoft.EntityFrameworkCore;

namespace CineManager.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Users> Users { get; set; }
        public DbSet<Rooms> Rooms { get; set; }
        public DbSet<Movies> Movies { get; set; }
        public DbSet<Sessions> Sessions { get; set; }
    }
}
