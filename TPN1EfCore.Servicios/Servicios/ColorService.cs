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
    public class ColorService:IColorService
    {
        private readonly IColorRepository _colorRepository;
        private readonly IUnitOfWork _unitOfWork;
        public ColorService(IColorRepository colorRepository, IUnitOfWork unitOfWork)
        {
            _colorRepository = colorRepository;
            _unitOfWork = unitOfWork;
        }

        public void Borrar(Colour Colour)
        {
            try
            {
                _unitOfWork.BeginTransaction();
                _colorRepository.Borrar(Colour);
                _unitOfWork.Commit();
            }
            catch (Exception)
            {
                _unitOfWork?.Rollback();
                throw;
            }
        }

        public bool EstaRelacionado(Colour Colour)
        {
            return _colorRepository.EstaRelacionado(Colour);
        }

        public bool Existe(Colour Colour)
        {
            return _colorRepository.Existe(Colour);
        }

        public int GetCantidad()
        {
            return _colorRepository.GetCantidad();
        }

        public Colour? GetColourPorId(int ColourId)
        {
            return _colorRepository.GetColourPorId(ColourId);
        }

        public Colour? GetColourPorNombre(string ColourName)
        {
            return _colorRepository.GetColourPorNombre(ColourName);
        }

        public List<Colour>? GetColours()
        {
            return _colorRepository.GetColours();
        }

        public void Guardar(Colour Colour)
        {
            try
            {
                _unitOfWork.BeginTransaction();
                if (Colour.ColourId==0)
                {
                    _colorRepository.Agregar(Colour);
                }
                else
                {
                    _colorRepository.Editar(Colour);
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
