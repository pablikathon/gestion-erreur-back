namespace Services.Models.Common;

public class QueryParameters
{

    public DateParameters? DateParam { get; set; }
    public SearchParameters?  SearchParam { get; set;}

    public PaginationParameters Pagination { get; set; } = new PaginationParameters();
    public SortParameters Sort { get; set; } = new SortParameters();
}