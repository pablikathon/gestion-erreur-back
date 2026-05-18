using System.ComponentModel.DataAnnotations;

using Persist.Entities;
using Persist.Entities.Application;
using Persist.Entities.BaseTable;

using Ressources.Annotation.RestrictionLentgh;
using Ressources.Annotation.ValidationMessage;
using Ressources.DefaultValue.Event;

namespace Services.Models.Command
{
    public class CreateErrorCommand
    {
        [Required(ErrorMessage = ValidationMessagesGeneric.DescriptionRequired)]
        [StringLength((int)FieldRestrictionLentgh.FieldTooLongBy500,
            ErrorMessage = FieldRestrictionLentghMessage.FieldTooLongBy500)]
        public required string Description { get; set; }

        public DateTime? InterventionDate { get; set; }

        [Required(ErrorMessage = ValidationMessagesGeneric.IdRequired)]
        [StringLength((int)IdRestrictionLentgh.IdentifierTooLongBy36,
            ErrorMessage = IdentifierRestrictionLentghMessage.IdentifierTooLongBy36)]
        public required string ServerId { get; set; }

        [Required(ErrorMessage = ValidationMessagesGeneric.DescriptionRequired)]
        [StringLength((int)FieldRestrictionLentgh.FieldTooLongBy500,
            ErrorMessage = IdentifierRestrictionLentghMessage.IdentifierTooLongBy36)]

        public required string ApplicationId { get; set; }

        [Required(ErrorMessage = ValidationMessagesGeneric.IdRequired)]
        [StringLength((int)FieldRestrictionLentgh.FieldTooLongBy500,
            ErrorMessage = IdentifierRestrictionLentghMessage.IdentifierTooLongBy36)]

        public required string SeverityId { get; set; }

        [Required(ErrorMessage = ValidationMessagesGeneric.IdRequired)]
        [StringLength((int)IdRestrictionLentgh.IdentifierTooLongBy36,
            ErrorMessage = IdentifierRestrictionLentghMessage.IdentifierTooLongBy36)]
        public string StatusId { get; set; } = ErrorStatusConstantId.UnresolvedStatus;
    }

    public class UpdateErroCommand
    {
        [Required(ErrorMessage = ValidationMessagesGeneric.IdRequired)]
        [StringLength((int)FieldRestrictionLentgh.FieldTooLongBy500,
            ErrorMessage = IdentifierRestrictionLentghMessage.IdentifierTooLongBy36)]
        public required string OldStatusId { get; set; }

        [Required(ErrorMessage = ValidationMessagesGeneric.IdRequired)]
        [StringLength((int)FieldRestrictionLentgh.FieldTooLongBy500,
            ErrorMessage = IdentifierRestrictionLentghMessage.IdentifierTooLongBy36)]
        public required string OldSeverityId { get; set; }
        public DateTime? EventDate { get; set; }

        [Required(ErrorMessage = ValidationMessagesGeneric.IdRequired)]
        [StringLength((int)IdRestrictionLentgh.IdentifierTooLongBy36,
            ErrorMessage = IdentifierRestrictionLentghMessage.IdentifierTooLongBy36)]
        public required string ServerId { get; set; }

        [Required(ErrorMessage = ValidationMessagesGeneric.DescriptionRequired)]
        [StringLength((int)FieldRestrictionLentgh.FieldTooLongBy500,
            ErrorMessage = IdentifierRestrictionLentghMessage.IdentifierTooLongBy36)]

        public required string ApplicationId { get; set; }

        [Required(ErrorMessage = ValidationMessagesGeneric.IdRequired)]
        [StringLength((int)FieldRestrictionLentgh.FieldTooLongBy500,
            ErrorMessage = IdentifierRestrictionLentghMessage.IdentifierTooLongBy36)]

        public required string SeverityId { get; set; }

        [Required(ErrorMessage = ValidationMessagesGeneric.IdRequired)]
        [StringLength((int)FieldRestrictionLentgh.FieldTooLongBy500,
            ErrorMessage = IdentifierRestrictionLentghMessage.IdentifierTooLongBy36)]
        public required string StatusId { get; set; }

        public DateTime CreatedAt { get; set; }
    }
    public class GetErrorCommand
    {
        [Required(ErrorMessage = ValidationMessagesGeneric.IdRequired)]
        [StringLength((int)IdRestrictionLentgh.IdentifierTooLongBy36,
            ErrorMessage = IdentifierRestrictionLentghMessage.IdentifierTooLongBy36)]
        public required string ServerId { get; set; }

        [Required(ErrorMessage = ValidationMessagesGeneric.DescriptionRequired)]
        [StringLength((int)FieldRestrictionLentgh.FieldTooLongBy500,
            ErrorMessage = IdentifierRestrictionLentghMessage.IdentifierTooLongBy36)]

        public required string ApplicationId { get; set; }

        [Required(ErrorMessage = ValidationMessagesGeneric.IdRequired)]
        [StringLength((int)FieldRestrictionLentgh.FieldTooLongBy500,
            ErrorMessage = IdentifierRestrictionLentghMessage.IdentifierTooLongBy36)]

        public required string SeverityId { get; set; }

        [Required(ErrorMessage = ValidationMessagesGeneric.IdRequired)]
        [StringLength((int)FieldRestrictionLentgh.FieldTooLongBy500,
            ErrorMessage = IdentifierRestrictionLentghMessage.IdentifierTooLongBy36)]
        public required string StatusId { get; set; }

        public DateTime CreatedAt { get; set; }
    }
    public class ErrorForCustommerStatsResponseCommand
    {
        public required string custommerId { get; set; }
        public required string CustommerTitle { get; set; }
        public required string CustomerFiscalIdentification { get; set; }
        public required int nberrorSolved { get; set; }
        public required int nbErrorUnresolved { get; set; }
    }
    public class ErrorForACustommerStatsResponse
    {
        public required int Nberror { get; set; }
        //Faut que je découple ces trucs
        public ErrorStatusEntity? ErrorStatus { get; set; }
        public ApplicationEntity? Application { get; set; }

        public SeverityLevelEntity? Severity { get; set; }
        public ServerEntity? Server { get; set; }
        public DateTime CreatedAt { get; set; }


    }
}
