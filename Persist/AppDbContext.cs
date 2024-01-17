using Microsoft.EntityFrameworkCore;
using Persist.Entities;
using Pomelo.EntityFrameworkCore.MySql.Internal;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace Persist
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
               string connectionString = Environment.GetEnvironmentVariable("DefaultConnection") ?? "Server=localhost;Port=8081;User=root;Password=;Database=Projet";
               optionsBuilder.UseMySql(connectionString,ServerVersion.AutoDetect(connectionString));   
            }
        }
        public DbSet<Book> Books { get; set; }
    }
}
