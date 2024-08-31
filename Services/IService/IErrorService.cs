using Services.Models.Req;

namespace Repositories
{
    public interface IErrorService
    {
        Task<bool> AddAsync(CreateErrorRequest errorRequest);
        int UpdateErrors(UpdateErroRequest errorRequest);
        Task<Boolean> DeleteAsync(string idErreur);
    }
}
