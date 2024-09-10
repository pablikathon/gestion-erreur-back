using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace Persist.Entities
{
    [PrimaryKey(nameof(Id))]
    public class HashPasswordEntity : DateEntity
    {
        [Required] public required string Id { get; set; }
        [Required] public required string Password { get; set; }
        public bool IsForgotten { get; set; } = false;

    }
}