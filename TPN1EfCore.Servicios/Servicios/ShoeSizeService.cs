using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPN1EfCore.Datos.Interfaces;
using TPN1EfCore.Datos.Repositories;
using TPN1EfCore.Entidades;
using TPN1EfCore.Servicios.Interfaces;

namespace TPN1EfCore.Servicios.Servicios
{
    public class ShoeSizeService : IShoeSizeService
    {
        private readonly IShoeSizeRepository shoeSizeRepo;
        public ShoeSizeService(IShoeSizeRepository _shoeSizeRepo)
        {
            shoeSizeRepo = _shoeSizeRepo;
        }


        public int GetId()
        {
            return shoeSizeRepo.GetId();
        }
    }
}
