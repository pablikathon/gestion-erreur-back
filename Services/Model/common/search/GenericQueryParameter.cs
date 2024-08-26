namespace Services.Models.Common;

public class GenericQueryParameter
{
    public DateParameters  DateParam { get; set; } = new DateParameters();
    public PaginationParameters Pagination { get; set; } = new PaginationParameters();
}