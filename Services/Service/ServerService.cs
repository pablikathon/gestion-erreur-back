using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Persist.Entities;
using Persist.Entities.BaseTable;
using Repositories;
using Services.Extension;
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
            if (queryParameters.SearchParam != null)
                query = query.TextSearch(queryParameters.SearchParam);
            query = query.DateSearchQuery(queryParameters.DateParam);
            query = query.SortBy(queryParameters.Sort);
            query = query.Pagination(queryParameters.Pagination);

            var result = query.ToList();
            return new PaginationResponse<ServerEntity>(result, result.Count,
                queryParameters.Pagination.PageNumber, queryParameters.Pagination.PageSize);
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