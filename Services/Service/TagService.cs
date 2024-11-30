using AutoMapper;
using Persist;
using Persist.Entities.Catalyst;
using Persist.Migrations;
using Repositories;
using Services.Extension;
using Services.Models.Common;
using Services.Models.Req;

namespace Services
{
    public class TagService : ITagService
    {
        private readonly IMapper _mapper;

        private readonly ITagRepository _repository;

        public TagService( IMapper mapper,ITagRepository tagRepository)
        {
            _mapper = mapper;
            _repository = tagRepository;
        }

        public Task<string> AanalyzText(string Query)
        {
            throw new NotImplementedException();
        }
        //todo move into repository
        public async Task<bool> CreateTag(CreateTagRequest Tag )
        {
            return await _repository.CreateTag(_mapper.Map<TagEntity>(Tag ));
        }

        public async Task<bool> CreateTagCategory(CreateTagCategoryRequest category)
        {
            return await _repository.CreateTagCategory(_mapper.Map<TagCategoryEntity>(category));
        }

        public async Task<bool> DeleteTag(string id)
        {
            return await _repository.DeleteTag(id);
        }

        public async Task<bool> DeleteTagCategories(string id)
        {
            return await _repository.DeleteTagCategories(id);
        }

        public PaginationResponse<TagCategoryEntity> GetCategories(QueryParameters queryParameters)
        {
            var query = _repository.GetTagCategories();
            if (queryParameters.SearchParam != null)
                query = query.TextSearch(queryParameters.SearchParam);
            query = query.DateSearchQuery(queryParameters.DateParam);
            query = query.SortBy(queryParameters.Sort);
            query = query.Pagination(queryParameters.Pagination);

            var result = query.ToList();
            return new PaginationResponse<TagCategoryEntity>(result, result.Count,
                queryParameters.Pagination.PageNumber, queryParameters.Pagination.PageSize);
        }
        

        public PaginationResponse<TagEntity> GetTags(QueryParameters queryParameters)
        {
            var query = _repository.GetTag();
            if (queryParameters.SearchParam != null)
               query = query.DateSearchQuery(queryParameters.DateParam);
            query = query.SortBy(queryParameters.Sort);
            query = query.Pagination(queryParameters.Pagination);

            var result = query.ToList();
            return new PaginationResponse<TagEntity>(result, result.Count,
                queryParameters.Pagination.PageNumber, queryParameters.Pagination.PageSize);
        }

        public Task<bool> UpdateTag(UpdateTagRequest tag, string id)
        {
            return _repository.UpdateTag(_mapper.Map<TagEntity>(tag), id);
        }

        public Task<bool> UpdateTagCategory(UpdateTagCategoryRequest category,string id)
        {
            return _repository.UpdateTagCategory(_mapper.Map<TagCategoryEntity>(category), id);
        }
    }
}