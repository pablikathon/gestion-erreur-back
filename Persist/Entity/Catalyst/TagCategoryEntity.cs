using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persist.Entities.Catalyst.JoiningTable;
using Persist.Entity.CommonField;

namespace Persist.Entities.Catalyst
{
    [PrimaryKey(nameof(Id))]
    [Index(nameof(Title), IsUnique = true)]

    public class TagCategoryEntity : DateEntity
    {
        [Required] public required string Id { get; set; }
        [Required] public required string Title { get; set; }
        [Required] public string Language { get; set; } = "English";

        public ICollection<TagCategoryTagEntity> TagCategoryTags { get; set; } = new List<TagCategoryTagEntity>();

    }
    public class TagCategoryEntityConfiguration : IEntityTypeConfiguration<TagCategoryEntity>
    {
        public void Configure(EntityTypeBuilder<TagCategoryEntity> builder)
        {
            builder.HasKey(tc => tc.Id);
            builder.HasIndex(tc => tc.Title).IsUnique();
            builder.HasMany(tc => tc.TagCategoryTags)
                   .WithOne(tc => tc.TagCategoryEntity)
                   .HasForeignKey(tc => tc.TagCategoryEntityId);
        }
    }

}