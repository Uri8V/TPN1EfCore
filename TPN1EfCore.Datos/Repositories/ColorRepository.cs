using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPN1EfCore.Datos.Interfaces;
using TPN1EfCore.Entidades;

namespace TPN1EfCore.Datos.Repositories
{
    public class ColorRepository:IColorRepository
    {
        private readonly ShoesDbContext _context;
        public ColorRepository(ShoesDbContext context)
        {
            _context = context;
        }

        public void Agregar(Colour Colour)
        {
            _context.Colors.Add(Colour);
        }

        public void Borrar(Colour Colour)
        {
            _context.Colors.Remove(Colour);
        }

        public void Editar(Colour Colour)
        {
            _context.Colors.Update(Colour);
        }

        public bool EstaRelacionado(Colour Colour)
        {
           return _context.Shoes.Any(c=>c.ColorId == Colour.ColourId);
        }

        public bool Existe(Colour Colour)
        {
            if (Colour.ColourId == 0)
            {
                return _context.Colors.Any(c => c.ColorName == Colour.ColorName);
            }
            return _context.Colors.Any(c => c.ColorName == Colour.ColorName && c.ColourId != Colour.ColourId);
        }

        public int GetCantidad()
        {
            return _context.Colors.Count();
        }

        public Colour? GetColourPorId(int ColourId)
        {
            return _context.Colors.FirstOrDefault(c=>c.ColourId==ColourId);
        }

        public Colour? GetColourPorNombre(string ColourName)
        {
            return _context.Colors.FirstOrDefault(c => c.ColorName == ColourName);
        }

        public List<Colour>? GetColours()
        {
            return _context.Colors.OrderBy(c=>c.ColorName).ToList();
        }
    }
}
