using System.ComponentModel;
using Ressources.Annotation.ValidationMessage;

namespace Ressources.Annotation.RestrictionLentgh;

public enum FieldRestrictionLentgh
{
    [Description(FieldRestrictionLentghMessage.FieldTooLongBy50)]
    FieldTooLongBy50 = 50,

    [Description(FieldRestrictionLentghMessage.FieldTooLongBy100)]
    FieldTooLongBy100 = 100,

    [Description(FieldRestrictionLentghMessage.FieldTooLongBy150)]
    FieldTooLongBy150 = 150,

    [Description(FieldRestrictionLentghMessage.FieldTooLongBy200)]
    FieldTooLongBy200 = 200,

    [Description(FieldRestrictionLentghMessage.FieldTooLongBy300)]
    FieldTooLongBy300 = 300,

    [Description(FieldRestrictionLentghMessage.FieldTooLongBy500)]
    FieldTooLongBy500 = 500,
}

public enum IdRestrictionLentgh
{
    [Description(IdentifierRestrictionLentghMessage.NicTooLongBy5)]
    NicTooLongBy5 = 5,

    [Description(IdentifierRestrictionLentghMessage.SiretTooLongBy14)]
    SiretTooLongBy14 = 14,

    [Description(IdentifierRestrictionLentghMessage.IdentifierTooLongBy36)]
    IdentifierTooLongBy36 = 36
}

public enum UserRestrictionMessageEnum
{
    [Description(ValidationMessagesPassword.PasswordTooShortBy12)]
    PasswordTooShortBy12 = 12,
    [Description(ValidationMessagesUserField.EmailShouldBeLongerOrEqualThan5)]
    EmailMinimalLengh = 5,
    [Description(ValidationMessagesUserField.EmailShouldBeShorterOrEqualThan50)]
    EmailMaxLengh = 50,
}