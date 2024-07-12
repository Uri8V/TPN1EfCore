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
        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second) // Combina 2 expresiones lambda en una sola expresion
        {
            var parameter = Expression.Parameter(typeof(T), "x"); //define un parametro de tipo T al cual se le aplicara el filtro (En este caso Shoe)

            var body = Expression.AndAlso(// Esto es como la expresión lógica AND 
                Expression.Invoke(first, parameter),
                Expression.Invoke(second, parameter)
            ); // Esto combina las 2 expresiones 

            return Expression.Lambda<Func<T, bool>>(body, parameter);//construye una nueva expresión lambda a partir del cuerpo (body) y el parámetro definido.
        }
        public static Expression<Func<T, bool>> CombineFilters<T>(this List<Expression<Func<T, bool>>> filters) //El método CombineFilters<T> se utiliza para
                                                                                                                //agregar las expresiones a la lista,
                                                                                                                //nos fijamos si la lista tiene datos,
                                                                                                                //definimos una variable a la cual le agregamos
                                                                                                                //la primer expresión lambda y si hay más de uno
                                                                                                                //se lo agregamos con el método And<T>
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
