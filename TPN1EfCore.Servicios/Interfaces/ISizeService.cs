using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPN1EfCore.Entidades;
using TPN1EfCore.Entidades.DTO;

namespace TPN1EfCore.Servicios.Interfaces
{
    public interface ISizeService
    {
        List<Size> GetSizes();
        Size? GetSizePorId(int id, bool incluyeShoe = false);
        Size? GetSizePorDecimal(decimal sizenumber);
        List<ShoeListDto> GetShoePorSize(Size size);

    }
}
