using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persist.Entities.BaseTable;
using Ressources.DefaultValue.Event;

namespace Persist.Entities
{
    public class SeverityLevelEntity
    {
        public required string Id { get; set; }
        public required string Title { get; set; }
        [JsonIgnore]
        public ICollection<ErrorEntity>? Errors { get; set; }
    }
    public class SeverityLevelConfiguration : IEntityTypeConfiguration<SeverityLevelEntity>
    {
        public void Configure(EntityTypeBuilder<SeverityLevelEntity> builder)
        {
            builder.HasData(
                    new SeverityLevelEntity { Id = SeverityLevelId.LowSeverety, Title = SeverityLevelTitle.LowSeverety },
                    new SeverityLevelEntity
                    { Id = SeverityLevelId.MediumSeverity, Title = SeverityLevelTitle.MediumSeverity },
                    new SeverityLevelEntity { Id = SeverityLevelId.HighSeverity, Title = SeverityLevelTitle.HighSeverity },
                    new SeverityLevelEntity
                    { Id = SeverityLevelId.CriticalSeverity, Title = SeverityLevelTitle.CriticalSeverity }
            );
        }
    }

}

