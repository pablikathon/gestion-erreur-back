using System.Text.Json.Serialization;
using Persist.Entities.BaseTable;

namespace Persist.Entities
{
    public class SeverityLevelEntity
    {
        public required string Id { get; set; }
        public required string Title { get; set; }
        [JsonIgnore]
        public ICollection<ErrorEntity>? Errors { get; set; }
    }
}