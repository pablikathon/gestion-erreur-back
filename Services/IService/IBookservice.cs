using Services.Model;

namespace Services
{
    public interface IServiceBook
    {
        Task<IEnumerable<Book>> GetAllBooksAsync();
        Task<Book> GetBookByIdAsync(string id);
        Task<Book> AddBookAsync(Book book);
        Task<Book> UpdateBookAsync(Book book,string id);
        Task<Boolean> DeleteBookAsync(string id);
    }
}
