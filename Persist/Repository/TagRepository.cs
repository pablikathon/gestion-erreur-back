using Persist;
using Persist.Entities.Catalyst;
using Persist.Entities.Catalyst.JoiningTable;
namespace Repositories
{
    public class TagRepository : ITagRepository
    {
        private readonly AppDbContext _context;

        public TagRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateTag(TagEntity tag)
        {
            try
            {
                _context.Tag.Add(tag);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public async Task<bool> CreateTagCategory(TagCategoryEntity category)
        {
            try
            {
                _context.TagCategories.Add(category);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public async Task<bool> DeleteTag(string id)
        {
            try
            {
                TagEntity? tagEntity = await _context.Tag.FindAsync(id);
                if (tagEntity != null)
                {
                    _context.Tag.Remove(tagEntity);
                    await _context.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public async Task<bool> DeleteTagCategories(string id)
        {
            try
            {
                TagCategoryEntity? tagEntity = await _context.TagCategories.FindAsync(id);
                if (tagEntity != null)
                {
                    _context.TagCategories.Remove(tagEntity);
                    await _context.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public IQueryable<TagCategoryTagEntity> GetRelationBetwenTagAndCategories()
        {
            return _context.TagCategoriesTag.AsQueryable();
        }

        public IQueryable<TagEntity> GetTag()
        {
            return _context.Tag.AsQueryable();
        }

        public IQueryable<TagCategoryEntity> GetTagCategories()
        {
            return _context.TagCategories.AsQueryable();
        }

        public async Task<bool> RelateATagAndCategory(TagCategoryTagEntity tagCategories)
        {
            try
            {
                _context.TagCategoriesTag.Add(tagCategories);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public async Task<bool> UpdateTag(TagEntity tag, string id)
        {
            TagEntity? t = _context.Tag.Find(id);
            if (t != null)
            {
                t.Title = tag.Title;
                t.UpdatedAt = tag.UpdatedAt;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> UpdateTagCategory(TagCategoryEntity category, string id)
        {
            TagCategoryEntity? tc = _context.TagCategories.Find(id);
            if (tc != null)
            {
                tc.Title = category.Title;
                tc.UpdatedAt = category.UpdatedAt;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}