using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Persist.Entity.CommonField;

namespace Persist.Entities.Auth
{
    [PrimaryKey(nameof(Id))]
    [Index(nameof(Email), IsUnique=true)]
    public class UserEntity : DateEntity
    {

        [Required] public required string Id { get; set; }
        [Required] public required string FirstName { get; set; }
        [Required] public required string LastName { get; set; }
        [Required] public required string Email { get; set; }
        public bool IsEmailConfirmed { get; set; } = false;
        public string? RefreshTokenId { get; set; }
        [ForeignKey(nameof(RefreshTokenId))] public RefreshTokenEntity? RefreshToken { get; set; }
        [Required] public required string HashPasswordId { get; set; }
        [ForeignKey(nameof(HashPasswordId))] [Required] public required HashPasswordEntity HashPasswordEntity { get; set; }
        public ICollection<RefreshTokenEntity> OldRefreshTokens { get; set; } = new Collection<RefreshTokenEntity>();
        public ICollection<HashPasswordEntity> OldppHashPasswords { get; set; } = new Collection<HashPasswordEntity>();


    }
}