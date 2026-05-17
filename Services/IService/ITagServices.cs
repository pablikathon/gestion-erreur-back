using Persist.Entities.Catalyst;

using Services.Models.Command;
using Services.Models.Common;


namespace Services
{
    public interface ITagService
    {
        PaginationResponse<TagEntity> GetTags(QueryParameters queryParameters);
        PaginationResponse<TagCategoryEntity> GetCategories(QueryParameters queryParameters);
        Task<bool> CreateTag(CreateTagCommand tag);
        Task<bool> CreateTagCategory(CreateTagCategoryCommand category);
        Task<bool> DeleteTag(string id);
        Task<bool> DeleteTagCategories(string id);

        Task<bool> UpdateTag(UpdateTagCommand tag, string id);
        Task<bool> UpdateTagCategory(UpdateTagCategoryCommand category, string id);

        Task<String> AanalyzText(string Query);



    }
}
