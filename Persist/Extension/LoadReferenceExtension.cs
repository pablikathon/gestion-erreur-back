using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

public static class DbContextExtensions
{
    public static async Task LoadReferencesAsync<T>(this DbContext context, T entity,
        params Expression<Func<T, object?>>[] includes) where T : class
    {
        foreach (var include in includes)
        {
            if (include != null)
                await context.Entry(entity).Reference(include).LoadAsync();
        }
    }
}