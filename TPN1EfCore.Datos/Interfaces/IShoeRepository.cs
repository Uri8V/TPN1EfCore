using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPN1EfCore.Entidades;

namespace TPN1EfCore.Datos.Interfaces
{
    public interface IShoeRepository
    {
        void Agregar (Shoe shoe);
        void Borrar(Shoe Shoe);
        void Editar(Shoe Shoe);
        bool Existe(Shoe Shoe);
        int GetCantidad();
        List<Shoe> GetShoePorBrand(int brandId);
        List<Shoe> GetShoePorColor(int colorId);
        List<Shoe> GetShoePorGenre(int genreId);
        List<Shoe> GetShoePorSport(int sportId);
        List<Shoe> GetShoes();
        Shoe? GetShoePorId(int ShoeId);
    }
}
