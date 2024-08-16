using System.ComponentModel.DataAnnotations;

namespace Services.Models.Req
{
    //lors de la création d'une application le champ Title ne doit pas être null / createdAt sinitialise tout seul
    public class CreateApplicationRequest
    {
        [Required(ErrorMessage = "Title is required.")]
        [StringLength(100, ErrorMessage = "Title can't be longer than 100 characters.")]
        public string Title { get; set; }
    }

    //lors de la modification d'une application le champ Title ne doit pas être null / updatedAt sinitialise tout seul
    public class UpdateApplicationRequest
    {
        [Required(ErrorMessage = "Title is required.")]
        [StringLength(100, ErrorMessage = "Title can't be longer than 100 characters.")]
        public string Title { get; set; }

        public string Id { get; set; } = string.Empty;
    }
}