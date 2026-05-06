namespace Test;

using AutoMapper;

using Microsoft.Extensions.Logging;

using Persist.Entities.Application;
using Persist.Entities.BaseTable;

using Services.Models.Req;

using Xunit;

public class ApplicationAutoMapTest
{
    private readonly IMapper _mapper;
    private readonly ILoggerFactory _loggerFactoryMock;
    public ApplicationAutoMapTest()
    {
        _loggerFactoryMock = new LoggerFactory();
        var config = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>(), _loggerFactoryMock);
        _mapper = config.CreateMapper();
    }

    [Fact]
    public void CreateApplicationRequest_should_generate_Id()
    {
        // Arrange
        var CreateApplicationRequest = new CreateApplicationRequest()
        {
            Title = "Discord",
            Description = "Les cocinnelles sont des coléoptères"
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
            Title = "Discord",
            Description = "Les cocinnelles sont des coléoptères"
        };
        DateTime y;
        // Act
        var ApplicationEntity = _mapper.Map<ApplicationEntity>(CreateApplicationRequest);
        // Assert
        Assert.True(DateTime.TryParse(ApplicationEntity.CreatedAt.ToString(), out y));
    }

    [Fact]
    public void canNotMap_CreateApplication_On_customer()
    {
        // Arrange
        var CreateApplicationRequest = new CreateApplicationRequest()
        {
            Title = "Cegid",
            Description = "Les cocinnelles sont des coléoptères"
        };
        // Act & assert
        Assert.Throws<AutoMapperMappingException>(() => _mapper.Map<CustomerEntity>(CreateApplicationRequest));
    }

    [Fact]
    public void canNotMap_UpdateApplicationRequest_On_customer()
    {
        // Arrange
        var UpdateApplicationRequest = new UpdateApplicationRequest()
        {
            Title = "Cegid",
            Id = Guid.NewGuid().ToString()
        };
        // Act & assert
        Assert.Throws<AutoMapperMappingException>(() => _mapper.Map<CustomerEntity>(UpdateApplicationRequest));
    }
}
