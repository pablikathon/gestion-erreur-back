using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace Persist.Entities
{
    [PrimaryKey(nameof(Id))]
    public class ApplicationEntity : DateEntity
    {
        [Required]
        public required string Id { get; set; }
        [Required]

        public required string Title { get; set; }
        public bool Internal { get; set; } = false;
        public string? Description { get; set; }
        [JsonIgnore]
        public ICollection<ApplicationDeployedOnServerEntity> ApplicationDeployedOnServers { get; set; } = new List<ApplicationDeployedOnServerEntity>();
        [JsonIgnore]

        public ICollection<CustomerHaveLicenceToApplicationEntity> CustomerHaveLicenceToApplication { get; set; } = new List<CustomerHaveLicenceToApplicationEntity>();

    }
}
