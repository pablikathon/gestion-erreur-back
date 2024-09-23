using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Persist.Entities.BaseTable;
using Persist.Entity.CommonField;

namespace Persist.Entities.JoiningTable
{
    [PrimaryKey(nameof(ServerId), nameof(ApplicationId))]
    public class ApplicationDeployedOnServerEntity : DateEntity
    {
        [Required] public required string ServerId { get; set; }

        [ForeignKey(nameof(ServerId))] public required ServerEntity Server { get; set; }

        [Required] public required string ApplicationId { get; set; }

        [ForeignKey(nameof(ApplicationId))] public required ApplicationEntity Application { get; set; }
        public string? CustomerId { get; set; }

        [ForeignKey(nameof(CustomerId))] public CustomerEntity? Customer { get; set; }

        public required string ApplicationPath { get; set; }
        public bool IsActive { get; set; } = false;
    }
}