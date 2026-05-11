using System.ComponentModel.DataAnnotations;

using Ressources.Annotation.RestrictionLentgh;
using Ressources.Annotation.ValidationMessage;

namespace Services.Models.Command
{
    public class CreateCustomerCommand
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

    public class UpdateCustomerCommand
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


    public class CreateCustomerHasLicenceToCommand
    {
        [Required(ErrorMessage = ValidationMessagesGeneric.IdRequired)]
        [StringLength((int)IdRestrictionLentgh.IdentifierTooLongBy36,
            ErrorMessage = IdentifierRestrictionLentghMessage.IdentifierTooLongBy36)]
        public required string ApplicationId { get; set; }

        [Required(ErrorMessage = ValidationMessagesGeneric.IdRequired)]
        [StringLength((int)IdRestrictionLentgh.IdentifierTooLongBy36,
            ErrorMessage = IdentifierRestrictionLentghMessage.IdentifierTooLongBy36)]
        public required string CustomerId { get; set; }

        public DateTime? BeginingSupport { get; set; }
        public DateTime? EndingSupport { get; set; }
        public double cost { get; set; } = 0;

        public bool IsActive { get; set; } = false;
    }

    public class UpdateCustomerHasLicenceCommand
    {
        [Required(ErrorMessage = ValidationMessagesGeneric.IdRequired)]
        [StringLength((int)IdRestrictionLentgh.IdentifierTooLongBy36,
            ErrorMessage = IdentifierRestrictionLentghMessage.IdentifierTooLongBy36)]
        public required string ApplicationId { get; set; }

        [Required(ErrorMessage = ValidationMessagesGeneric.IdRequired)]
        [StringLength((int)IdRestrictionLentgh.IdentifierTooLongBy36,
            ErrorMessage = IdentifierRestrictionLentghMessage.IdentifierTooLongBy36)]
        public required string CustomerId { get; set; }

        public DateTime? BeginingSupport { get; set; }
        public DateTime? EndingSupport { get; set; }
        public double cost { get; set; } = 0;

        public bool IsActive { get; set; } = false;
    }

    public class DeleteCustomerHasLicenceCommand
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
