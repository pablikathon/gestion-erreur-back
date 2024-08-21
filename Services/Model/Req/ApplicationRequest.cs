using System.ComponentModel.DataAnnotations;
using Ressources.Annotation.RestrictionLentgh;

namespace Services.Models.Req
{
    //lors de la création d'une application le champ Title ne doit pas être null / createdAt sinitialise tout seul
    public class CreateApplicationRequest
    {
        [Required(ErrorMessage = ValidationMessages.TitleRequired)]
        [StringLength((int)IdRestrictionLentgh.IdentifierTooLongBy36, ErrorMessage = IdentifierRestrictionLentghMessage.IdentifierTooLongBy36)]
        public required string Title { get; set; }
    }

    //lors de la modification d'une application le champ Title ne doit pas être null / updatedAt sinitialise tout seul
    public class UpdateApplicationRequest
    {
        [Required(ErrorMessage = ValidationMessages.TitleRequired)]
        [StringLength((int)FieldRestrictionLentgh.FieldTooLongBy100, ErrorMessage = IdentifierRestrictionLentghMessage.IdentifierTooLongBy36)]
        public required string Title { get; set; }
        [Required(ErrorMessage = ValidationMessages.IdRequired)]
        [StringLength((int)IdRestrictionLentgh.IdentifierTooLongBy36)]
        public required string Id { get; set; }
    }
}