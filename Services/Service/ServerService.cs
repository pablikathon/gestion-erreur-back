using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Persist.Entities;
using Repositories;
using Services.Models.Common;
using Services.Models.Req;

namespace Services
{
    public class ServerServices : IServerService
    {
        private readonly IServerRepository _serverRepository;
        private readonly IMapper _mapper;

        public ServerServices(IServerRepository ServerRepository, IMapper mapper)
        {
            _serverRepository = ServerRepository;
            _mapper = mapper;
        }

        public PaginationResponse<ServerEntity> GetServers(QueryParameters queryParameters)
        {
            var query = _serverRepository.GetServers();
            query = TextSearchQuery(queryParameters, query);
            query = DateSearchQuery(queryParameters, query);
            query = SortQuery(queryParameters, query);
            query = Pagination(queryParameters, query);

            var result = query.ToList();
            return new PaginationResponse<ServerEntity>(result, result.Count,
                queryParameters.Pagination.PageNumber, queryParameters.Pagination.PageSize);
        }

        internal static IQueryable<ServerEntity> SortQuery(QueryParameters queryParameters,
            IQueryable<ServerEntity> query)
        {
            if (!String.IsNullOrEmpty(queryParameters.Sort.SortBy) &&
                !String.IsNullOrWhiteSpace(queryParameters.Sort.SortBy))
            {
                switch (queryParameters.Sort.SortBy)
                {
                    case nameof(ServerEntity.Title):
                        query = queryParameters.Sort.Ascending
                            ? query.OrderBy(a => a.Title)
                            : query.OrderByDescending(a => a.Title);
                        break;
                    case nameof(ServerEntity.CreatedAt):
                        query = queryParameters.Sort.Ascending
                            ? query.OrderBy(a => a.CreatedAt)
                            : query.OrderByDescending(a => a.CreatedAt);
                        break;
                    case nameof(ServerEntity.UpdatedAt):
                        query = queryParameters.Sort.Ascending
                            ? query.OrderBy(a => a.UpdatedAt)
                            : query.OrderByDescending(a => a.UpdatedAt);
                        break;
                }
            }

            return query;
        }

        internal static IQueryable<ServerEntity> Pagination(QueryParameters queryParameters,
            IQueryable<ServerEntity> query)
        {
            if (queryParameters.Pagination.PageNumber.GetHashCode() != 0)
            {
                query = query
                    .Skip((queryParameters.Pagination.PageNumber - 1) * queryParameters.Pagination.PageSize)
                    .Take(queryParameters.Pagination.PageSize);
            }

            return query;
        }

        internal static IQueryable<ServerEntity> DateSearchQuery(QueryParameters queryParameters,
            IQueryable<ServerEntity> query)
        {
            if (queryParameters.StartDate.HasValue && queryParameters.EndDate.HasValue)
            {
                switch (queryParameters.DateField)
                {
                    case nameof(ApplicationEntity.CreatedAt):
                        query = query.Where(a =>
                            a.CreatedAt >= queryParameters.StartDate && a.CreatedAt <= queryParameters.EndDate);
                        break;
                    case nameof(ApplicationEntity.UpdatedAt):
                        query = query.Where(a =>
                            a.UpdatedAt >= queryParameters.StartDate && a.UpdatedAt <= queryParameters.EndDate);
                        break;
                    default:
                        throw new ArgumentException("Bad column date name");
                }
            }

            return query;
        }

        internal static IQueryable<ServerEntity> TextSearchQuery(QueryParameters queryParameters,
            IQueryable<ServerEntity> query)
        {
            if (!String.IsNullOrEmpty(queryParameters.SearchTerm) &&
                !String.IsNullOrWhiteSpace(queryParameters.SearchTerm))
            {
                switch (queryParameters.SearchColumn)
                {
                    case nameof(ServerEntity.Title):
                        query = query.Where(a => a.Title.ToLower().Contains(queryParameters.SearchTerm.ToLower()));
                        break;
                    default:
                        throw new ArgumentException("Bad column name");
                }
            }

            return query;
        }

        public async Task<ServerEntity> CreateServer(CreateServerRequest createServerRequest)
        {
            var validation = new ValidationContext(createServerRequest);
            var validationResults = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(createServerRequest, validation, validationResults, true);
            if (isValid)
                return await _serverRepository.AddAsync(_mapper.Map<ServerEntity>(createServerRequest));
            throw new ArgumentException("not valid object");
        }

        public async Task<Boolean> UpdateServer(UpdateServerRequest updateServerRequest)
        {
            return await _serverRepository.UpdateAsync(_mapper.Map<ServerEntity>(updateServerRequest));
        }

        public async Task<Boolean> DeleteServer(string id)
        {
            return await _serverRepository.DeleteAsync(id);
        }
    }
}