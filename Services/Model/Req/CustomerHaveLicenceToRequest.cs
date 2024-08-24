using System.ComponentModel.DataAnnotations;
using Ressources.Annotation.RestrictionLentgh;
using Ressources.Annotation.ValidationMessage;

namespace Services.Models.Req
{
    public class CreateCustomerHasLicenceToRequest
    {
        [Required(ErrorMessage = ValidationMessagesGeneric.IdRequired)]
        [StringLength((int)IdRestrictionLentgh.IdentifierTooLongBy36, ErrorMessage = IdentifierRestrictionLentghMessage.IdentifierTooLongBy36)]
        public required string ApplicationId { get; set; }
        [Required(ErrorMessage = ValidationMessagesGeneric.IdRequired)]
        [StringLength((int)IdRestrictionLentgh.IdentifierTooLongBy36, ErrorMessage = IdentifierRestrictionLentghMessage.IdentifierTooLongBy36)]
        public required string CustomerId { get; set; }
        public DateTime? BeginingSupport { get; set; }
        public DateTime? EndingSupport { get; set; }
        public  double cost { get; set; } = 0;

        public bool IsActive { get; set; } = false;

    }
    public class UpdateCustomerHasLicenceRequest
    {
        [Required(ErrorMessage = ValidationMessagesGeneric.IdRequired)]
        [StringLength((int)IdRestrictionLentgh.IdentifierTooLongBy36, ErrorMessage = IdentifierRestrictionLentghMessage.IdentifierTooLongBy36)]
        public required string ApplicationId { get; set; }
        [Required(ErrorMessage = ValidationMessagesGeneric.IdRequired)]
        [StringLength((int)IdRestrictionLentgh.IdentifierTooLongBy36, ErrorMessage = IdentifierRestrictionLentghMessage.IdentifierTooLongBy36)]
        public required string CustomerId { get; set; }
        public DateTime? BeginingSupport { get; set; }
        public DateTime? EndingSupport { get; set; }
        public  double cost { get; set; } = 0;

        public bool IsActive { get; set; } = false;

    }
    public class DeleteCustomerHasLicenceRequest
    {
        [Required(ErrorMessage = ValidationMessagesGeneric.IdRequired)]
        [StringLength((int)IdRestrictionLentgh.IdentifierTooLongBy36, ErrorMessage = IdentifierRestrictionLentghMessage.IdentifierTooLongBy36)]
        public required string ApplicationId { get; set; }
        [Required(ErrorMessage = ValidationMessagesGeneric.IdRequired)]
        [StringLength((int)IdRestrictionLentgh.IdentifierTooLongBy36, ErrorMessage = IdentifierRestrictionLentghMessage.IdentifierTooLongBy36)]
        public required string ServerId { get; set; }
    }
}