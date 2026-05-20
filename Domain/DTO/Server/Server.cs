namespace Domain.Servers;

using Domain.Applications;
public class Server
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public List<Application> ApplicationDeployed { get; private set; }
    public Server(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new Exception("Server name is required");
        }

        Id = Guid.NewGuid();
        Name = name;
        ApplicationDeployed = [];
    }
}