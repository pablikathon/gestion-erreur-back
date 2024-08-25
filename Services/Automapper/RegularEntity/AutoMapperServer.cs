using AutoMapper;
using Persist.Entities;
using Services.Models.Req;

public partial class MappingProfile : Profile
{
    public void MappingProfileServer()
    {
        
        CreateMap<CreateServerRequest, ServerEntity>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid().ToString()))
            .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.UtcNow))
            .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore());

        CreateMap<UpdateServerRequest, ServerEntity>()
            .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => DateTime.UtcNow));
    }
}