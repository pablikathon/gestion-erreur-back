using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Persist.Entities;
using Repositories;
using Services.Model;

namespace Services
{
    public class ServiceBook : IServiceBook
    {
        private readonly IBookRepository _bookRepository;
       private readonly IMapper _mapper;

        public ServiceBook(IBookRepository bookRepository,IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper=mapper;
        }

        public async Task<IEnumerable<Book>> GetAllBooksAsync()
        {
            IEnumerable<BookEntity> AllEntity=await _bookRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<Book>>(AllEntity);
        }

        public async Task<Book> GetBookByIdAsync(string id)
        {
            BookEntity Entity=await _bookRepository.GetByIdAsync(id);
            return _mapper.Map<Book>(Entity);
        }
        /// <summary>
        /// Create a book
        /// </summary>
        /// <param name="book"></param>
        /// <returns>book with new guid</returns>
        public async Task<Book> AddBookAsync(Book book)
        {
            BookEntity b1=new BookEntity{
                Id=Guid.NewGuid().ToString(),
                Title=book.Title
            };
           BookEntity Entity = await _bookRepository.AddAsync(b1);
           return _mapper.Map<Book>(Entity);
        }

        public async Task<Book> UpdateBookAsync(Book book,string id)
        {
            BookEntity b1=new BookEntity{
                Id=id,
                Title=book.Title
            };
            BookEntity Entity =await _bookRepository.UpdateAsync(b1);
            return _mapper.Map<Book>(Entity);
        }

        public async Task<Boolean> DeleteBookAsync(string id)
        {
           return  await _bookRepository.DeleteAsync(id);
        }
    }
}
