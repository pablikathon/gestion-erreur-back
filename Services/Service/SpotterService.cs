using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Persist.Entities;
using Repositories;
using Services.Model;

namespace Services
{
    public class SpotterService : ISpotterService
    {
        private readonly ISpotterRepository _spotterRepository;
       private readonly IMapper _mapper;

        public SpotterService(ISpotterRepository spotterRepository,IMapper mapper)
        {
            _spotterRepository = spotterRepository;
            _mapper=mapper;
        }

        public async Task<IEnumerable<Spotter>> GetAllSpottersAsync()
        {
            IEnumerable<SpotterEntity> AllEntity=await _spotterRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<Spotter>>(AllEntity);
        }

        public async Task<Spotter> GetSpotterByIdAsync(string id)
        {
            SpotterEntity Entity=await _spotterRepository.GetByIdAsync(id);
            return _mapper.Map<Spotter>(Entity);
        }

        public async Task<Spotter> AddSpotterAsync(Spotter spotter)
        {
            SpotterEntity b1=new SpotterEntity{
                Id=Guid.NewGuid().ToString(),
                Title=spotter.Title,
                Tag=spotter.Tag
            };
           SpotterEntity Entity = await _spotterRepository.AddAsync(b1);
           return _mapper.Map<Spotter>(Entity);
        }

        public async Task<Spotter> UpdateSpotterAsync(Spotter spotter,string id)
        {
            SpotterEntity b1=new SpotterEntity{
                Id=id,
                Title=spotter.Title,
                Tag=spotter.Tag
            };
            SpotterEntity Entity =await _spotterRepository.UpdateAsync(b1);
            return _mapper.Map<Spotter>(Entity);
        }

        public async Task<Boolean> DeleteSpotterAsync(string id)
        {
           return  await _spotterRepository.DeleteAsync(id);
        }
    }
}
