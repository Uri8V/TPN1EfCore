using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPN1EfCore.Datos.Interfaces;
using TPN1EfCore.Entidades;

namespace TPN1EfCore.Datos.Repositories
{
    public class SizeRepository : ISizeRepository
    {
        private readonly ShoesDbContext context;
        public SizeRepository(ShoesDbContext _context)
        {
            context = _context;
        }

        public void AgregarSizeShoe(ShoeSizes nuevarelacion)
        {
            context.Set<ShoeSizes>().Add(nuevarelacion); 
        }

        public Size? GetSizePorId(int id, bool incluyeShoe = false)
        {   //El id que esta como parametro es de Size
            var query = context.Sizes;
            if (incluyeShoe)//Indica si debemos incluir los Shoes asociados a este Size
            {
                return query.Include(s=>s.ShoeSize)
                    .ThenInclude(ss=>ss.Shoe)//Con este permito que me traiga los datos de los Shoes
                    .FirstOrDefault(s=>s.SizeId==id);//Este me trae el Size y los Shoes que tiene relacionados
            }
            return query.FirstOrDefault(s=>s.SizeId==id);//Este me trae el Size que y le pido
        }

        public List<Size> GetSizes()
        {
            return context.Sizes.ToList();
        }
    }
}
