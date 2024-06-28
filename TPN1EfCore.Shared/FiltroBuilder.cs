using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPN1EfCore.Entidades;

namespace TPN1EfCore.Windows.Helpers
{
    public static class FiltroBuilder
    {
        public static Func<Shoe, bool> And(this Func<Shoe, bool> first, Func<Shoe, bool> second)
        {
            return filtro=> first(filtro) && second(filtro);
        } 
        public static Func<Shoe, bool> Not(this Func<Shoe, bool> filtro)
        {
            return filter => !filtro(filter);
        }
    }
}
