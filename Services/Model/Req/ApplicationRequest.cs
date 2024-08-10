using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Services.Models.Req
{
    public abstract class ApplicationRequest
    {
        public virtual string Id { get; set; } = string.Empty;
        public virtual string? Title { get; set; }
        [JsonIgnore]
        public DateTime? CreatedAt;
        [JsonIgnore]
        public DateTime? UpdatedAt;
    }
    //lors de la création d'une application le champ Title ne doit pas être null / createdAt sinitialise tout seul
    public class CreateApplicationRequest : ApplicationRequest
    {
        public virtual string Id { get; set; } = string.Empty;
        [Required]
        public override string Title { get; set; } 

    }
    //lors de la modification d'une application le champ Title ne doit pas être null / updatedAt sinitialise tout seul
    public class UpdateApplicationRequest : ApplicationRequest
    {
        public override string Title { get; set; }

    }
    public class DeleteApplicationRequest : ApplicationRequest
    {

        public override string Id { get; set; }
    }





}