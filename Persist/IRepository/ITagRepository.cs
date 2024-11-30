using Persist.Entities.Catalyst;
using Persist.Entities.Catalyst.JoiningTable;
using Persist.Migrations;

namespace Repositories
{
    public interface ITagRepository
    {
        IQueryable<TagEntity> GetTag();
        IQueryable<TagCategoryEntity> GetTagCategories();
        IQueryable<TagCategoryTagEntity> GetRelationBetwenTagAndCategories();

        Task<bool> CreateTag(TagEntity tag);
        Task<bool> CreateTagCategory(TagCategoryEntity category);
        Task<bool> DeleteTag(string id);
        Task<bool> DeleteTagCategories(string id);
        Task<bool> UpdateTag(TagEntity tag, string id);
        Task<bool> UpdateTagCategory(TagCategoryEntity category, string id);

        Task<bool> RelateATagAndCategory(TagCategoryTagEntity tagCategoryTag);
    }
}