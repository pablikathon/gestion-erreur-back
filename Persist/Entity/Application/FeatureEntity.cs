using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persist.Entities.BaseTable;
using Persist.Entity.CommonField;

namespace Persist.Entities.Application
{
    [PrimaryKey(nameof(Id))]
    public class FeatureEntity : DateEntity
    {
        [Required] public required string Id { get; set; }
        [Required] public required string Title { get; set; }
        public bool IsPrenium { get; set; } = false;
        public ICollection<StepEntity> Steps { get; set; } = new List<StepEntity>();
        public ICollection<CustomerEntity> CustomersWhoCanUseFeature { get; set; } = new HashSet<CustomerEntity>();
        public bool EverybodyCouldUseIt { get; set; } = true;

    }
    public class FeatureEntityConfiguration : IEntityTypeConfiguration<FeatureEntity>
    {
        public void Configure(EntityTypeBuilder<FeatureEntity> builder)
        {
            builder.HasKey(ft => ft.Id);
            builder.HasIndex(ft => ft.Title).IsUnique();

            builder.HasMany(ft => ft.Steps)
            .WithOne(s => s.Feature)
            .HasForeignKey(s => s.FeatureId)
            .OnDelete(DeleteBehavior.Cascade);
            
            builder.HasMany(ft => ft.CustomersWhoCanUseFeature)
            .WithMany(c => c.CustomerHaveAccessToAFeature);
        }
    }
}