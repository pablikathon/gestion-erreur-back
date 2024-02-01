
namespace Services.Model
{
    public class DataRecognitionModel
    {
        public Spotter Spotter { get; set; }
        public IEnumerable<Entry> EntryList { get; set; }
    }
}
