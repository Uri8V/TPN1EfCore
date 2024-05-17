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
    public class BrandService : IBrandService
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IUnitOfWork _unitOfWork;
        public BrandService(IBrandRepository brandRepository, IUnitOfWork unitOfWork)
        {
            _brandRepository = brandRepository;
            _unitOfWork = unitOfWork;
        }

        public void Borrar(Brand brand)
        {
            try
            {
                _unitOfWork.BeginTransaction();
                _brandRepository.Borrar(brand);
                _unitOfWork.Commit();
            }
            catch (Exception)
            {
                _unitOfWork.Rollback();
                throw;
            }
        }

        public bool EstaRelacionado(Brand brand)
        {
            return _brandRepository.EstaRelacionado(brand);
        }

        public bool Existe(Brand brand)
        {
            return _brandRepository.Existe(brand);
        }

        public Brand? GetBrandPorId(int BrandId)
        {
            return _brandRepository.GetBrandPorId(BrandId);
        }

        public Brand? GetBrandPorNombre(string BrandName)
        {
            return _brandRepository.GetBrandPorNombre(BrandName);
        }

        public List<Brand>? GetBrands()
        {
           return _brandRepository.GetBrands();
        }

        public int GetCantidad()
        {
            return _brandRepository.GetCantidad();
        }

        public void Guardar(Brand brand)
        {
            try
            {
                _unitOfWork.BeginTransaction();
                if (brand.BrandId == 0)
                {
                    _brandRepository.Agregar(brand);
                }
                else
                {
                    _brandRepository.Editar(brand);
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
