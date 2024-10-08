using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persist.Entities.BaseTable;
using Ressources.DefaultValue.Event;

namespace Persist.Entities
{
    public class ErrorStatusEntity
    {
        public required string Id { get; set; }
        public required string Title { get; set; }
        [JsonIgnore]
        public ICollection<ErrorEntity>? Errors { get; set; }
    }
    public class ErrorStatusConfiguration : IEntityTypeConfiguration<SeverityLevelEntity>
    {
        public void Configure(EntityTypeBuilder<SeverityLevelEntity> builder)
        {
            builder.HasData(
                new ErrorStatusEntity
                { Id = ErrorStatusConstantId.UnresolvedStatus, Title = ErrorStatusConstantTitle.UnresolvedStatus },
                new ErrorStatusEntity
                { Id = ErrorStatusConstantId.InProgressStatus, Title = ErrorStatusConstantTitle.InProgressStatus },
                new ErrorStatusEntity
                { Id = ErrorStatusConstantId.ResolvedStatus, Title = ErrorStatusConstantTitle.ResolvedStatus }
            );
        }
    }
}