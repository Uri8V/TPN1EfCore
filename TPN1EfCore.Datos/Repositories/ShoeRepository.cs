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
    public class ShoeRepository:IShoeRepository
    {
        private readonly ShoesDbContext _context;
        public ShoeRepository(ShoesDbContext context)
        {
            _context = context;
        }

        public void Agregar(Shoe shoe)
        {
           _context.Shoes.Add(shoe);
        }

        public void Borrar(Shoe Shoe)
        {
            _context.Shoes.Remove(Shoe);
        }

        public void Editar(Shoe Shoe)
        {
            _context.Shoes.Update(Shoe);
        }

        public bool Existe(Shoe Shoe)
        {
            if (Shoe.ShoeId==0)
            {
                return _context.Shoes.Any(s => s.SportId == Shoe.SportId && s.BrandId == Shoe.BrandId && s.GenreId == Shoe.GenreId && s.ColorId == Shoe.ColorId);
            }
            return _context.Shoes.Any(s => s.SportId == Shoe.SportId && s.BrandId == Shoe.BrandId && s.GenreId == Shoe.GenreId && s.ColorId == Shoe.ColorId && s.ShoeId!=Shoe.ShoeId);
        }

        public int GetCantidad()
        {
            return _context.Shoes.Count();
        }

        public List<Shoe> GetShoePorBrand(int brandId)
        {
            return _context.Shoes.Include(s => s.Brands)
                .Include(s => s.Genres)
                .Include(s => s.Color)
                .Include(s => s.Sports)
                .Where(s => s.BrandId == brandId)
                .AsNoTracking()
                .ToList();
        }

        public List<Shoe> GetShoePorColor(int colorId)
        {
            return _context.Shoes.Include(s => s.Brands)
                .Include(s => s.Genres)
                .Include(s => s.Color)
                .Include(s => s.Sports)
                .Where(s => s.ColorId == colorId)
                .AsNoTracking()
                .ToList();
        }

        public List<Shoe> GetShoePorGenre(int genreId)
        {
            return _context.Shoes.Include(s => s.Brands)
                .Include(s => s.Genres)
                .Include(s => s.Color)
                .Include(s => s.Sports)
                .Where(s => s.GenreId == genreId)
                .AsNoTracking()
                .ToList();
        }

        public Shoe GetShoePorId(int ShoeId)
        {
            return _context.Shoes.FirstOrDefault(s => s.ShoeId == ShoeId);
        }

        public List<Shoe> GetShoePorSport(int sportId)
        {
            return _context.Shoes.Include(s => s.Brands)
                 .Include(s => s.Genres)
                 .Include(s => s.Color)
                 .Include(s => s.Sports)
                 .Where(s => s.SportId == sportId)
                 .AsNoTracking()
                 .ToList();
        }

        public List<Shoe> GetShoes()
        {
            return _context.Shoes.OrderBy(s=>s.Model).AsNoTracking().ToList();
        }
    }
}
