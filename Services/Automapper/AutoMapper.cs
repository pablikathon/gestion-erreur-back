using AutoMapper;
using Persist.Entities;
using Services.Models.Req;

public partial class MappingProfile : Profile
{
    public MappingProfile()
    {

        this.MappingProfilRegularEntity();
        this.MappingProfilJoiningEnity();

    }
    public void MappingProfilRegularEntity(){
        this.MappingProfileServer();
        this.MappingProfileCustomer();
        this.MappingProfileApplication();
        this.MappingProfileError();
    }
    public void MappingProfilJoiningEnity(){
        this.MappingProfileApplicationDeployement();
        this.MappingProfileCustomerHaveLicence();

    }
}