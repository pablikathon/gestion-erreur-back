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
}