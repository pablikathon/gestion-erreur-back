using System.ComponentModel.DataAnnotations;
using Ressources.Annotation.RestrictionLentgh;
using Ressources.Annotation.ValidationMessage;

namespace Services.Models.Req
{
    public class CreateCustomerRequest
    {
        [Required(ErrorMessage = ValidationMessagesGeneric.TitleRequired)]
        [StringLength((int)FieldRestrictionLentgh.FieldTooLongBy100)]
        public required string Title { get; set; }

        [Required(ErrorMessage = ValidationMessagesCustommer.FiscalIdentificationRequired)]
        [StringLength((int)IdRestrictionLentgh.SiretTooLongBy14,
            ErrorMessage = IdentifierRestrictionLentghMessage.SiretTooLongBy14)]
        public required string FiscalIdentification { get; set; }

        [Required(ErrorMessage = ValidationMessagesCustommer.LastInteractionRequired)]
        public required DateTime LastInteraction { get; set; }
    }

    public class UpdateCustomerRequest
    {
        [Required]
        [StringLength((int)IdRestrictionLentgh.IdentifierTooLongBy36,
            ErrorMessage = IdentifierRestrictionLentghMessage.IdentifierTooLongBy36)]
        public required string Id { get; set; }

        [Required]
        [StringLength((int)FieldRestrictionLentgh.FieldTooLongBy100,
            ErrorMessage = FieldRestrictionLentghMessage.FieldTooLongBy100)]
        public required string Title { get; set; }

        [Required]
        [StringLength((int)IdRestrictionLentgh.SiretTooLongBy14,
            ErrorMessage = IdentifierRestrictionLentghMessage.SiretTooLongBy14)]
        public required string FiscalIdentification { get; set; }

        [Required(ErrorMessage = ValidationMessagesCustommer.LastInteractionRequired)]
        public required DateTime LastInteraction { get; set; }
    }

    public class UpdateCustomerRequest2
    {
        [Required]
        [StringLength((int)IdRestrictionLentgh.IdentifierTooLongBy36,
            ErrorMessage = IdentifierRestrictionLentghMessage.IdentifierTooLongBy36)]
        public required string Id { get; set; }

        [Required]
        [StringLength((int)FieldRestrictionLentgh.FieldTooLongBy100,
            ErrorMessage = FieldRestrictionLentghMessage.FieldTooLongBy100)]
        public required string Title { get; set; }

        [Required]
        [StringLength((int)IdRestrictionLentgh.SiretTooLongBy14,
            ErrorMessage = IdentifierRestrictionLentghMessage.SiretTooLongBy14)]
        public required string FiscalIdentification { get; set; }

        [Required(ErrorMessage = ValidationMessagesCustommer.LastInteractionRequired)]
        public required DateTime LastInteraction { get; set; }
    }
}