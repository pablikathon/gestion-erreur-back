using System.Text.Json.Serialization;

namespace Persist.Entities
{
    public class ErrorStatusEntity
    {
        public required string Id { get; set; }
        public required string Title { get; set; }
        [JsonIgnore]
        public ICollection<ErrorEntity>? Errors { get; set; }
    }
}