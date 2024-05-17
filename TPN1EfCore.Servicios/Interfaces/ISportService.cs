using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPN1EfCore.Entidades;

namespace TPN1EfCore.Servicios.Interfaces
{
    public interface ISportService
    {
        void Borrar(Sport sport);
        void Guardar(Sport sport);
        bool EstaRelacionado(Sport sport);
        bool Existe(Sport sport);
        int GetCantidad();
        Sport? GetSportPorNombre(string SportName);
        List<Sport>? GetSports();
        Sport? GetSportPorId(int SportId);
    }
}
