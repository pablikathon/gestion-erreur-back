using System.ComponentModel.DataAnnotations;

namespace Services.Models.Req
{
    public class CreateServerRequest
    {
        [Required(ErrorMessage = "Title is required.")]
        [StringLength(100, ErrorMessage = "Title can't be longer than 200 characters.")]
        public required string Title { get; set; }
    }
    public class UpdateServerRequest
    {
        [Required(ErrorMessage = "Id is required.")]
        [StringLength(16, ErrorMessage = "Guid can't be longer than 16 character")]
        public required string Id { get; set; }
        [Required(ErrorMessage = "Title is required.")]
        [StringLength(100, ErrorMessage = "Title can't be longer than 200 characters.")]
        public required string Title { get; set; }
    }
}