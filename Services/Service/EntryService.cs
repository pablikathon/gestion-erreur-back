using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Persist.Entities;
using Repositories;
using Services.Model;

namespace Services
{
    public class EntryService : IEntryService
    {
        private readonly IEntryRepository _entryRepository;
       private readonly IMapper _mapper;

        public EntryService(IEntryRepository entryRepository,IMapper mapper)
        {
            _entryRepository = entryRepository;
            _mapper=mapper;
        }

        public async Task<IEnumerable<Entry>> GetAllEntrysAsync()
        {
            IEnumerable<EntryEntity> AllEntity=await _entryRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<Entry>>(AllEntity);
        }

        public async Task<Entry> GetEntryByIdAsync(string id)
        {
            EntryEntity Entity=await _entryRepository.GetByIdAsync(id);
            return _mapper.Map<Entry>(Entity);
        }
        /// <summary>
        /// Create a book
        /// </summary>
        /// <param name="book"></param>
        /// <returns>book with new guid</returns>
        public async Task<Entry> AddEntryAsync(Entry entry)
        {
            EntryEntity b1=new EntryEntity{
                Id=Guid.NewGuid().ToString(),
                Title=entry.Title
            };
           EntryEntity Entity = await _entryRepository.AddAsync(b1);
           return _mapper.Map<Entry>(Entity);
        }

        public async Task<Entry> UpdateEntryAsync(Entry entry,string id)
        {
            EntryEntity b1=new EntryEntity{
                Id=id,
                Title=entry.Title
            };
            EntryEntity Entity =await _entryRepository.UpdateAsync(b1);
            return _mapper.Map<Entry>(Entity);
        }

        public async Task<Boolean> DeleteEntryAsync(string id)
        {
           return  await _entryRepository.DeleteAsync(id);
        }
    }
}
