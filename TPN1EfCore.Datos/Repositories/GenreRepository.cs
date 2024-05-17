using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TPN1EfCore.Datos.Interfaces;
using TPN1EfCore.Entidades;

namespace TPN1EfCore.Datos.Repositories
{
    public class GenreRepository:IGenreRepository
    {
        private readonly ShoesDbContext _context;
        public GenreRepository(ShoesDbContext context)
        {
            _context = context;
        }

        public void Agregar(Genre genre)
        {
            _context.Genres.Add(genre);
        }

        public void Borrar(Genre genre)
        {
            _context.Genres.Remove(genre);
        }

        public void Editar(Genre genre)
        {
           _context.Genres.Update(genre);
        }

        public bool EstaRelacionado(Genre genre)
        {
            return _context.Shoes.Any(g => g.GenreId == genre.GenreId);
        }

        public bool Existe(Genre genre)
        {
            if (genre.GenreId == 0)
            {
                return _context.Genres.Any(g=>g.GenreName == genre.GenreName);
            }
            return _context.Genres.Any(g => g.GenreName == genre.GenreName && g.GenreId == genre.GenreId);

        }

        public int GetCantidad()
        {
            return _context.Genres.Count();
        }

        public Genre? GetGenrePorId(int GenreId)
        {
            return _context.Genres.FirstOrDefault(g=>g.GenreId==GenreId);
        }

        public Genre? GetGenrePorNombre(string GenreName)
        {
            return _context.Genres.FirstOrDefault(g=>g.GenreName == GenreName);
        }

        public List<Genre>? GetGenres()
        {
            return _context.Genres.OrderBy(g =>g.GenreName).AsNoTracking().ToList();
        }
    }
}
