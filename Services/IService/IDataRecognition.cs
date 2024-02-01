using Services.Model;

namespace Services
{
    public interface IDataRecognition
    {
        Task<String> AanalyzText(String Query);
    }
}
