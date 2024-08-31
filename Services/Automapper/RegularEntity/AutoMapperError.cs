using AutoMapper;
using Persist.Entities;
using Services.Models.Req;

public partial class MappingProfile : Profile
{
    public void MappingProfileError()
    {
        CreateMap<CreateErrorRequest, ErrorEntity>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid().ToString()))
            .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.UtcNow))
            .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore());
    }
}