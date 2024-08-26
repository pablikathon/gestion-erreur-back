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
            query = query.DateSearchQuery(queryParameters.DateParam);
            query = SortQuery(queryParameters, query);
            query = query.Pagination(queryParameters.Pagination);

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

        internal static IQueryable<ServerEntity> TextSearchQuery(QueryParameters queryParameters,
            IQueryable<ServerEntity> query)
        {
            if (queryParameters.SearchParam != null)
                if (!String.IsNullOrEmpty(queryParameters.SearchParam.SearchTerm) &&
                    !String.IsNullOrWhiteSpace(queryParameters.SearchParam.SearchTerm))
                {
                    switch (queryParameters.SearchParam.SearchColumn)
                    {
                        case nameof(ServerEntity.Title):
                            query = query.Where(a => a.Title.ToLower().Contains(queryParameters.SearchParam.SearchTerm.ToLower()));
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