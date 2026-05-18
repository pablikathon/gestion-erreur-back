namespace Test;

using AutoMapper;

using Microsoft.Extensions.Logging;

using Persist.Entities.Application;
using Persist.Entities.BaseTable;


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


}
