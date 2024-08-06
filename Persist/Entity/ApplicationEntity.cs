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
        public ApplicationEntity(string Id,string Title){
            CreatedAt = DateTime.Now;
            this.Id = Id;
            this.Title=Title;
        }
    }
}
