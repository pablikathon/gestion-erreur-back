namespace Persist.Entities
{
    public class ErrorStatusEntity
    {
        public required string Id { get; set; }
        public required string Title { get; set; }

        public ICollection<ErrorEntity>? Errors { get; set; }
    }
}