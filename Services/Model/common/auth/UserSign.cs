using System.ComponentModel.DataAnnotations;
using Ressources.Annotation.RestrictionLentgh;
using Ressources.Annotation.ValidationMessage;

namespace Services.Models.Auth;

public class UserSignUp
{
    [Required(ErrorMessage = ValidationMessagesUserField.NameIsRequired)]
    public required string FirstName { get; set; }
    [Required(ErrorMessage = ValidationMessagesUserField.LastNameIsRequired)]
    public required string LastName { get; set; }
    [Required(ErrorMessage = ValidationMessagesUserField.EmailIsRequired)]
    [StringLength((int)UserRestrictionMessageEnum.EmailMaxLengh, MinimumLength = (int)UserRestrictionMessageEnum.EmailMinimalLengh, ErrorMessage = ValidationMessagesUserField.EmailLengthShouldBeBetween5And50)]
    [DataType(DataType.EmailAddress)]
    public required string Email { get; set; }
    [Required(ErrorMessage = ValidationMessagesPassword.PasswordRequired)]
    [StringLength(int.MaxValue, MinimumLength = (int)UserRestrictionMessageEnum.PasswordTooShortBy12, ErrorMessage = ValidationMessagesPassword.PasswordTooShortBy12)]
    [DataType(DataType.Password)]
    public required string Password { get; set; }
}

