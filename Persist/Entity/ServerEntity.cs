using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace Persist.Entities
{
    [PrimaryKey(nameof(Id))]
    public class ServerEntity
    {
        [Required]
        public required string Id { get; set; }
        public required string Title { get; set; }
        //On va assumer pour l'instant que c'est un coûts en euros et par mois
        public double? Cost { get; set; }
        public bool IsActive { get; set; } = false;
        public DateTime? HostedSince { get; set; }
        public DateTime? StopHost { get; set; }
        public DateTime? HasToMakeSupportSince { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        [JsonIgnore]
        public ICollection<ApplicationDeployedOnServerEntity> ApplicationDeployedOnServers { get; set; } = new List<ApplicationDeployedOnServerEntity>();

    }
}
