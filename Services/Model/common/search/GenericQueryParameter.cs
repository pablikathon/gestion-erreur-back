namespace Services.Models.Common;

public class GenericQueryParameter
{
    public DateParameters DateParam { get; set; } = new();
    public PaginationParameters Pagination { get; set; } = new();
}