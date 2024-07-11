using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPN1EfCore.Entidades;
using TPN1EfCore.Entidades.DTO;

namespace TPN1EfCore.Datos.Interfaces
{
    public interface ISizeRepository
    {
        List<Size> GetSizes();
        Size? GetSizePorId(int id, bool incluyeShoe = false);
        void AgregarSizeShoe(ShoeSizes nuevarelacion);
        Size? GetSizePorDecimal(decimal sizenumber);
        List<ShoeListDto> GetShoePoSize(Size size);
    }
}
