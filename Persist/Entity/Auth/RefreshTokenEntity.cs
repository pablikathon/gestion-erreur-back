using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Persist.Entity.CommonField;

namespace Persist.Entities.Auth
{
    [PrimaryKey(nameof(Id))]
    public class RefreshTokenEntity : DateEntity
    {
        [Required] public required string Id { get; set; }
        [Required] public required string RefreshToken { get; set; }
        public bool OldToken { get; set; } = false;
        
    }
}