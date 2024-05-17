using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPN1EfCore.Datos;
using TPN1EfCore.Datos.Interfaces;
using TPN1EfCore.Entidades;
using TPN1EfCore.Servicios.Interfaces;

namespace TPN1EfCore.Servicios.Servicios
{
    public class SportService:ISportService
    {
        private readonly ISportRepository _sportRepository;
        private readonly IUnitOfWork _unitOfWork;
        public SportService(ISportRepository sportRepository, IUnitOfWork unitOfWork)
        {
            _sportRepository = sportRepository;
            _unitOfWork = unitOfWork;
        }

        public void Borrar(Sport sport)
        {
            try
            {
                _unitOfWork.BeginTransaction();
                _sportRepository.Borrar(sport);
                _unitOfWork.Commit();
            }
            catch (Exception)
            {
                _unitOfWork?.Rollback();
                throw;
            }
        }

        public bool EstaRelacionado(Sport sport)
        {
           return _sportRepository.EstaRelacionado(sport);
        }

        public bool Existe(Sport sport)
        {
            return _sportRepository.Existe(sport);
        }

        public int GetCantidad()
        {
           return _sportRepository.GetCantidad();
        }

        public Sport? GetSportPorId(int SportId)
        {
            return _sportRepository.GetSportPorId(SportId);
        }

        public Sport? GetSportPorNombre(string SportName)
        {
            return _sportRepository.GetSportPorNombre(SportName);
        }

        public List<Sport>? GetSports()
        {
          return _sportRepository.GetSports();
        }

        public void Guardar(Sport sport)
        {
            try
            {   _unitOfWork.BeginTransaction();
                if (sport.SportId==0)
                {
                    _sportRepository.Agregar(sport);
                }
                else
                {
                    _sportRepository.Editar(sport);
                }
                _unitOfWork.Commit();
            }
            catch (Exception)
            {
                _unitOfWork.Rollback();
                throw;
            }
        }
    }
}
