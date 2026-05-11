using AutoMapper;

using Presentation.Models.Req;

using Services.Models.Command;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateApplicationRequest, CreateApplicationCommand>();
        CreateMap<UpdateApplicationRequest, UpdateApplicationCommand>();
        CreateMap<CreateApplicationRequest, CreateApplicationCommand>();
        CreateMap<UpdateApplicationRequest, UpdateApplicationCommand>();
        CreateMap<CreateServerRequest, CreateServerCommand>();
        CreateMap<UpdateServerRequest, UpdateServerCommand>();
        CreateMap<CreateTagRequest, CreateTagCommand>();
        CreateMap<UpdateTagRequest, UpdateTagCommand>();
        CreateMap<CreateTagCategoryRequest, CreateTagCategoryCommand>();


    }
}