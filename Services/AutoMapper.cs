using AutoMapper;
using Persist.Entities;
using Services.Model;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<BookEntity, Book>();
    }
}
