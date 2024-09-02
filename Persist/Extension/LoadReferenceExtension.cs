using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

public static class DbContextExtensions
{
    public static async Task LoadReferencesAsync<T>(this DbContext context, T entity,
        params Expression<Func<T, object>>[] includes) where T : class
    {
        foreach (var include in includes)
        {
            await context.Entry(entity).Reference(include).LoadAsync();
        }
    }
}