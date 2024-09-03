using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Persist;
using Persist.Entities;
using Repositories;
using Services.Models.Common;
using Services.Models.Req;

namespace Services
{
    public class ErrorService : IErrorService
    {
        private readonly IErrorRepository _errorRepository;
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;

        public ErrorService(IErrorRepository errorRepository, IMapper mapper, AppDbContext context)
        {
            _errorRepository = errorRepository;
            _mapper = mapper;
            _context = context;
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
        public PaginationResponse<ErrorForACustommerStatsResponse> GetErrorsForAClientStats(
            QueryParameters queryParameters, string custommerId)
        {
            var query = _context.Error

            .Where(e => e.Application.CustomerHaveLicenceToApplication
            .Any(chlta => chlta.CustomerId.Equals(custommerId))
            )
            .GroupBy(g => new
            {
                g.ApplicationId,
                g.ServerId,
                g.SeverityId,
                g.StatusId,
            }).Select(s => new
             {
                 Nberror = s.Select(e => e.Id).Distinct().Count(),
                 s.Key.ServerId,
                 s.Key.SeverityId,
                 s.Key.StatusId,
                 CreatedAt = s.Max(e => e.CreatedAt)
             });
            query = query.Pagination(queryParameters.Pagination);
            // ça demande moins de perf de chercher les champs directement avec le groupBy puis le select pour ensuite faire la pagination
            // afin de réduire le nom de champ au maximum avant 

            //J'ai besoins d'utiliser un asenumerable pour chercher mes éléments
            var lastquery = query.ToList()
            .Select(s => new ErrorForACustommerStatsResponse
            {
                Nberror = s.Nberror,
                Server = _context.Server.FirstOrDefault(server => server.Id == s.ServerId),
                Severity = _context.SeverityLevel.FirstOrDefault(severity => severity.Id == s.SeverityId),
                Status = _context.ErrorStatus.FirstOrDefault(status => status.Id == s.StatusId),
                CreatedAt = s.CreatedAt
            });            
        
            if (queryParameters.SearchParam != null)
                    query = query.TextSearch(queryParameters.SearchParam);

            query = query.SortBy(queryParameters.Sort);
            var result = lastquery.ToList();

            return new PaginationResponse<ErrorForACustommerStatsResponse>(result, result.Count,
                queryParameters.Pagination.PageNumber,
                queryParameters.Pagination.PageSize);
        }
    }
}