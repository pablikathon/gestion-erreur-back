    namespace Services.Models.Common;

    public class QueryParameters
    {
        public string? SearchTerm { get; set; }
        public string? SearchColumn { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public string? DateField { get; set; }
        public PaginationParameters Pagination { get; set; } = new PaginationParameters();
        public SortParameters Sort { get; set; } = new SortParameters();
    }