using System.ComponentModel.DataAnnotations;
using Ressources.Annotation.RestrictionLentgh;
using Ressources.Annotation.ValidationMessage;

namespace Services.Models.Auth;

public abstract class GrantRequest
{
    public required string GrantType { get; set; }
}

public class UserSignInWithPassword : GrantRequest
{
    [Required(ErrorMessage = ValidationMessagesUserField.EmailIsRequired)]
    [StringLength((int)UserRestrictionMessageEnum.EmailMaxLengh, MinimumLength = (int)UserRestrictionMessageEnum.EmailMinimalLengh, ErrorMessage = ValidationMessagesUserField.EmailLengthShouldBeBetween5And50)]
    [DataType(DataType.EmailAddress)]
    public required string Email { get; set; }
    [Required(ErrorMessage = ValidationMessagesPassword.PasswordRequired)]
    [StringLength(int.MaxValue, MinimumLength = (int)UserRestrictionMessageEnum.PasswordTooShortBy12, ErrorMessage = ValidationMessagesPassword.PasswordTooShortBy12)]
    [DataType(DataType.Password)]
    public required string Password { get; set; }
    UserSignInWithPassword()
    {
        GrantType = "password";

    }
}
public class UserSignInWithRefreshToken : GrantRequest
{
    [Required(ErrorMessage = ValidationMessagesUserField.EmailIsRequired)]
    [StringLength((int)UserRestrictionMessageEnum.EmailMaxLengh, MinimumLength = (int)UserRestrictionMessageEnum.EmailMinimalLengh, ErrorMessage = ValidationMessagesUserField.EmailLengthShouldBeBetween5And50)]
    [DataType(DataType.EmailAddress)]
    public required string Email { get; set; }
    public required string RefreshToken { get; set; }

}

