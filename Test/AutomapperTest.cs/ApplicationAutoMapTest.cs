namespace Test;
using AutoMapper;
using Persist.Entities;
using Services.Models.Req;
using Xunit;

public class ApplicationAutoMapTest
{
    private readonly IMapper _mapper;

    public ApplicationAutoMapTest()
    {
        var config = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());
        _mapper = config.CreateMapper();
    }
    [Fact]
    public void CreateApplicationRequest_should_generate_Id()
    {
        // Arrange
        var CreateApplicationRequest = new CreateApplicationRequest()
        {
            Title = "Discord"
        };
        Guid x;
        // Act
        var ApplicationEntity = _mapper.Map<ApplicationEntity>(CreateApplicationRequest);
        // Assert
        Assert.True(Guid.TryParse(ApplicationEntity.Id, out x));
    }
    [Fact]
    public void CreateApplicationRequest_should_generate_CreatedAt()
    {
        // Arrange
        var CreateApplicationRequest = new CreateApplicationRequest()
        {
            Title = "Discord"
        };
        DateTime y;
        // Act
        var ApplicationEntity = _mapper.Map<ApplicationEntity>(CreateApplicationRequest);
        // Assert
        Assert.True(DateTime.TryParse(ApplicationEntity.CreatedAt.ToString(),out y));
    }

}