namespace Test;

using AutoMapper;

using Microsoft.Extensions.Logging;

using Persist.Entities.Application;
using Persist.Entities.BaseTable;

using Services.Models.Req;

using Xunit;

public class CustommerAutoMapTest
{
    private readonly IMapper _mapper;
    private readonly ILoggerFactory _loggerFactoryMock;
    public CustommerAutoMapTest()
    {
        _loggerFactoryMock = new LoggerFactory();
        var config = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>(), _loggerFactoryMock);
        _mapper = config.CreateMapper();
    }

    [Fact]
    public void CreateCustomerRequest_should_generate_Id()
    {
        // Arrange
        var CreateCustomerRequest = new CreateCustomerRequest()
        {
            Title = "Discord",
            FiscalIdentification = "42829692500160",
            LastInteraction = new DateTime()
        };
        Guid x;
        // Act
        var CustomerEntity = _mapper.Map<CustomerEntity>(CreateCustomerRequest);
        // Assert
        Assert.True(Guid.TryParse(CustomerEntity.Id, out x));
    }

    [Fact]
    public void CreateApplicationRequest_should_generate_CreatedAt()
    {
        // Arrange
        var CreateCustomerRequest = new CreateCustomerRequest()
        {
            Title = "Discord",
            FiscalIdentification = "42829692500160",
            LastInteraction = new DateTime()
        };
        DateTime y;
        // Act
        var CustomerEntity = _mapper.Map<CustomerEntity>(CreateCustomerRequest);
        // Assert
        Assert.True(DateTime.TryParse(CustomerEntity.CreatedAt.ToString(), out y));
    }

    [Fact]
    public void CreateCustomerRequest_should_generate_CreatedAt()
    {
        // Arrange
        var CreateCustomerRequest = new CreateCustomerRequest()
        {
            Title = "Cegid",
            FiscalIdentification = "42829692500160",
            LastInteraction = new DateTime()
        };
        // Act & assert
        Assert.Throws<AutoMapperMappingException>(() => _mapper.Map<ApplicationEntity>(CreateCustomerRequest));
    }
}
