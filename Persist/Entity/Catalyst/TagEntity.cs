using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persist.Entities.Catalyst.JoiningTable;
using Persist.Entity.CommonField;

namespace Persist.Entities.Catalyst
{
    [PrimaryKey(nameof(Id))]
    [Index(nameof(Title), IsUnique = true)]

    public class TagEntity : DateEntity
    {
        [Required] public required string Id { get; set; }
        [Required] public required string Title { get; set; }
        public ICollection<TagCategoryTagEntity> TagCategoryTags { get; set; } = new List<TagCategoryTagEntity>();

    }


    public class TagEntityConfiguration : IEntityTypeConfiguration<TagEntity>
    {
        public void Configure(EntityTypeBuilder<TagEntity> builder)
        {
            builder.HasKey(t => t.Id);
            builder.HasIndex(t => t.Title).IsUnique();
            builder.HasMany(t => t.TagCategoryTags)
                   .WithOne(tc => tc.TagEntity)
                   .HasForeignKey(tc => tc.TagEntityId);
        }
    }
}