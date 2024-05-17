using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPN1EfCore.Entidades;

namespace TPN1EfCore.Servicios.Interfaces
{
    public interface IBrandService
    {
        void Guardar(Brand brand);
        void Borrar(Brand brand);
        bool EstaRelacionado(Brand brand);
        bool Existe(Brand brand);
        int GetCantidad();
        Brand? GetBrandPorNombre(string BrandName);
        List<Brand>? GetBrands();
        Brand? GetBrandPorId(int BrandId);
    }
}
