using AutoMapper;
using Persist.Entities;
using Repositories;
using Services.Model;

namespace Services
{
    public class EntrySpotterService : IEntrySpotterService
    {
        private readonly IEntrySpotterRepository _entrySpotterRepository;
        private readonly IMapper _mapper;

        public EntrySpotterService(IEntrySpotterRepository entrySpotterRepository, IMapper mapper)
        {
            _entrySpotterRepository = entrySpotterRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EntrySpotter>> GetAllEntrySpotterAsync()
        {
            IEnumerable<EntrySpotterEntity> AllEntity = await _entrySpotterRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<EntrySpotter>>(AllEntity);
        }

        public async Task<EntrySpotter> AddEntrySpotterAsync(EntrySpotter entrySpotter)
        {
            EntryEntity entry=new EntryEntity{
                Id=entrySpotter.Entry.Id
            };
            SpotterEntity spotter=new SpotterEntity{
                Id=entrySpotter.Spotter.Id
            };
            EntrySpotterEntity b1 = new EntrySpotterEntity
            {
                Entry = entry,
                Spotter = spotter
            };
            EntrySpotterEntity Entity = await _entrySpotterRepository.AddAsync(b1);
            return _mapper.Map<EntrySpotter>(Entity);
        }


        public async Task<Boolean> DeleteEntrySpotterAsync(EntrySpotter entrySpotter)
        {
            EntryEntity entry=new EntryEntity{
                Id=entrySpotter.Entry.Id
            };
            SpotterEntity spotter=new SpotterEntity{
                Id=entrySpotter.Spotter.Id
            };
            EntrySpotterEntity b1 = new EntrySpotterEntity
            {
                Entry = entry,
                Spotter = spotter
            };
            return await _entrySpotterRepository.DeleteAsync(b1);
        }
    }
}
