using AutoMapper;
using Persist.Entities;
using Services.Model;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<BookEntity, Book>();
        CreateMap<EntryEntity,Entry>();
        CreateMap<SpotterEntity,Spotter>();
        CreateMap<EntrySpotterEntity,EntrySpotter>();
    }
}
