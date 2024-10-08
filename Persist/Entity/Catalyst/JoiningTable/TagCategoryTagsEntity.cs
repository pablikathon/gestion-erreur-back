using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persist.Entity.CommonField;

namespace Persist.Entities.Catalyst.JoiningTable
{
    [PrimaryKey(nameof(TagEntityId), nameof(TagCategoryEntityId))]
    public class TagCategoryTagEntity : DateEntity
    {
        public required string TagEntityId { get; set; }
        public required TagEntity TagEntity { get; set; }

        public required string TagCategoryEntityId { get; set; }
        public required TagCategoryEntity TagCategoryEntity { get; set; }

    }
    public class TagCategoryTagConfiguration : IEntityTypeConfiguration<TagCategoryTagEntity>
    {
        
        public void Configure(EntityTypeBuilder<TagCategoryTagEntity> builder)
        {
            builder.HasKey(tct => new { tct.TagEntityId, tct.TagCategoryEntityId });
        }
    }
}