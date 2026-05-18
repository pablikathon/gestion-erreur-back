namespace Test;

using AutoMapper;

using Microsoft.Extensions.Logging;

using Persist.Entities.Auth;

using Services.Models.Auth;
using Services.Models.Command;

using Xunit;

public class UserSignAutoMapTest
{
    private readonly IMapper _mapper;
    private readonly ILoggerFactory _loggerFactoryMock;
    public UserSignAutoMapTest()
    {
        _loggerFactoryMock = new LoggerFactory();

        var config = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>(), _loggerFactoryMock);
        _mapper = config.CreateMapper();
    }

    [Fact]
    public void SignUp_should_generate_hasPassword()
    {
        // Arrange
        var UserSignUp = new UserSignUpCommand()
        {
            FirstName = "Edouard",
            LastName = "Philipe",
            Email = "EdouardPhilipe@gmail.com",
            Password = "LongDuZboob69ùù%"

        };
        Guid x;

        // Act
        var ApplicationEntity = _mapper.Map<UserEntity>(UserSignUp);
        // Assert
        Assert.True(Guid.TryParse(ApplicationEntity.Id, out x));
    }


}
