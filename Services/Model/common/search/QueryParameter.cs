namespace Services.Models.Common;

public class QueryParameters
{
    public DateParameters DateParam { get; set; } = new();
    public SearchParameters? SearchParam { get; set; }

    public PaginationParameters Pagination { get; set; } = new();
    public SortParameters Sort { get; set; } = new();
}