using System.ComponentModel.DataAnnotations;

namespace Services.Models.Req
{
   
    //lors de la création d'une application le champ Title ne doit pas être null / createdAt sinitialise tout seul
    public class CreateCustomerRequest 
    {
        [Required]
        public string Title { get; set; } 
        public string FiscalIdentification { get; set; }
        public DateTime LastInteraction{ get; set; }  
    }
    //lors de la modification d'une application le champ Title ne doit pas être null / updatedAt sinitialise tout seul
    public class UpdateCustomerRequest 
    {
        public string Id { get; set; }
        public  string Title { get; set; }
        public string FiscalIdentification { get; set; }
        public DateTime LastInteraction{ get; set; }  

    }
}