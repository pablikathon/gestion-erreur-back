namespace Test;
using AutoMapper;
using Persist.Entities;
using Services.Models.Req;
using Xunit;

public class CustommerAutoMapTest
{
    private readonly IMapper _mapper;

    public CustommerAutoMapTest()
    {
        var config = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());
        _mapper = config.CreateMapper();
    }
    [Fact]
    public void CreateCustomerRequest_should_generate_Id()
    {
        // Arrange
        var CreateCustomerRequest = new CreateCustomerRequest()
        {
            Title = "Discord"
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
            Title = "Discord"
        };
        DateTime y;
        // Act
        var CustomerEntity = _mapper.Map<CustomerEntity>(CreateCustomerRequest);
        // Assert
        Assert.True(DateTime.TryParse(CustomerEntity.CreatedAt.ToString(),out y));
    }
    [Fact]
    public void canNotMap_customer_On_Application()
    {
        // Arrange
        var CreateCustomerRequest = new CreateCustomerRequest()
        {
            Title = "Cegid"
        };
        // Act & assert
        Assert.Throws<AutoMapperMappingException>(() => _mapper.Map<ApplicationEntity>(CreateCustomerRequest));
    }

}