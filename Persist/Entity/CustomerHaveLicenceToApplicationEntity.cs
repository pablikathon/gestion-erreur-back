using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Persist.Entities
{
    [PrimaryKey(nameof(CustomerId), nameof(ApplicationId))]

    public class CustomerHaveLicenceToApplicationEntity
    {
        [Required]
        public required string ApplicationId { get; set; }

        [ForeignKey(nameof(ApplicationId))]
        public required ApplicationEntity Application { get; set; }
        [Required]

        public required string CustomerId { get; set; }

        [ForeignKey(nameof(CustomerId))]
        public required CustomerEntity Customer { get; set; }

        public DateTime? BeginingSupport { get; set; }
        public DateTime? EndingSupport { get; set; }
        //On va assumer pour l'instant que c'est en euros par mois
        public required double cost { get; set; }

        public bool IsActive { get; set; } = false;
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }

}