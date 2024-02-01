using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Persist.Entities
{
    [PrimaryKey(nameof(EntryId),nameof(SpotterId))]

    public class EntrySpotterEntity
    {
        [Required]
        public string EntryId { get; set; }

        [ForeignKey(nameof(EntryId))]
        public EntryEntity Entry { get; set; }

        [Required]
        public string SpotterId { get; set; }

        [ForeignKey(nameof(SpotterId))]
        public SpotterEntity Spotter { get; set; }

    }

}