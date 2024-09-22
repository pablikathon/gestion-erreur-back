using Services.Models.Common;
using System.Linq.Expressions;
using System.Reflection;
using exception.Message;
using exception;

namespace Services.Extension;
public static class PaginationExtension
{
    public static IQueryable<T> Pagination<T>(this IQueryable<T> query, PaginationParameters paginationParameters)
        where T : class
    {
        if (paginationParameters.PageNumber.GetHashCode() != 0)
        {
            query = query
                .Skip((paginationParameters.PageNumber - 1) * paginationParameters.PageSize)
                .Take(paginationParameters.PageSize);
        }

        return query;
    }

    public static IQueryable<T> DateSearchQuery<T>(this IQueryable<T> query, DateParameters DateParam)
        where T : DateEntity
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
                throw new FieldNotFoundException($"'{NotFoundMessage.FieldNotFound}' : '{DateParam.DateField}'" );
        }

        return query;
    }

    public static IQueryable<T> SortBy<T>(this IQueryable<T> source, SortParameters sort) where T : class
    {
        if (string.IsNullOrWhiteSpace(sort.SortBy))
            throw new ArgumentNullException(nameof(sort.SortBy));
        
        BuildProperty<T>(sort.SortBy, out Type entityType, out Expression propertyAccess, out LambdaExpression lambdaExpression);

        var methodName = sort.Ascending ? nameof(Queryable.OrderBy) : nameof(Queryable.OrderByDescending);
        var method = typeof(Queryable).GetMethods()
            .First(m => m.Name == methodName && m.GetParameters().Length == 2);
        var genericMethod = method.MakeGenericMethod(entityType, propertyAccess.Type);
        return (IQueryable<T>)genericMethod.Invoke(null, new object[] { source, lambdaExpression })!;
    }

    private static void BuildProperty<T>(string PropertyToBuild, out Type entityType, out Expression propertyAccess, out LambdaExpression lambdaExpression) where T : class
    {
        //Could be Title or Server.Title
        if (string.IsNullOrWhiteSpace(PropertyToBuild))
            throw new ArgumentNullException(nameof(PropertyToBuild));

        var sortBy = PropertyToBuild.Split('.');
        entityType = typeof(T);
        var parameter = Expression.Parameter(entityType, "x");

        propertyAccess = parameter;
        Type currentType = entityType;
        foreach (string propertyName in sortBy)
        {
            var property = currentType.GetProperty(propertyName, BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase)
            ??
            throw new ArgumentException(
                $"'{NotFoundMessage.FieldNotFound}' '{currentType.Name}'"
            );
            propertyAccess = Expression.MakeMemberAccess(propertyAccess, property);
            currentType = property.PropertyType;
        }
        lambdaExpression = Expression.Lambda(propertyAccess, parameter);
    }

    public static IQueryable<T> TextSearch<T>(this IQueryable<T> source, SearchParameters searchParameters) where T : class
    {
        if (string.IsNullOrWhiteSpace(searchParameters.SearchColumn))
            throw new ArgumentNullException(nameof(searchParameters.SearchColumn));
        if (string.IsNullOrWhiteSpace(searchParameters.SearchTerm))
            throw new ArgumentNullException(nameof(searchParameters.SearchTerm));

        BuildProperty<T>(searchParameters.SearchColumn, out Type entityType, out Expression propertyAccess, out LambdaExpression lambdaExpression);

        if (propertyAccess.Type != typeof(string))
            throw new ArgumentException($"'{TypoMessage.PropertyMustBeString}' : '{searchParameters.SearchColumn}'");

        var toLowerMethod = typeof(string).GetMethod(nameof(String.ToLower), Type.EmptyTypes) ?? throw new InvalidOperationException( $"'{NotFoundMessage.MethodNotFound}' :  '{nameof(String.ToLower)}' ");;            
        var containsMethod = typeof(string).GetMethod(nameof(String.Contains), new[] { typeof(string) }) ?? throw new InvalidOperationException($" '{NotFoundMessage.MethodNotFound}' : '{nameof(String.Contains)} ");;
            

        var toLowerExpression = Expression.Call(propertyAccess, toLowerMethod);
        var searchExpression = Expression.Constant(searchParameters.SearchTerm.ToLower());

        var containsExpression = Expression.Call(toLowerExpression, containsMethod, searchExpression);

        // x => x.Property.ToLower().Contains(searchTerm.ToLower())
        var lambda = Expression.Lambda<Func<T, bool>>(containsExpression, lambdaExpression.Parameters[0]);
        return source.Where(lambda);
    }
}