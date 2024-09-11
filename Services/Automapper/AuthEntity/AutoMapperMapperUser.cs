using AutoMapper;
using Persist.Entities;
using Services.Models.Auth;
public partial class MappingProfile : Profile
{
    public void MappingProfileUser()
    {
        CreateMap<UserSignUp, UserEntity>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid().ToString()))
            .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.UtcNow))
            .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore())
            .ForMember(dest => dest.HashPasswordEntity, opt => opt.MapFrom((src, dest) =>
                {
                    var hashPasswordId = Guid.NewGuid().ToString(); // Génération d'un seul identifiant
                    dest.HashPasswordId = hashPasswordId;
                    return new HashPasswordEntity
                    {
                        Id = hashPasswordId, // Assignation de l'ID à l'entité HashPasswordEntity
                        Password = _securityService.Hash(src.Password),
                        CreatedAt = DateTime.UtcNow
                    };
                }
            ));
    }
}