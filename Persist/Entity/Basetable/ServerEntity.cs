using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Persist.Entities.JoiningTable;
using Persist.Entity.CommonField;

namespace Persist.Entities.BaseTable
{
    [PrimaryKey(nameof(Id))]
    [Index(nameof(Title), IsUnique = true)]
    public class ServerEntity : DateEntity
    {
        [Required] public required string Id { get; set; }

        public required string Title { get; set; }

        //On va assumer pour l'instant que c'est un coûts en euros et par mois
        public double? Cost { get; set; }
        public bool IsActive { get; set; } = false;
        public DateTime? HostedSince { get; set; }
        public DateTime? StopHost { get; set; }
        public DateTime? HasToMakeSupportSince { get; set; }
        public string? CustomerWhoOwnServerId { get; set; }

        [ForeignKey(nameof(CustomerWhoOwnServerId))]
        public CustomerEntity? Customer { get; set; }

        [JsonIgnore]
        public ICollection<ApplicationDeployedOnServerEntity> ApplicationDeployedOnServers { get; set; } =
            new List<ApplicationDeployedOnServerEntity>();
    }
}