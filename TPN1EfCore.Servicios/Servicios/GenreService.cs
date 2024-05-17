using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPN1EfCore.Datos;
using TPN1EfCore.Datos.Interfaces;
using TPN1EfCore.Entidades;
using TPN1EfCore.Servicios.Interfaces;

namespace TPN1EfCore.Servicios.Servicios
{
    public class GenreService:IGenreService
    {
        private readonly IGenreRepository _genreRepository;
        private readonly IUnitOfWork _unitOfWork;
        public GenreService(IGenreRepository genreRepository, IUnitOfWork unitOfWork )
        {
            _genreRepository = genreRepository;
            _unitOfWork = unitOfWork;
        }

        public void Borrar(Genre genre)
        {
            try
            {
                _unitOfWork.BeginTransaction();
                _genreRepository?.Borrar(genre);
                _unitOfWork.Commit();
            }
            catch (Exception)
            {
                _unitOfWork?.Rollback();
                throw;
            }
        }

        public bool EstaRelacionado(Genre genre)
        {
            return _genreRepository.EstaRelacionado(genre);
        }

        public bool Existe(Genre genre)
        {
            return _genreRepository.Existe(genre);
        }

        public int GetCantidad()
        {
            return _genreRepository.GetCantidad();
        }

        public Genre? GetGenrePorId(int GenreId)
        {
            return _genreRepository.GetGenrePorId(GenreId);
        }

        public Genre? GetGenrePorNombre(string GenreName)
        {
            return _genreRepository.GetGenrePorNombre(GenreName);
        }

        public List<Genre>? GetGenres()
        {
            return _genreRepository.GetGenres();
        }

        public void Guardar(Genre genre)
        {
            try
            {
                _unitOfWork.BeginTransaction();
                if (genre.GenreId==0)
                {
                    _genreRepository.Agregar(genre);
                }
                else
                {
                    _genreRepository.Editar(genre);
                }
                _unitOfWork.Commit();   
            }
            catch (Exception)
            {
                _unitOfWork.Rollback();
                throw;
            }
        }
    }
}
