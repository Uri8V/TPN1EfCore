using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPN1EfCore.Datos.Interfaces;
using TPN1EfCore.Entidades;

namespace TPN1EfCore.Datos.Repositories
{
    public class ShoeSizeRepository : IShoeSizeRepository
    {
        private readonly ShoesDbContext? _context;
        public ShoeSizeRepository(ShoesDbContext? context) 
        {
            _context = context;
        }
        public int GetId()
        {
            return _context.ShoeSizes.ToList().Count()+1;
        }
    }
}
