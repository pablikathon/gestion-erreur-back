using Microsoft.EntityFrameworkCore;
using Persist.Entities;
using Persist.Entities.Auth;
using Persist.Entities.BaseTable;
using Persist.Entities.Catalyst;
using Persist.Entities.Catalyst.JoiningTable;
using Persist.Entities.JoiningTable;
using Persist.Entities.Application;

namespace Persist
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string connectionString = Environment.GetEnvironmentVariable("DefaultConnection") ??
                                          "Server=localhost;Port=8081;User=root;Password=;Database=testntier";
                optionsBuilder.UseMySql(
                    "Server=localhost;Port=3306;User=root;Password=;Database=testntier;Charset=utf8;",
                    ServerVersion.AutoDetect(
                        "Server=localhost;Port=3306;User=root;Password=;Database=testntier;Charset=utf8;"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MySqlDbContextOptionsBuilderExtensions).Assembly);

            base.OnModelCreating(modelBuilder);

        }

        public DbSet<ApplicationEntity> Application { get; set; }
        public DbSet<ServerEntity> Server { get; set; }
        public DbSet<CustomerEntity> Customer { get; set; }
        public DbSet<ApplicationDeployedOnServerEntity> ApplicationDeployedOnServer { get; set; }
        public DbSet<CustomerHaveLicenceToApplicationEntity> CustomerHaveLicenceToApplications { get; set; }
        public DbSet<ErrorStatusEntity> ErrorStatus { get; set; }
        public DbSet<SeverityLevelEntity> SeverityLevel { get; set; }
        public DbSet<ErrorEntity> Error { get; set; }
        public DbSet<HashPasswordEntity> HashPassword { get; set; }
        public DbSet<RefreshTokenEntity> RefreshToken { get; set; }
        public DbSet<UserEntity> User { get; set; }
        public DbSet<TagEntity> Tag { get; set; }

        public DbSet<TagCategoryEntity> TagCategories { get; set; }
        public DbSet<TagCategoryTagEntity> TagCategoriesTag { get; set; }
        public DbSet<FeatureEntity> Feature { get; set; }
        public DbSet<StepEntity> Step { get; set; }

    }
}