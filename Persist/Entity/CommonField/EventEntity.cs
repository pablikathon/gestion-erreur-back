using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Persist.Entities.BaseTable;
using Persist.Entity.CommonField;

namespace Persist.Entity.Basetable;

public abstract class EventEntity : DateEntity
{
    public required string Id { get; set; }
    public string? Description { get; set; }
    [Required] public required string ServerId { get; set; }
    [ForeignKey(nameof(ServerId))] public required ServerEntity Server { get; set; }
    [Required] public required string ApplicationId { get; set; }
    [ForeignKey(nameof(ApplicationId))] public required ApplicationEntity Application { get; set; }
}