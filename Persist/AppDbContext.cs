using Microsoft.EntityFrameworkCore;
using Persist.Entities;
using Ressources.DefaultValue.Event;


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
            base.OnModelCreating(modelBuilder);

            // Configuring the relationship between Error and ErrorStatus
            modelBuilder.Entity<ErrorEntity>()
                .HasOne(e => e.Status)
                .WithMany(es => es.Errors)
                .HasForeignKey(e => e.StatusId)
                .IsRequired();
            modelBuilder.Entity<ErrorEntity>()
                .HasOne(e => e.Severity)
                .WithMany(es => es.Errors)
                .HasForeignKey(e => e.SeverityId)
                .IsRequired();
            ;
            modelBuilder.Entity<SeverityLevelEntity>().HasData(
                new SeverityLevelEntity { Id = SeverityLevelId.LowSeverety, Title = SeverityLevelTitle.LowSeverety },
                new SeverityLevelEntity
                    { Id = SeverityLevelId.MediumSeverity, Title = SeverityLevelTitle.MediumSeverity },
                new SeverityLevelEntity { Id = SeverityLevelId.HighSeverity, Title = SeverityLevelTitle.HighSeverity },
                new SeverityLevelEntity
                    { Id = SeverityLevelId.CriticalSeverity, Title = SeverityLevelTitle.CriticalSeverity }
            );
            modelBuilder.Entity<ErrorStatusEntity>().HasData(
                new ErrorStatusEntity
                    { Id = ErrorStatusConstantId.UnresolvedStatus, Title = ErrorStatusConstantTitle.UnresolvedStatus },
                new ErrorStatusEntity
                    { Id = ErrorStatusConstantId.InProgressStatus, Title = ErrorStatusConstantTitle.InProgressStatus },
                new ErrorStatusEntity
                    { Id = ErrorStatusConstantId.ResolvedStatus, Title = ErrorStatusConstantTitle.ResolvedStatus }
            );
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
        public DbSet<RefreshTokenEntity> RefreshToken{ get; set; }
        public DbSet<UserEntity> User{ get; set; }
        
    }
}