using System.ComponentModel.DataAnnotations;
using Ressources.Annotation.RestrictionLentgh;
using Ressources.Annotation.ValidationMessage;

namespace Services.Models.Req
{
    public class CreateApplicationDeployedRequest
    {
        [Required(ErrorMessage = ValidationMessagesGeneric.IdRequired)]
        [StringLength((int)IdRestrictionLentgh.IdentifierTooLongBy36, ErrorMessage = IdentifierRestrictionLentghMessage.IdentifierTooLongBy36)]
        public required string ApplicationId { get; set; }
        [Required(ErrorMessage = ValidationMessagesGeneric.IdRequired)]
        [StringLength((int)IdRestrictionLentgh.IdentifierTooLongBy36, ErrorMessage = IdentifierRestrictionLentghMessage.IdentifierTooLongBy36)]
        public required string ServerId { get; set; }
        [StringLength((int)IdRestrictionLentgh.IdentifierTooLongBy36, ErrorMessage = IdentifierRestrictionLentghMessage.IdentifierTooLongBy36)]
        public string? CustomerId { get; set; }
        [Required(ErrorMessage = ValidationMessageDeployedApplication.ApplicationPath)]
        [StringLength((int)FieldRestrictionLentgh.FieldTooLongBy500, ErrorMessage = FieldRestrictionLentghMessage.FieldTooLongBy500)]
        public required string ApplicationPath { get; set; }
        public bool IsActive { get; set; } = false;

    }
    public class UpdateApplicationDeployedRequest
    {
        [Required(ErrorMessage = ValidationMessagesGeneric.IdRequired)]
        [StringLength((int)IdRestrictionLentgh.IdentifierTooLongBy36, ErrorMessage = IdentifierRestrictionLentghMessage.IdentifierTooLongBy36)]
        public required string ApplicationId { get; set; }
        [Required(ErrorMessage = ValidationMessagesGeneric.IdRequired)]
        [StringLength((int)IdRestrictionLentgh.IdentifierTooLongBy36, ErrorMessage = IdentifierRestrictionLentghMessage.IdentifierTooLongBy36)]
        public required string ServerId { get; set; }
        [StringLength((int)IdRestrictionLentgh.IdentifierTooLongBy36, ErrorMessage = IdentifierRestrictionLentghMessage.IdentifierTooLongBy36)]
        public string? CustomerId { get; set; }
        [Required(ErrorMessage = ValidationMessageDeployedApplication.ApplicationPath)]
        [StringLength((int)FieldRestrictionLentgh.FieldTooLongBy500, ErrorMessage = FieldRestrictionLentghMessage.FieldTooLongBy500)]
        public required string ApplicationPath { get; set; }
        public bool IsActive { get; set; } = false;

    }
    public class DeleteApplicationDeployedRequest
    {
        [Required(ErrorMessage = ValidationMessagesGeneric.IdRequired)]
        [StringLength((int)IdRestrictionLentgh.IdentifierTooLongBy36, ErrorMessage = IdentifierRestrictionLentghMessage.IdentifierTooLongBy36)]
        public required string ApplicationId { get; set; }
        [Required(ErrorMessage = ValidationMessagesGeneric.IdRequired)]
        [StringLength((int)IdRestrictionLentgh.IdentifierTooLongBy36, ErrorMessage = IdentifierRestrictionLentghMessage.IdentifierTooLongBy36)]
        public required string ServerId { get; set; }
    }
}