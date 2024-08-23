using System.ComponentModel.DataAnnotations;
using Ressources.Annotation.RestrictionLentgh;
using Ressources.Annotation.ValidationMessage;

namespace Services.Models.Req
{
    //lors de la création d'une application le champ Title ne doit pas être null / createdAt sinitialise tout seul
    public class CreateApplicationRequest
    {
        [Required(ErrorMessage = ValidationMessagesGeneric.TitleRequired)]
        [StringLength((int)IdRestrictionLentgh.IdentifierTooLongBy36, ErrorMessage = IdentifierRestrictionLentghMessage.IdentifierTooLongBy36)]
        public required string Title { get; set; }
        public bool Internal { get; set; } = false;
        [Required(ErrorMessage = ValidationMessagesGeneric.DescriptionRequired)]
        [StringLength((int)FieldRestrictionLentgh.FieldTooLongBy500, ErrorMessage = FieldRestrictionLentghMessage.FieldTooLongBy500)]
        public required string Description { get; set; }

    }

    //lors de la modification d'une application le champ Title ne doit pas être null / updatedAt sinitialise tout seul
    public class UpdateApplicationRequest
    {
        [Required(ErrorMessage = ValidationMessagesGeneric.TitleRequired)]
        [StringLength((int)FieldRestrictionLentgh.FieldTooLongBy100, ErrorMessage = IdentifierRestrictionLentghMessage.IdentifierTooLongBy36)]
        public required string Title { get; set; }
        [Required(ErrorMessage = ValidationMessagesGeneric.IdRequired)]
        [StringLength((int)IdRestrictionLentgh.IdentifierTooLongBy36)]
        public required string Id { get; set; }
        public bool Internal { get; set; } = false;
        public string? Description { get; set; }
    }
}