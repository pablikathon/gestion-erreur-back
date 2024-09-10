using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Persist.Entities
{
    [PrimaryKey(nameof(Id))]
    public class RefreshTokenEntity : DateEntity
    {
        [Required] public required string Id { get; set; }
        [Required] public required string RefreshToken { get; set; }
        public bool OldToken { get; set; } = false;
        
    }
}