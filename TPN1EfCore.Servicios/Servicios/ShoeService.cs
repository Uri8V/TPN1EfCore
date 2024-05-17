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
    public class ShoeService:IShoeService
    {
        private readonly IShoeRepository _shoeRepository;
        private readonly IUnitOfWork _unitOfWork;
        public ShoeService(IShoeRepository shoeRepository, IUnitOfWork unitOfWork)
        {
            _shoeRepository = shoeRepository;
            _unitOfWork = unitOfWork;
        }

        public void Borrar(Shoe Shoe)
        {
            try
            {
                _unitOfWork.BeginTransaction();
                _shoeRepository.Borrar(Shoe);
                _unitOfWork.Commit();
            }
            catch (Exception)
            {
                _unitOfWork.Rollback();
                throw;
            }
        }

        public bool Existe(Shoe Shoe)
        {
           return _shoeRepository.Existe(Shoe);
        }

        public int GetCantidad()
        {
            return _shoeRepository.GetCantidad();
        }

        public List<Shoe> GetShoePorBrand(int brandId)
        {
            return _shoeRepository.GetShoePorBrand(brandId);
        }

        public List<Shoe> GetShoePorColor(int colorId)
        {
            return _shoeRepository.GetShoePorColor(colorId);
        }

        public List<Shoe> GetShoePorGenre(int genreId)
        {
            return _shoeRepository.GetShoePorGenre(genreId);
        }

        public Shoe? GetShoePorId(int ShoeId)
        {
           return _shoeRepository.GetShoePorId(ShoeId);    
        }

        public List<Shoe> GetShoePorSport(int sportId)
        {
            return _shoeRepository.GetShoePorSport(sportId);
        }

        public List<Shoe> GetShoes()
        {
            return _shoeRepository.GetShoes();
        }

        public void Guardar(Shoe Shoe)
        {
            try
            {
                _unitOfWork.BeginTransaction();
                if (Shoe.ShoeId==0)
                {
                    _shoeRepository.Agregar(Shoe);
                }
                else
                {
                    _shoeRepository.Editar(Shoe);
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
