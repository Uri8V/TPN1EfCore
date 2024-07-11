using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPN1EfCore.Datos.Interfaces;
using TPN1EfCore.Datos;
using TPN1EfCore.Entidades;
using TPN1EfCore.Servicios.Interfaces;
using TPN1EfCore.Entidades.DTO;

namespace TPN1EfCore.Servicios.Servicios
{
    public class SizeService : ISizeService
    {
        private readonly ISizeRepository _sizeRepository;
        private readonly IUnitOfWork _unitOfWork;
        public SizeService(ISizeRepository sizeRepository, IUnitOfWork unitOfWork)
        {
            _sizeRepository = sizeRepository;
            _unitOfWork = unitOfWork;
        }

        public List<ShoeListDto> GetShoePorSize(Size size)
        {
           return _sizeRepository.GetShoePoSize(size);
        }

        public Size? GetSizePorDecimal(decimal sizenumber)
        {
            return _sizeRepository.GetSizePorDecimal(sizenumber);
        }

        public Size? GetSizePorId(int id, bool incluyeShoe = false)
        {
            return _sizeRepository.GetSizePorId(id, incluyeShoe);
        }

        public List<Size> GetSizes()
        {
            return _sizeRepository.GetSizes();
        }

    }
}
