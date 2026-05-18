using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

using Ressources.Annotation.RestrictionLentgh;
using Ressources.Annotation.ValidationMessage;

namespace Services.Models.Auth;

public class GrantTypeRequest
{
    public required string GrantType { get; set; }

    [JsonConverter(typeof(GrantConnectionConverter))]
    public required IGrantConnection GrantDetails { get; set; }

}
public abstract class IGrantConnection
{
    [Required(ErrorMessage = ValidationMessagesUserField.EmailIsRequired)]
    [StringLength((int)UserRestrictionMessageEnum.EmailMaxLengh, MinimumLength = (int)UserRestrictionMessageEnum.EmailMinimalLengh, ErrorMessage = ValidationMessagesUserField.EmailLengthShouldBeBetween5And50)]
    [DataType(DataType.EmailAddress)]
    public required string Email { get; set; }
    public abstract bool Validate();
}

public class UserSignInWithPasswordRequest : IGrantConnection
{
    [Required(ErrorMessage = ValidationMessagesPassword.PasswordRequired)]
    [StringLength(int.MaxValue, MinimumLength = (int)UserRestrictionMessageEnum.PasswordTooShortBy12, ErrorMessage = ValidationMessagesPassword.PasswordTooShortBy12)]
    [DataType(DataType.Password)]
    public required string Password { get; set; }
    public override bool Validate()
    {
        return !string.IsNullOrWhiteSpace(Password);
    }
}
public class UserSignInWithRefreshTokenRequest : IGrantConnection
{
    public required string RefreshToken { get; set; }
    public override bool Validate()
    {
        return !string.IsNullOrWhiteSpace(RefreshToken);
    }
}

