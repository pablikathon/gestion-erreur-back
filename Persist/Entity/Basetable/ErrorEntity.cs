using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persist.Entity.Basetable;
using Ressources.DefaultValue.Event;

namespace Persist.Entities.BaseTable
{
    public class ErrorEntity : EventEntity
    {
        public required string SeverityId { get; set; } // Clé étrangère vers SeverityLevel

        [ForeignKey(nameof(SeverityId))]
        public required SeverityLevelEntity Severity { get; set; } // doit être renseigné

        public string StatusId { get; set; } = ErrorStatusConstantId.InProgressStatus;
        [ForeignKey(nameof(StatusId))] public required ErrorStatusEntity Status { get; set; }
        public DateTime? InterventionDate { get; set; }
    }
    public class TagCategoryTagConfiguration : IEntityTypeConfiguration<ErrorEntity>
    {

        public void Configure(EntityTypeBuilder<ErrorEntity> builder)
        {
            builder
                .HasOne(e => e.Status)
                .WithMany(es => es.Errors)
                .HasForeignKey(e => e.StatusId)
                .IsRequired();
            builder
                .HasOne(e => e.Severity)
                .WithMany(es => es.Errors)
                .HasForeignKey(e => e.SeverityId)
                .IsRequired();        
        }
    }
}
