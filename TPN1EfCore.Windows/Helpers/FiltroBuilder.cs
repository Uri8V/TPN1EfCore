using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TPN1EfCore.Entidades;

namespace TPN1EfCore.Windows.Helpers
{
    public static class FiltroBuilder
    {
        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second)
        {
            var parameter = Expression.Parameter(typeof(T), "x");

            var body = Expression.AndAlso(
                Expression.Invoke(first, parameter),
                Expression.Invoke(second, parameter)
            );

            return Expression.Lambda<Func<T, bool>>(body, parameter);
        }
        public static Expression<Func<T, bool>> CombineFilters<T>(this List<Expression<Func<T, bool>>> filters)
        {
            if (filters == null || filters.Count == 0)
                return x => true;

            var combinedFilter = filters[0];

            for (int i = 1; i < filters.Count; i++)
            {
                combinedFilter = combinedFilter.And(filters[i]);
            }

            return combinedFilter;
        }
    }
}
