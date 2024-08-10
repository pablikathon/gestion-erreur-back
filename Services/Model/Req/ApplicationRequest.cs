using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Services.Models.Req
{
   
    //lors de la création d'une application le champ Title ne doit pas être null / createdAt sinitialise tout seul
    public class CreateApplicationRequest 
    {
        [Required]
        public  string Title { get; set; } 

    }
    //lors de la modification d'une application le champ Title ne doit pas être null / updatedAt sinitialise tout seul
    public class UpdateApplicationRequest 
    {
        public  string Title { get; set; }
        public  string Id { get; set; } = string.Empty;

    }






}