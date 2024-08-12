using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Persist.Entities
{
    [PrimaryKey(nameof(Id))]
    public class CustomerEntity
    {
        [Required]
        public string Id { get; set; }
        public string Title { get; set; }  

        public string FiscalIdentification { get; set; }
        public DateTime CreatedAt{ get; set; }  
        public DateTime? UpdatedAt{ get; set; }  
        public DateTime LastInteraction{ get; set; }  

    }
}
