using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Persist.Entities.JoiningTable;
using Persist.Entity.CommonField;

namespace Persist.Entities.Application
{
    [PrimaryKey(nameof(Id))]
    [Index(nameof(Title), IsUnique = true)]

    public class ApplicationEntity : DateEntity
    {
        [Required] public required string Id { get; set; }
        [Required] public required string Title { get; set; }
        public bool Internal { get; set; } = false;
        public string? Description { get; set; }

        [JsonIgnore]
        public ICollection<ApplicationDeployedOnServerEntity> ApplicationDeployedOnServers { get; set; } =
            new List<ApplicationDeployedOnServerEntity>();

        [JsonIgnore]
        public ICollection<CustomerHaveLicenceToApplicationEntity> CustomerHaveLicenceToApplication { get; set; } =
            new List<CustomerHaveLicenceToApplicationEntity>();
        public ICollection<FeatureEntity> Features { get; set; } = new List<FeatureEntity>();
    }
    
}
