using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Persist.Entities
{
    [PrimaryKey(nameof(Id))]
    public class ServerEntity
    {
        [Required]
        public string Id { get; set; }
        public string Title { get; set; }
    }
}
