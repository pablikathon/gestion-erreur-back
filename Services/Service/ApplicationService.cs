using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Persist.Entities;
using Repositories;
using Services.Models.Common;
using Services.Models.Req;

namespace Services
{
    public class ApplicationService : IApplicationService
    {
        private readonly IApplicationRepository _applicationRepository;
        private readonly IMapper _mapper;

        public ApplicationService(IApplicationRepository ApplicationRepository,IMapper mapper)
        {
            _applicationRepository = ApplicationRepository;
            _mapper=mapper;
        }
        public async Task<PaginationResponse<ApplicationEntity>> GetApplications(QueryParameters queryParameters){
            var query =  _applicationRepository.GetApplications();
            if(!String.IsNullOrEmpty(queryParameters.SearchTerm) && !String.IsNullOrWhiteSpace(queryParameters.SearchTerm)){
                switch (queryParameters.SearchColumn)
                {
                    case nameof(ApplicationEntity.Title):
                         query.Where( a => a.Title.ToLower().Equals(queryParameters.SearchTerm.ToLower()));                        
                         break;
                    default:
                        throw new ArgumentException("Bad column name");
                }
            }
            if( queryParameters.Pagination.PageNumber.GetHashCode() != 0 ){
                query = query
                .Skip((queryParameters.Pagination.PageNumber - 1) * queryParameters.Pagination.PageSize)
                .Take(queryParameters.Pagination.PageSize);
            }

            var result = query.ToList();

            return new PaginationResponse<ApplicationEntity>(result, result.Count, queryParameters.Pagination.PageNumber, queryParameters.Pagination.PageSize);
        }

        public async Task<ApplicationEntity> CreateApplication(ApplicationRequest  application){
            ApplicationEntity a1=new ApplicationEntity(
                Guid.NewGuid().ToString(),
                application.Title);
            a1 = await _applicationRepository.AddAsync(a1);
            return a1;
        }
    }
}