using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Ressources.DefaultValue.Event;
namespace Persist.Entities
{
    public class ErrorEntity : EventEntity
    {
        public required string SeverityId { get; set; }  // Clé étrangère vers SeverityLevel
        [ForeignKey(nameof(SeverityId))]
        public required SeverityLevelEntity Severity { get; set; } // doit être renseigné
        public string StatusId { get; set; } = ErrorStatusConstantId.InProgressStatus;
        [ForeignKey(nameof(StatusId))]
        public required ErrorStatusEntity Status { get; set; }
        public DateTime? InterventionDate { get; set; }

    }
}