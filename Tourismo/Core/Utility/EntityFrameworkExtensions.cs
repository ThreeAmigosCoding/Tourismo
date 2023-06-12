using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Reflection;
using Tourismo.Core.Model.TravelManagement;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

public static class EntityFrameworkExtensions
{
    public static IQueryable<T> IncludeAll<T>(this IQueryable<T> query) where T : class
    {
        var entityType = typeof(T);
        var properties = entityType.GetProperties(BindingFlags.Public | BindingFlags.Instance)
            .Where(p => p.PropertyType.IsClass && p.PropertyType != typeof(string));

        foreach (var property in properties)
        {
            if (property.Name != nameof(Travel.SoonestPeriod))
            {
                query = query.Include(property.Name);
            }
        }

        return query;
    }

}

