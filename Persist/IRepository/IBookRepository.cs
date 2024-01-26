using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Persist.Entities;

namespace Repositories
{
    public interface IBookRepository 
    {
        Task<IEnumerable<BookEntity>> GetAllAsync();
        Task<BookEntity> GetByIdAsync(string id);
        Task<BookEntity> AddAsync(BookEntity book);
        Task<BookEntity>UpdateAsync(BookEntity book);
        Task<Boolean> DeleteAsync(string id);
    }
}
