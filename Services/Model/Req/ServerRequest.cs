using System.ComponentModel.DataAnnotations;
using Ressources.Annotation.RestrictionLentgh;
using Ressources.Annotation.ValidationMessage;

namespace Services.Models.Req
{
    public class CreateServerRequest
    {
        [Required(ErrorMessage = ValidationMessagesGeneric.TitleRequired)]
        [StringLength((int)FieldRestrictionLentgh.FieldTooLongBy100,
            ErrorMessage = FieldRestrictionLentghMessage.FieldTooLongBy100)]
        public required string Title { get; set; }

        [Required(ErrorMessage = ValidationMessagesServer.CostRequired)]
        [Range(0.0, Double.PositiveInfinity, ErrorMessage = ValidationMessagesServer.CostMustBePositive)]
        public required double Cost { get; set; }

        public bool IsActive { get; set; } = false;

        public DateTime? HostedSince { get; set; }
        public DateTime? StopHost { get; set; }
    }

    public class UpdateServerRequest
    {
        [Required(ErrorMessage = ValidationMessagesGeneric.IdRequired)]
        [StringLength((int)IdRestrictionLentgh.IdentifierTooLongBy36,
            ErrorMessage = IdentifierRestrictionLentghMessage.IdentifierTooLongBy36)]
        public required string Id { get; set; }

        [Required(ErrorMessage = ValidationMessagesGeneric.TitleRequired)]
        [StringLength((int)FieldRestrictionLentgh.FieldTooLongBy100,
            ErrorMessage = FieldRestrictionLentghMessage.FieldTooLongBy100)]
        public required string Title { get; set; }

        [Required(ErrorMessage = ValidationMessagesServer.CostRequired)]
        [StringLength((int)FieldRestrictionLentgh.FieldTooLongBy100,
            ErrorMessage = FieldRestrictionLentghMessage.FieldTooLongBy100)]
        public required double Cost { get; set; }

        public bool IsActive { get; set; } = false;

        [Required(ErrorMessage = ValidationMessagesServer.HostedSinceRequired)]
        public required DateTime HostedSince { get; set; }

        [Required(ErrorMessage = ValidationMessagesServer.StopHostRequired)]
        public required DateTime StopHost { get; set; }
    }
}