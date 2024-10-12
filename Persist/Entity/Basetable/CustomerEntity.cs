using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Persist.Entities.Application;
using Persist.Entity.CommonField;

namespace Persist.Entities.BaseTable
{
    [PrimaryKey(nameof(Id))]
    [Index(nameof(Title), IsUnique = true)]

    public class CustomerEntity : DateEntity
    {
        [Required] public required string Id { get; set; }
        public required string Title { get; set; }

        public required string FiscalIdentification { get; set; }
        public bool IsActive { get; set; } = false;
        public DateTime? FirstInteraction { get; set; }

        public DateTime LastInteraction { get; set; }
        public ICollection<FeatureEntity> CustomerHaveAccessToAFeature { get; set; } = new List<FeatureEntity>();
        [JsonIgnore]
        public ICollection<CustomerHaveLicenceToApplicationEntity> CustomerHaveLicenceToApplication { get; set; } =
            new List<CustomerHaveLicenceToApplicationEntity>();
    }
}