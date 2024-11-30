using Persist.Entities.Catalyst;
using Services.Models.Common;
using Services.Models.Req;


namespace Services
{
    public interface ITagService
    {
        PaginationResponse<TagEntity> GetTags(QueryParameters queryParameters);
        PaginationResponse<TagCategoryEntity> GetCategories(QueryParameters queryParameters);
        Task<bool> CreateTag(CreateTagRequest tag);
        Task<bool> CreateTagCategory(CreateTagCategoryRequest category);
        Task<bool> DeleteTag(string id);
        Task<bool> DeleteTagCategories(string id);

        Task<bool> UpdateTag(UpdateTagRequest tag,string id);
        Task<bool> UpdateTagCategory(UpdateTagCategoryRequest category,string id);

        Task<String> AanalyzText(string Query);



    }
}