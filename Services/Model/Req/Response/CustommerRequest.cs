using Persist.Entities;

namespace Services.Models.Req
{
    public class ErrorForCustommerStatsResponse
    {
        public required string custommerId { get; set; }
        public required string CustommerTitle { get; set; }
        public required string CustomerFiscalIdentification { get; set; }
        public required int nberrorSolved { get; set; }
        public required int nbErrorUnresolved { get; set; }
    }
    public class ErrorForACustommerStatsResponse
    {
        public required int Nberror { get; set; }
        public required ErrorStatusEntity Status { get; set; }
        public required SeverityLevelEntity Severity { get; set; }
        public required ServerEntity Server { get; set; }
        public required DateTime CreatedAt { get; set; }


    }
}