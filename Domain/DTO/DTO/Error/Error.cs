
using Domain.Applications;
namespace Domain.DTO.Error
{
    public class Error
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string? StackTrace { get; set; }
        public DateTime OccurredAt { get; set; }
        public string? Severity { get; set; }
        public string? Source { get; set; }
        public bool IsResolved { get; set; }
        public Application? Application { get; set; }
        public bool IsSevereByFrequency(IEnumerable<Error> errors, int threshold = 3)
        {
            if (errors == null)
            {
                return false;
            }

            int duplicates = errors.Count(e =>
                string.Equals(e.Title, Title, StringComparison.OrdinalIgnoreCase) &&
                e.OccurredAt.Date == OccurredAt.Date);

            return duplicates >= threshold;
        }

    }
}
