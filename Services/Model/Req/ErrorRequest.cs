using System.ComponentModel.DataAnnotations;
using Ressources.Annotation.RestrictionLentgh;
using Ressources.Annotation.ValidationMessage;
using Ressources.DefaultValue.Event;
namespace Services.Models.Req
{
    public class CreateErrorRequest
    {
        [Required(ErrorMessage = ValidationMessagesGeneric.DescriptionRequired)]
        [StringLength((int)FieldRestrictionLentgh.FieldTooLongBy500, ErrorMessage = FieldRestrictionLentghMessage.FieldTooLongBy500)]
        public required string Description { get; set; }
        public DateTime? InterventionDate { get; set; }
        [Required(ErrorMessage = ValidationMessagesGeneric.IdRequired)]
        [StringLength((int)IdRestrictionLentgh.IdentifierTooLongBy36, ErrorMessage = IdentifierRestrictionLentghMessage.IdentifierTooLongBy36)]
        public required string ServerId { get; set; }
        [Required(ErrorMessage = ValidationMessagesGeneric.DescriptionRequired)]
        [StringLength((int)FieldRestrictionLentgh.FieldTooLongBy500, ErrorMessage = IdentifierRestrictionLentghMessage.IdentifierTooLongBy36)]

        public required string ApplicationId { get; set; }
        [Required(ErrorMessage = ValidationMessagesGeneric.IdRequired)]
        [StringLength((int)FieldRestrictionLentgh.FieldTooLongBy500, ErrorMessage = IdentifierRestrictionLentghMessage.IdentifierTooLongBy36)]

        public required string SeverityId { get; set; }
        [Required(ErrorMessage = ValidationMessagesGeneric.IdRequired)]
        [StringLength((int)IdRestrictionLentgh.IdentifierTooLongBy36, ErrorMessage = IdentifierRestrictionLentghMessage.IdentifierTooLongBy36)]
        public string StatusId { get; set; } = ErrorStatusConstantId.UnresolvedStatus;
    }
    public class UpdateErroRequest
    {
        [Required(ErrorMessage = ValidationMessagesGeneric.IdRequired)]
        [StringLength((int)FieldRestrictionLentgh.FieldTooLongBy500, ErrorMessage = IdentifierRestrictionLentghMessage.IdentifierTooLongBy36)]
        public required string OldStatusId { get; set; }
        [Required(ErrorMessage = ValidationMessagesGeneric.IdRequired)]
        [StringLength((int)FieldRestrictionLentgh.FieldTooLongBy500, ErrorMessage = IdentifierRestrictionLentghMessage.IdentifierTooLongBy36)]
        public required string OldSeverityId { get; set; }
        [Required(ErrorMessage = ValidationMessagesGeneric.DescriptionRequired)]
        [StringLength((int)FieldRestrictionLentgh.FieldTooLongBy500, ErrorMessage = FieldRestrictionLentghMessage.FieldTooLongBy500)]
        public required string Description { get; set; }
        public DateTime? EventDate { get; set; }
        [Required(ErrorMessage = ValidationMessagesGeneric.IdRequired)]
        [StringLength((int)IdRestrictionLentgh.IdentifierTooLongBy36, ErrorMessage = IdentifierRestrictionLentghMessage.IdentifierTooLongBy36)]
        public required string ServerId { get; set; }
        [Required(ErrorMessage = ValidationMessagesGeneric.DescriptionRequired)]
        [StringLength((int)FieldRestrictionLentgh.FieldTooLongBy500, ErrorMessage = IdentifierRestrictionLentghMessage.IdentifierTooLongBy36)]

        public required string ApplicationId { get; set; }
        [Required(ErrorMessage = ValidationMessagesGeneric.IdRequired)]
        [StringLength((int)FieldRestrictionLentgh.FieldTooLongBy500, ErrorMessage = IdentifierRestrictionLentghMessage.IdentifierTooLongBy36)]

        public required string SeverityId { get; set; }
        [Required(ErrorMessage = ValidationMessagesGeneric.IdRequired)]
        [StringLength((int)FieldRestrictionLentgh.FieldTooLongBy500, ErrorMessage = IdentifierRestrictionLentghMessage.IdentifierTooLongBy36)]
        public required string StatusId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
