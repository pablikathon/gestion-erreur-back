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
                    err.ServerId.Equals(errorRequest.ServerId) &&
                    err.SeverityId.Equals(errorRequest.OldSeverityId) &&
                    err.StatusId.Equals(errorRequest.OldStatusId)
            ).ExecuteUpdate(
                setter =>
                    setter.SetProperty(err => err.SeverityId, errorRequest.SeverityId)
                        .SetProperty(err => err.StatusId, errorRequest.StatusId)
                        .SetProperty(err => err.UpdatedAt, DateTime.UtcNow)
            );
        }
        public PaginationResponse<ErrorForACustommerStatsResponse> GetErrorsForACustommerAgregate(
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
                createdAt = EF.Functions.DateDiffDay(new DateTime(1900, 1, 1), g.CreatedAt)
            }).Select(s => new
            {
                Nberror = s.Select(e => e.Id).Distinct().Count(),
                s.Key.ServerId,
                s.Key.SeverityId,
                s.Key.StatusId,
                s.Key.ApplicationId,
                CreatedAt = s.Max(e => e.CreatedAt)
            })
            .Pagination(queryParameters.Pagination).ToList();


            var lastquery = query.Select(s => new ErrorForACustommerStatsResponse
            {
                Nberror = s.Nberror,
                Server = _context.Server.FirstOrDefault(server => server.Id.Equals(s.ServerId)),
                Severity = _context.SeverityLevel.FirstOrDefault(severity => severity.Id.Equals(s.SeverityId)),
                ErrorStatus = _context.ErrorStatus.FirstOrDefault(status => status.Id.Equals(s.StatusId)),
                Application = _context.Application.FirstOrDefault(application => application.Id.Equals(s.ApplicationId)),
                CreatedAt = s.CreatedAt
            }).AsQueryable();

            if (queryParameters.SearchParam != null)
                lastquery = lastquery.TextSearch(queryParameters.SearchParam);

            var result = lastquery.SortBy(queryParameters.Sort).ToList();
            //var result = lastquery.OrderBy(x => x.Server.Title).ToList();
            return new PaginationResponse<ErrorForACustommerStatsResponse>(result, result.Count,
                queryParameters.Pagination.PageNumber,
                queryParameters.Pagination.PageSize);
        }
        public PaginationResponse<ErrorEntity> GetErrorsForACustommer(
    QueryParameters queryParameters, GetErrorRequest errorRequest)
        {
            var query =
             _context.Error.Where(
                err =>
                    err.ApplicationId.Equals(errorRequest.ApplicationId) &&
                    EF.Functions.DateDiffDay(new DateTime(1900, 1, 1), err.CreatedAt) == EF.Functions.DateDiffDay(new DateTime(1900, 1, 1), errorRequest.CreatedAt) &&
                    err.ServerId.Equals(errorRequest.ServerId) &&
                    err.SeverityId.Equals(errorRequest.SeverityId) &&
                    err.StatusId.Equals(errorRequest.StatusId)
            );
            if (queryParameters.SearchParam != null)
                query = query.TextSearch(queryParameters.SearchParam);
            query = query.DateSearchQuery(queryParameters.DateParam);
            query = query.Pagination(queryParameters.Pagination);
            query = query.SortBy(queryParameters.Sort);
            var result = query.ToList();
            return new PaginationResponse<ErrorEntity>(result, result.Count,
                queryParameters.Pagination.PageNumber,
                queryParameters.Pagination.PageSize);
        }
    }
}