using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Persist.Entities;
using Repositories;
using Services.Models.Req;

namespace Services
{
    public class ErrorService : IErrorService
    {
        private readonly IErrorRepository _errorRepository;
        private readonly IMapper _mapper;

        public ErrorService(IErrorRepository errorRepository, IMapper mapper)
        {
            _errorRepository = errorRepository;
            _mapper = mapper;
        }

        public async Task<bool> AddAsync(CreateErrorRequest errorRequest)
        {
            return await _errorRepository.AddAsync(_mapper.Map<ErrorEntity>(errorRequest));
        }

        public async Task<bool> DeleteAsync(string idErreur)
        {
            return await _errorRepository.DeleteAsync(idErreur);
        }

        /// <summary>
        ///  update all error who match with errorrequest
        /// </summary>
        /// <param name="errorRequest"></param>
        /// <returns>number of row affected</returns>
        public int UpdateErrors(UpdateErroRequest errorRequest)
        {
            var query = _errorRepository.GetAllAsync();
            return query.Where(
                err =>
                    err.ApplicationId.Equals(errorRequest.ApplicationId) &&
                    err.CreatedAt.Date.Equals(errorRequest.CreatedAt.Date) &&
                    err.ServerId.Equals(errorRequest.SeverityId) &&
                    err.SeverityId.Equals(errorRequest.OldSeverityId) &&
                    err.StatusId.Equals(errorRequest.OldStatusId)
            ).ExecuteUpdate(
                setter =>
                    setter.SetProperty(err => err.SeverityId, errorRequest.SeverityId)
                        .SetProperty(err => err.StatusId, errorRequest.StatusId)
                        .SetProperty(err => err.UpdatedAt, DateTime.UtcNow)
            );
        }
    }
}