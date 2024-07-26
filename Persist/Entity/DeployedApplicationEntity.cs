using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Persist.Entities
{
    [PrimaryKey(nameof(ServerId),nameof(ApplicationId),nameof(CustomerId))]

    public class DeployedApplicationEntity
    {
        [Required]
        public string ServerId { get; set; }

        [ForeignKey(nameof(ServerId))]
        public ServerEntity Entry { get; set; }

        [Required]
        public string ApplicationId { get; set; }

        [ForeignKey(nameof(ApplicationId))]
        public ApplicationEntity Application { get; set; }
        [Required]
        public string CustomerId { get; set; }

        [ForeignKey(nameof(CustomerId))]
        public CustomerEntity Customer { get; set; }

    }

}