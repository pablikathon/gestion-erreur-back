
namespace Domain.DTO.Applications
{
    public class ApplicationDeployed
    {
        public Guid Id { get; set; }

        public Guid ApplicationId { get; set; }
        public Guid ServerId { get; set; }

        public string Version { get; set; }
        public string Environment { get; set; }
        public DateTime DeployedAt { get; set; }
        public string Status { get; set; }

        public ApplicationDeployed()
        {
            Id = Guid.NewGuid();
            DeployedAt = DateTime.UtcNow;
            Version = string.Empty;
            Environment = string.Empty;
            Status = "Pending";
        }

        public ApplicationDeployed(Guid applicationId, Guid serverId, string version, string environment, string status = "Success") : this()
        {
            ApplicationId = applicationId;
            ServerId = serverId;
            Version = version ?? string.Empty;
            Environment = environment ?? string.Empty;
            Status = status ?? "Success";
            DeployedAt = DateTime.UtcNow;
        }
    }
}
