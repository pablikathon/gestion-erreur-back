using AutoMapper;
using Persist.Entities;
using Services;
using Services.Models.Auth;
using Services.Models.Req;

public partial class MappingProfile : Profile
{
    private readonly PasswordHasherService  _passwordHasherService = new();
    public MappingProfile()
    {
        
        this.MappingProfilRegularEntity();
        this.MappingProfilJoiningEnity();
        this.MappingProfileAuthEntity();
    }

    public void MappingProfilRegularEntity()
    {
        this.MappingProfileServer();
        this.MappingProfileCustomer();
        this.MappingProfileApplication();
        this.MappingProfileError();
    }

    public void MappingProfilJoiningEnity()
    {
        this.MappingProfileApplicationDeployement();
        this.MappingProfileCustomerHaveLicence();
    }
    public void MappingProfileAuthEntity(){
        this.MappingProfileUser();
    }
}