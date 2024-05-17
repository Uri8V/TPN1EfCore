using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPN1EfCore.Entidades;

namespace TPN1EfCore.Servicios.Interfaces
{
    public interface IGenreService
    {
        void Borrar(Genre genre);
        void Guardar(Genre genre);
        bool EstaRelacionado(Genre genre);
        bool Existe(Genre genre);
        int GetCantidad();
        Genre? GetGenrePorNombre(string GenreName);
        List<Genre>? GetGenres();
        Genre? GetGenrePorId(int GenreId);
    }
}
