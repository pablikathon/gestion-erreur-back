using Services.Models.Common;

public static class PaginationExtension
{
    public static IQueryable<T> Pagination<T>(this IQueryable<T> query, PaginationParameters paginationParameters) where T : class
    {
        if (paginationParameters.PageNumber.GetHashCode() != 0)
        {
            query = query
                .Skip((paginationParameters.PageNumber - 1) * paginationParameters.PageSize)
                .Take(paginationParameters.PageSize);
        }
        return query;
    }
    public static IQueryable<T> DateSearchQuery<T>(this IQueryable<T> query, DateParameters DateParam) where T : DateEntity
    {
        switch (DateParam.DateField)
        {
            case nameof(DateEntity.CreatedAt):
                query = query.Where(a =>
                a.CreatedAt >= DateParam.StartDate && a.CreatedAt <= DateParam.EndDate);
                break;
            case nameof(DateEntity.UpdatedAt):
                query = query.Where(a =>
                a.UpdatedAt >= DateParam.StartDate && a.UpdatedAt <= DateParam.EndDate);
                break;
            default:
                throw new ArgumentException("Bad column date name");
        }
        return query;
    }

}