using System.ComponentModel.DataAnnotations;
using Ressources.Annotation.RestrictionLentgh;
using Ressources.Annotation.ValidationMessage;

namespace Services.Models.Req
{
    //lors de la création d'une application le champ Title ne doit pas être null / createdAt sinitialise tout seul
    public class CreateTagRequest
    {
        [Required(ErrorMessage = ValidationMessagesGeneric.TitleRequired)]
        [StringLength((int)FieldRestrictionLentgh.FieldTooLongBy100,
        ErrorMessage = FieldRestrictionLentghMessage.FieldTooLongBy100)]
        public required string Title { get; set; }
    }
    public class UpdateTagRequest
    {
        [Required(ErrorMessage = ValidationMessagesGeneric.TitleRequired)]
        [StringLength((int)FieldRestrictionLentgh.FieldTooLongBy100,
        ErrorMessage = FieldRestrictionLentghMessage.FieldTooLongBy100)]
        public required string Title { get; set; }
    }
    public class CreateTagCategoryRequest
    {
        [Required(ErrorMessage = ValidationMessagesGeneric.TitleRequired)]
        [StringLength((int)FieldRestrictionLentgh.FieldTooLongBy100,
        ErrorMessage = FieldRestrictionLentghMessage.FieldTooLongBy100)]
        public required string Title { get; set; }
    }
    public class UpdateTagCategoryRequest
    {
        [Required(ErrorMessage = ValidationMessagesGeneric.IdRequired)]
        [StringLength((int)IdRestrictionLentgh.IdentifierTooLongBy36,
        ErrorMessage = IdentifierRestrictionLentghMessage.IdentifierTooLongBy36)]
        public required string Id { get; set; }

        [Required(ErrorMessage = ValidationMessagesGeneric.TitleRequired)]
        [StringLength((int)FieldRestrictionLentgh.FieldTooLongBy100,
        ErrorMessage = FieldRestrictionLentghMessage.FieldTooLongBy100)]
        public required string Title { get; set; }
    }
    public class CreateTagCategoryTagRequest
    {
        [Required(ErrorMessage = ValidationMessagesGeneric.IdRequired)]
        [StringLength((int)IdRestrictionLentgh.IdentifierTooLongBy36,
        ErrorMessage = IdentifierRestrictionLentghMessage.IdentifierTooLongBy36)]
        public required string IdTag { get; set; }
        [Required(ErrorMessage = ValidationMessagesGeneric.IdRequired)]
        [StringLength((int)IdRestrictionLentgh.IdentifierTooLongBy36,
        ErrorMessage = IdentifierRestrictionLentghMessage.IdentifierTooLongBy36)]
        public required string IdTagCategory { get; set; }
    }
    public class UpdateTagCategoryTagRequest
    {
        [Required(ErrorMessage = ValidationMessagesGeneric.IdRequired)]
        [StringLength((int)IdRestrictionLentgh.IdentifierTooLongBy36,
        ErrorMessage = IdentifierRestrictionLentghMessage.IdentifierTooLongBy36)]
        public required string IdTag { get; set; }
        [Required(ErrorMessage = ValidationMessagesGeneric.IdRequired)]
        [StringLength((int)IdRestrictionLentgh.IdentifierTooLongBy36,
        ErrorMessage = IdentifierRestrictionLentghMessage.IdentifierTooLongBy36)]
        public required string IdTagCategory { get; set; }
    }
}