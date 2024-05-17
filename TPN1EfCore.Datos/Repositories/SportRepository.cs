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
    public class SportRepository:ISportRepository
    {
        private readonly ShoesDbContext _context;
        public SportRepository(ShoesDbContext context)
        {
            _context = context;
        }

        public void Agregar(Sport sport)
        {
            _context.Sports.Add(sport);
        }

        public void Borrar(Sport sport)
        {
            _context.Sports.Remove(sport);
        }

        public void Editar(Sport sport)
        {
            _context.Sports.Update(sport);
        }

        public bool EstaRelacionado(Sport sport)
        {
            return _context.Shoes.Any(s => s.SportId == sport.SportId);
        }

        public bool Existe(Sport sport)
        {
            if (sport.SportId == 0)
            {
                return _context.Sports.Any(s => s.SportName == sport.SportName);
            }
            return _context.Sports.Any(s => s.SportName== sport.SportName && s.SportId != sport.SportId);
        }

        public int GetCantidad()
        {
            return _context.Sports.Count();
        }

        public Sport? GetSportPorId(int SportId)
        {
            return _context.Sports.SingleOrDefault(s=>s.SportId==SportId);
        }

        public Sport? GetSportPorNombre(string SportName)
        {
            return _context.Sports.FirstOrDefault(s => s.SportName == SportName);
        }

        public List<Sport>? GetSports()
        {
           return _context.Sports.OrderBy(s=>s.SportName).AsNoTracking().ToList();  
        }
    }
}
