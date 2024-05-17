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
    public class BrandRepository:IBrandRepository
    { 
        private readonly ShoesDbContext context;
        public BrandRepository(ShoesDbContext _context)
        {
            context= _context;
        }

        public void Agregar(Brand brand)
        {
            context.Brands.Add(brand);
        }

        public void Borrar(Brand brand)
        {
            context.Brands.Remove(brand);
        }

        public void Editar(Brand brand)
        {
            context.Brands.Update(brand);
        }

        public bool EstaRelacionado(Brand brand)
        {
            return context.Shoes.Any(b => b.BrandId == brand.BrandId);
        }

        public bool Existe(Brand brand)
        {
            if (brand.BrandId == 0)
            {
                return context.Brands.Any(b=>b.BrandName==brand.BrandName);
            }
            return context.Brands.Any(b=>b.BrandName == brand.BrandName && b.BrandId!=brand.BrandId);
        }

        public Brand? GetBrandPorId(int BrandId)
        {
            return context.Brands.SingleOrDefault(b => b.BrandId == BrandId);
        }

        public int GetCantidad()
        {
            return context.Brands.Count();
        }

        public Brand? GetBrandPorNombre(string BrandName)
        {
            return context.Brands.FirstOrDefault(b => b.BrandName == BrandName);
        }

        public List<Brand>? GetBrands()
        {
            return context.Brands.OrderBy(b => b.BrandName).AsNoTracking().ToList();
        }
    }
}
