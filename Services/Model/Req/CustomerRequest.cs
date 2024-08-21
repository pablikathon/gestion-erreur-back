using System.ComponentModel.DataAnnotations;
using Ressources.Annotation.RestrictionLentgh;

namespace Services.Models.Req
{
    public class CreateCustomerRequest
    {
        [Required]
        [StringLength((int)FieldRestrictionLentgh.FieldTooLongBy100)]
        public required string Title { get; set; }
        [Required]
        [StringLength((int)IdRestrictionLentgh.IdentifierTooLongBy36)]
        public required string FiscalIdentification { get; set; }
        public DateTime LastInteraction { get; set; }
    }

    public class UpdateCustomerRequest
    {
        [Required]
        [StringLength((int)IdRestrictionLentgh.IdentifierTooLongBy36, ErrorMessage = IdentifierRestrictionLentghMessage.IdentifierTooLongBy36)]
        public required string Id { get; set; }
        [Required]
        [StringLength((int)FieldRestrictionLentgh.FieldTooLongBy100, ErrorMessage = FieldRestrictionLentghMessage.FieldTooLongBy100)]
        public required string Title { get; set; }
        [Required]
        [StringLength((int)IdRestrictionLentgh.SiretTooLongBy14, ErrorMessage = IdentifierRestrictionLentghMessage.SiretTooLongBy14)]
        public required string FiscalIdentification { get; set; }
        public DateTime LastInteraction { get; set; }
    }
}