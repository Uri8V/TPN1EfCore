using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TPN1EfCore.Entidades;
using TPN1EfCore.Entidades.DTO;
using TPN1EfCore.Entidades.Enums;

namespace TPN1EfCore.Servicios.Interfaces
{
    public interface IShoeService
    {
        void Borrar(Shoe Shoe);
        void Guardar(Shoe Shoe, List<int> stock, List<Size>? sizes =null);
        bool Existe(Shoe Shoe);
        int GetCantidad(Expression<Func<Shoe, bool>>? filtro);
        List<ShoeListDto> GetShoes();
        Shoe? GetShoePorId(int ShoeId);
        public List<ShoeListDto> GetListaPaginadaOrdenadaFiltrada(int page,
      int pageSize, Orden? orden = null, Brand? brandFiltro = null,
      Sport? sportFiltro = null, Genre? genreFiltro = null, Colour? colourFiltro = null,
      decimal? maximo = null, decimal? minimo = null, Size? sizeseleccionado = null, Size? sizeMaximo = null);
        public List<ShoeListDto> GetListaPorPropiedadDeseada(Brand? brandFiltro = null,
Sport? sportFiltro = null, Genre? genreFiltro = null, Colour? colourFiltro = null);
        List<ShoeListDto>? GetListaDeShoeSinSize();
        void AsignarSizealShoe(Shoe shoeSinSize, Size? sizeSeleccionado, int Stock );
        void Editar(Shoe shoe, int stock, int? value = null);
        IEnumerable<IGrouping<int, Shoe>> GetShoesAgrupadasPorBrand();
        IEnumerable<IGrouping<int, Shoe>> GetShoesAgrupadasPorSport();
        IEnumerable<IGrouping<int, Shoe>> GetShoesAgrupadasPorGenre();
        IEnumerable<IGrouping<int, Shoe>> GetShoesAgrupadasPorColor();
        IEnumerable<IGrouping<int, ShoeSizes>> GetShoesAgrupadasPorSize();
        List<Size>? GetSizesPorShoes(int shoeId);
        bool ExisteRelacion(Shoe shoe, Size size);

    }
}
