using System.ComponentModel.DataAnnotations;
using Ressources.Annotation.RestrictionLentgh;

namespace Services.Models.Req
{
    public class CreateServerRequest
    {
        [Required(ErrorMessage = ValidationMessages.TitleRequired)]
        [StringLength((int)FieldRestrictionLentgh.FieldTooLongBy100, ErrorMessage = FieldRestrictionLentghMessage.FieldTooLongBy100)]
        public required string Title { get; set; }
    }
    public class UpdateServerRequest
    {
        [Required(ErrorMessage = ValidationMessages.IdRequired )]
        [StringLength((int)IdRestrictionLentgh.IdentifierTooLongBy16, ErrorMessage = IdentifierRestrictionLentghMessage.IdentifierTooLongBy16)]
        public required string Id { get; set; }
        [Required(ErrorMessage = ValidationMessages.TitleRequired)]
        [StringLength((int)FieldRestrictionLentgh.FieldTooLongBy100, ErrorMessage = FieldRestrictionLentghMessage.FieldTooLongBy100)]
        public required string Title { get; set; }
    }
}