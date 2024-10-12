using Persist.Entities.Catalyst;
using Persist.Migrations;
using Services.Models.Common;


namespace Services
{
    public interface ITagService
    {
        PaginationResponse<TagEntity> GetTags(QueryParameters queryParameters);
        PaginationResponse<TagCategories> GetCategories(QueryParameters queryParameters);
        bool CreateTag(TagEntity tag);
        bool CreateTagCategory(TagCategories category);
        bool DeleteTag(TagEntity tag);
        bool DeleteTagCategories(TagCategories category);

        bool UpdateTag(TagEntity tag);
        bool UpdateTagCategory(TagCategories category);

        Task<String> AanalyzText(string Query);



    }
}