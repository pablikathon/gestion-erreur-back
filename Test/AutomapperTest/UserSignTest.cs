namespace Test;

using AutoMapper;
using Persist.Entities;
using Services.Models.Auth;
using Services.Models.Req;
using Xunit;

public class UserSignAutoMapTest
{
    private readonly IMapper _mapper;

    public UserSignAutoMapTest()
    {
        var config = new MapperConfiguration(cfg => cfg.AddProfile<MappingProfile>());
        _mapper = config.CreateMapper();
    }

    [Fact]
    public void SignUp_should_generate_hasPassword()
    {
        // Arrange
        var UserSignUp = new UserSignUp()
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