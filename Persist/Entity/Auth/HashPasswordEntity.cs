using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Persist.Entity.CommonField;

namespace Persist.Entities.Auth
{
    [PrimaryKey(nameof(Id))]
    public class HashPasswordEntity : DateEntity
    {
        [Required] public required string Id { get; set; }
        [Required] public required string Password { get; set; }
        public bool IsForgotten { get; set; } = false;
        
    }
}