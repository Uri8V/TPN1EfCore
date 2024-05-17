using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPN1EfCore.Entidades;

namespace TPN1EfCore.Datos.Interfaces
{
    public interface IGenreRepository
    {
        void Agregar(Genre genre);
        void Borrar(Genre genre);
        void Editar(Genre genre);
        bool EstaRelacionado(Genre genre);
        bool Existe(Genre genre);
        int GetCantidad();
        Genre? GetGenrePorNombre(string GenreName);
        List<Genre>? GetGenres();
        Genre? GetGenrePorId(int GenreId);
    }
}
