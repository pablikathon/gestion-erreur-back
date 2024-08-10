using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Persist.Entities
{
    [PrimaryKey(nameof(Id))]
    public class ApplicationEntity
    {
        [Required]
        public string Id { get; set; }
        public string Title { get; set; }  
        public DateTime CreatedAt{ get; set; }  
        public DateTime? UpdatedAt{ get; set; }  

    }
}
