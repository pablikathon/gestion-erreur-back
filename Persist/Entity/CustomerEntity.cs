using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace Persist.Entities
{
    [PrimaryKey(nameof(Id))]
    public class CustomerEntity
    {
        [Required]
        public required string Id { get; set; }
        public required string Title { get; set; }

        public required string FiscalIdentification { get; set; }
        public bool IsActive { get; set; } = false;

        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? FirstInteraction { get; set; }

        public DateTime LastInteraction { get; set; }
        [JsonIgnore]

        public ICollection<CustomerHaveLicenceToApplicationEntity> CustomerHaveLicenceToApplication { get; set; } = new List<CustomerHaveLicenceToApplicationEntity>();


    }
}
