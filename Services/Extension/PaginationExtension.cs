using Services.Models.Common;

public static class PaginationExtension
{
    public  static IQueryable<T> Pagination<T> (this IQueryable<T> query ,PaginationParameters paginationParameters)  where T : class
    {
        if (paginationParameters.PageNumber.GetHashCode() != 0)
        {
            query = query
                .Skip((paginationParameters.PageNumber - 1) * paginationParameters.PageSize)
                .Take(paginationParameters.PageSize);
        }
        return query;
    }
}