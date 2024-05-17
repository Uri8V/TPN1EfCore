using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPN1EfCore.Entidades;

namespace TPN1EfCore.Datos.Interfaces
{
    public interface IColorRepository
    {
        void Agregar(Colour Colour);
        void Borrar(Colour Colour);
        void Editar(Colour Colour);
        bool EstaRelacionado(Colour Colour);
        bool Existe(Colour Colour);
        int GetCantidad();
        Colour? GetColourPorNombre(string ColourName);
        List<Colour>? GetColours();
        Colour? GetColourPorId(int ColourId);
    }
}
