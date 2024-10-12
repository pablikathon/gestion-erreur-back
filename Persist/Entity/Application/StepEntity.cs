using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persist.Entity.CommonField;

namespace Persist.Entities.Application
{
    [PrimaryKey(nameof(Id))]
    [Index(nameof(Title), IsUnique = true)]

    public class StepEntity : DateEntity
    {
        [Required] public required string Id { get; set; }
        [Required] public required string Title { get; set; }
        public bool NotObligatory { get; set; } = false;
        public required string FeatureId { get; set; }
        public FeatureEntity Feature { get; set; } = null!; 

        public string? PreviousStepId { get; set; }
        public StepEntity? PreviousStep { get; set; }
        public ICollection<StepEntity> NextSteps { get; set; } = new List<StepEntity>();

    }
    public class StepEntityConfiguration : IEntityTypeConfiguration<StepEntity>
    {
        public void Configure(EntityTypeBuilder<StepEntity> builder)
        {
            builder
                .HasOne(s => s.PreviousStep)
                .WithMany(s => s.NextSteps)
                .HasForeignKey(s => s.PreviousStepId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }

}