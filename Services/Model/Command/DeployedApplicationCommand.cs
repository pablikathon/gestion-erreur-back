using System.ComponentModel.DataAnnotations;

using Ressources.Annotation.RestrictionLentgh;
using Ressources.Annotation.ValidationMessage;

namespace Services.Models.Command
{
    public class CreateApplicationDeployedCommand
    {
        [Required(ErrorMessage = ValidationMessagesGeneric.IdRequired)]
        [StringLength((int)IdRestrictionLentgh.IdentifierTooLongBy36,
            ErrorMessage = IdentifierRestrictionLentghMessage.IdentifierTooLongBy36)]
        public required string ApplicationId { get; set; }

        [Required(ErrorMessage = ValidationMessagesGeneric.IdRequired)]
        [StringLength((int)IdRestrictionLentgh.IdentifierTooLongBy36,
            ErrorMessage = IdentifierRestrictionLentghMessage.IdentifierTooLongBy36)]
        public required string ServerId { get; set; }

        [StringLength((int)IdRestrictionLentgh.IdentifierTooLongBy36,
            ErrorMessage = IdentifierRestrictionLentghMessage.IdentifierTooLongBy36)]
        public string? CustomerId { get; set; }

        [Required(ErrorMessage = ValidationMessageDeployedApplication.ApplicationPath)]
        [StringLength((int)FieldRestrictionLentgh.FieldTooLongBy500,
            ErrorMessage = FieldRestrictionLentghMessage.FieldTooLongBy500)]
        public required string ApplicationPath { get; set; }

        public bool IsActive { get; set; } = false;
    }

    public class UpdateApplicationDeployedCommand
    {
        [Required(ErrorMessage = ValidationMessagesGeneric.IdRequired)]
        [StringLength((int)IdRestrictionLentgh.IdentifierTooLongBy36,
            ErrorMessage = IdentifierRestrictionLentghMessage.IdentifierTooLongBy36)]
        public required string ApplicationId { get; set; }

        [Required(ErrorMessage = ValidationMessagesGeneric.IdRequired)]
        [StringLength((int)IdRestrictionLentgh.IdentifierTooLongBy36,
            ErrorMessage = IdentifierRestrictionLentghMessage.IdentifierTooLongBy36)]
        public required string ServerId { get; set; }

        [StringLength((int)IdRestrictionLentgh.IdentifierTooLongBy36,
            ErrorMessage = IdentifierRestrictionLentghMessage.IdentifierTooLongBy36)]
        public string? CustomerId { get; set; }

        [Required(ErrorMessage = ValidationMessageDeployedApplication.ApplicationPath)]
        [StringLength((int)FieldRestrictionLentgh.FieldTooLongBy500,
            ErrorMessage = FieldRestrictionLentghMessage.FieldTooLongBy500)]
        public required string ApplicationPath { get; set; }

        public bool IsActive { get; set; } = false;
    }

    public class DeleteApplicationDeployedCommand
    {
        [Required(ErrorMessage = ValidationMessagesGeneric.IdRequired)]
        [StringLength((int)IdRestrictionLentgh.IdentifierTooLongBy36,
            ErrorMessage = IdentifierRestrictionLentghMessage.IdentifierTooLongBy36)]
        public required string ApplicationId { get; set; }

        [Required(ErrorMessage = ValidationMessagesGeneric.IdRequired)]
        [StringLength((int)IdRestrictionLentgh.IdentifierTooLongBy36,
            ErrorMessage = IdentifierRestrictionLentghMessage.IdentifierTooLongBy36)]
        public required string ServerId { get; set; }
    }
}



