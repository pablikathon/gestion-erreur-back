using AutoMapper;
using Microsoft.Extensions.Configuration;
using Services;
using Services.Models.Auth;

public partial class MappingProfile : Profile
{
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