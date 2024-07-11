using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using TPN1EfCore.Datos.Interfaces;
using TPN1EfCore.Entidades;
using TPN1EfCore.Entidades.DTO;
using TPN1EfCore.Entidades.Enums;
using Size = TPN1EfCore.Entidades.Size;

namespace TPN1EfCore.Datos.Repositories
{
    public class ShoeRepository : IShoeRepository
    {
        private readonly ShoesDbContext _context;
        private readonly IShoeSizeRepository _shoeSizeRepository;//Lo necesito para obtener el Id para crear la nueva relacion
                                                                 // (No se me ocurrió otra forma)
        public ShoeRepository(ShoesDbContext context, IShoeSizeRepository shoeSizeRepository)
        {
            _context = context;
            _shoeSizeRepository = shoeSizeRepository;
        }

        public void Agregar(Shoe? shoe)
        {
            // Verificar si la Brand asociado
            // al Shoe ya existe en la base de datos
            var brandExistente = _context.Brands
                .FirstOrDefault(t => t.BrandId == shoe.BrandId);

            // Si la Brand ya existe,
            // adjuntarlo al contexto en lugar de agregarlo nuevamente
            if (brandExistente != null)
            {
                _context.Attach(brandExistente);
                shoe.Brands = brandExistente;
            }
            // Verificar si el Sport asociado
            // al Shoe ya existe en la base de datos

            var sportExistente = _context
                .Sports.FirstOrDefault(t => t.SportId == shoe.SportId);

            // Si el Sport ya existe,
            // adjuntarlo al contexto en lugar de agregarlo nuevamente

            if (sportExistente != null)
            {
                _context.Attach(sportExistente);
                shoe.Sports = sportExistente;
            }

            var colorExistente = _context
               .Colors.FirstOrDefault(t => t.ColourId == shoe.ColourId);
            if (colorExistente != null)
            {
                _context.Attach(colorExistente);
                shoe.Color = colorExistente;
            }

            var genreExistente = _context
             .Genres.FirstOrDefault(t => t.GenreId == shoe.GenreId);
            if (genreExistente != null)
            {
                _context.Attach(genreExistente);
                shoe.Genres = genreExistente;
            }

            // Agregar la planta al contexto de la base de datos
            _context.Shoes.Add(shoe);
        }

        public void Borrar(Shoe? Shoe)
        {
            _context.Shoes.Remove(Shoe);
        }

        public void Editar(Shoe? shoe, List<Size>? sizes = null)
        {
            // Verificar si la Brand asociado
            // al Shoe ya existe en la base de datos
            var brandExistente = _context.Brands
                .FirstOrDefault(t => t.BrandId == shoe.BrandId);

            // Si la Brand ya existe,
            // adjuntarlo al contexto en lugar de agregarlo nuevamente
            if (brandExistente != null)
            {
                _context.Attach(brandExistente);
                shoe.Brands = brandExistente;
            }
            // Verificar si el Sport asociado
            // al Shoe ya existe en la base de datos

            var sportExistente = _context
                .Sports.FirstOrDefault(t => t.SportId == shoe.SportId);

            // Si el Sport ya existe,
            // adjuntarlo al contexto en lugar de agregarlo nuevamente

            if (sportExistente != null)
            {
                _context.Attach(sportExistente);
                shoe.Sports = sportExistente;
            }

            var colorExistente = _context
               .Colors.FirstOrDefault(t => t.ColourId == shoe.ColourId);
            if (colorExistente != null)
            {
                _context.Attach(colorExistente);
                shoe.Color = colorExistente;
            }

            var genreExistente = _context
             .Genres.FirstOrDefault(t => t.GenreId == shoe.GenreId);
            if (genreExistente != null)
            {
                _context.Attach(genreExistente);
                shoe.Genres = genreExistente;
            }

            // Agregar la planta al contexto de la base de datos

            _context.Shoes.Update(shoe);
        }

        public bool Existe(Shoe? Shoe)
        {
            if (Shoe?.ShoeId == 0)
            {
                return _context.Shoes.Any(s => s.SportId == Shoe.SportId && s.BrandId == Shoe.BrandId && s.GenreId == Shoe.GenreId && s.ColourId == Shoe.ColourId);
            }
            return _context.Shoes.Any(s => s.SportId == Shoe.SportId && s.BrandId == Shoe.BrandId && s.GenreId == Shoe.GenreId && s.ColourId == Shoe.ColourId && s.ShoeId != Shoe.ShoeId);
        }

        public int GetCantidad(Func<Shoe, bool>? filtro)
        {

            if (filtro != null)
            {
                return _context.Shoes.Where(filtro).Count();
            }
            else
            {
                return _context.Shoes.Count();
            }

        }

        public Shoe? GetShoePorId(int ShoeId)
        {
            return _context.Shoes.FirstOrDefault(s => s.ShoeId == ShoeId);
        }

        public List<ShoeListDto> GetShoes()
        {
            return _context.Shoes
                .Include(s => s.Brands)
                .Include(s => s.Sports)
                .Include(s => s.Color)
                .Include(s => s.Genres)
                .Include(s => s.ShoeSize).ThenInclude(s => s.Size)
                .Select(s => new ShoeListDto
                {
                    shoeId = s.ShoeId,
                    brand = s.Brands != null ? s.Brands.BrandName : string.Empty,
                    color = s.Color != null ? s.Color.ColorName : string.Empty,
                    genre = s.Genres != null ? s.Genres.GenreName : string.Empty,
                    sport = s.Sports != null ? s.Sports.SportName : string.Empty,
                    descripcion = s.Descripcion,
                    model = s.Model,
                    price = s.Price,
                    size = s.ShoeSize.Select(s => s.Size.SizeNumber).ToList(),
                    Stock = s.ShoeSize.Select(s => s.QuantityInStock).ToList()
                })
                .OrderBy(s => s.shoeId).AsNoTracking().ToList();
        }



        public List<ShoeListDto> GetListaPaginadaOrdenadaFiltrada(int page,
         int pageSize, Orden? orden = null, Brand? brandFiltro = null,
         Sport? sportFiltro = null, Genre? genreFiltro = null, Colour? colourFiltro = null,
         decimal? maximo = null, decimal? minimo = null, Size? sizeseleccionado = null, Size? sizeMaximo = null)
        {
            IQueryable<Shoe> query = _context.Shoes
                .Include(s => s.Brands)
                .Include(s => s.Sports)
                .Include(s => s.Genres)
                .Include(s => s.Color)
                .Include(ss => ss.ShoeSize).ThenInclude(s => s.Size)
                .AsNoTracking();


            // Aplicar filtro si se proporciona una Brand
            if (brandFiltro != null)
            {
                query = query
                    .Where(p => p.BrandId == brandFiltro.BrandId);
            }
            // Aplicar filtro si se proporciona un Sport
            if (sportFiltro != null)
            {
                query = query
                    .Where(p => p.SportId == sportFiltro.SportId);
            }
            //Aplicar filtro si se proporciona un Genre
            if (genreFiltro != null)
            {
                query = query
                    .Where(p => p.GenreId == genreFiltro.GenreId);
            }
            //Aplicar filtro si se proporciona un Color
            if (colourFiltro != null)
            {
                query = query
                    .Where(p => p.ColourId == colourFiltro.ColourId);
            }

            // Aplicar orden si se proporciona
            if (orden != null)
            {
                switch (orden)
                {
                    case Orden.AZ:
                        query = query.OrderBy(s => s.Model);
                        break;
                    case Orden.ZA:
                        query = query.OrderByDescending(s => s.Model);
                        break;
                    case Orden.MenorPrecio:
                        query = query.OrderBy(s => s.Price);
                        break;
                    case Orden.MayorPrecio:
                        query = query.OrderByDescending(s => s.Price);
                        break;
                    default:
                        break;
                }
            }

            if (maximo != null && minimo != null)
            {
                query = query.Where(s => s.Price <= maximo).Where(s => s.Price >= minimo);
            }
            if (sizeseleccionado != null && sizeMaximo==null)
            {
                query = query.Where(s =>_context.ShoeSizes.Any(ss=>ss.SizeId==sizeseleccionado.SizeId && ss.ShoeId==s.ShoeId ));
            }
            if (sizeseleccionado != null && sizeMaximo != null)
            {
                query = query.Where(s => _context.ShoeSizes.Any(ss => ss.ShoeId == s.ShoeId  && ss.SizeId <= sizeMaximo.SizeId && ss.SizeId >= sizeseleccionado.SizeId));
            }

            // Paginar los resultados
            List<Shoe> listaPaginada = query
                .AsNoTracking()
                .Skip(page * pageSize)//Saltea estos registros
                .Take(pageSize)//Muestra estos
                .ToList();

            // Mapear los resultados de ShoeListDto
            List<ShoeListDto> listaDto = listaPaginada
                .Select(s => new ShoeListDto
                {
                    shoeId = s.ShoeId,
                    brand = s.Brands.BrandName,
                    sport = s.Sports.SportName,
                    genre = s.Genres.GenreName,
                    color = s.Color.ColorName,
                    descripcion = s.Descripcion,
                    price = s.Price,
                    model = s.Model,
                    size = s.ShoeSize.Select(s => s.Size.SizeNumber).ToList(),
                    Stock = s.ShoeSize.Select(s => s.QuantityInStock).ToList()
                })
                .OrderBy(s => s.price).ToList();

            return listaDto;
        }



        public List<ShoeListDto> GetListaPorPropiedadDeseada(Brand? brandFiltro = null, Sport? sportFiltro = null, Genre? genreFiltro = null, Colour? colourFiltro = null)
        {
            IQueryable<Shoe> query = null;
            if (brandFiltro != null)
            {
                query = _context.Entry(brandFiltro).Collection(s => s.Shoes).Query()
                    .Include(sp => sp.Sports).Include(G => G.Genres).Include(c => c.Color);
            }
            if (sportFiltro != null)
            {
                query = _context.Entry(sportFiltro).Collection(s => s.Shoes).Query()
                .Include(b => b.Brands).Include(G => G.Genres).Include(c => c.Color);
            }
            if (genreFiltro != null)
            {
                query = _context.Entry(genreFiltro).Collection(s => s.Shoes).Query()
                .Include(b => b.Brands).Include(sp => sp.Sports).Include(c => c.Color);
            }
            if (colourFiltro != null)
            {
                query = _context.Entry(colourFiltro).Collection(s => s.Shoes).Query()
                .Include(b => b.Brands).Include(G => G.Genres).Include(s => s.Sports);
            }
            List<ShoeListDto> listaDto = query
              .Select(s => new ShoeListDto
              {
                  shoeId = s.ShoeId,
                  brand = s.Brands.BrandName,
                  sport = s.Sports.SportName,
                  genre = s.Genres.GenreName,
                  color = s.Color.ColorName,
                  descripcion = s.Descripcion,
                  price = s.Price,
                  model = s.Model
              })
              .ToList();

            return listaDto;
        }

        public List<ShoeListDto>? GetListaDeShoeSinSize()
        {
            return _context.Shoes //Le indico que me traiga una lista de tipo SHOELISTDTO, la cual va a incluir los datos de las tablas
                .Include(b => b.Brands)//simples y me va a traer todos los Shoes los cuales no tengan relacionado algún Size
                .Include(s => s.Sports)
                .Include(c => c.Color)
                .Include(g => g.Genres)
                .Where(sz => !sz.ShoeSize.Any())
                .Select(sh => new ShoeListDto
                {
                    shoeId = sh.ShoeId,
                    brand = sh.Brands.BrandName,
                    sport = sh.Sports.SportName,
                    color = sh.Color.ColorName,
                    genre = sh.Genres.GenreName,
                    descripcion = sh.Descripcion,
                    price = sh.Price,
                    model = sh.Model
                }).ToList();
        }

        public void AsignarSizeAlShoe(ShoeSizes nuevaRelacion)
        {
            _context.Set<ShoeSizes>().Add(nuevaRelacion);//Indico que en la propiedad ShoeSizes me agregue una nueva relación

        }

        public void AsignarSizeAlShoe(Shoe shoe, List<Size> sizes, List<int> stocks)
        {
            var id = _shoeSizeRepository.GetId();
            for (int i = 0; i < sizes.Count; i++)
            {
                var size = sizes[i];
                var stock=stocks[i];
                var sizeExistente = _context.Sizes
                    .FirstOrDefault(p => p.SizeId == size.SizeId);

                if (sizeExistente == null)
                {
                    _context.Sizes.Add(size); // Agregar nuevo size, en este caso nunca va a ser nuevo 
                    //a menos que lo configure para que pueda agregar uno nuevo
                    sizeExistente = size; // Establecer sizeExistente como el nuevo size
                }
                else
                {
                    _context.Sizes.Attach(sizeExistente); // Attach si el size ya existe y está detached
                }

                if (!ExisteRelacion(shoe, sizeExistente))
                {
                    _context.ShoeSizes.Add(new ShoeSizes
                    {
                        ShoeSizeId = id,
                        ShoeId = shoe.ShoeId,
                        SizeId = sizeExistente.SizeId,
                        QuantityInStock = stock
                    });
                }
                id ++;
            }

        }

        private bool ExisteRelacion(Shoe shoe, Size sizeExistente)
        {
            if (shoe == null || sizeExistente == null) return false;

            return _context.ShoeSizes
                .Any(pp => pp.ShoeId == shoe.ShoeId
                && pp.SizeId == sizeExistente.SizeId);
        }

        public void EliminarRelaciones(Shoe shoe)
        {
            var relacionesPasadas = _context.ShoeSizes
               .Where(pp => pp.ShoeId == shoe.ShoeId)
               .ToList();

            _context.ShoeSizes
                .RemoveRange(relacionesPasadas);
        }

        public IEnumerable<IGrouping<int, Shoe>> GetShoesAgrupadasPorBrand()
        {
            return _context.Shoes.GroupBy(pp => pp.BrandId).ToList();
        }

        public IEnumerable<IGrouping<int, Shoe>> GetShoesAgrupadasPorSport()
        {
            return _context.Shoes.GroupBy(pp => pp.SportId).ToList();
        }

        public IEnumerable<IGrouping<int, Shoe>> GetShoesAgrupadasPorGenre()
        {
            return _context.Shoes.GroupBy(_ => _.GenreId).ToList();
        }

        public IEnumerable<IGrouping<int, Shoe>> GetShoesAgrupadasPorColor()
        {
            return _context.Shoes.GroupBy(ss => ss.ColourId).ToList();
        }

        public IEnumerable<IGrouping<int, ShoeSizes>> GetShoesAgrupadasPorSize()
        {
            return _context.ShoeSizes.GroupBy(ss => ss.SizeId).ToList();
        }

        public List<Size>? GetSizesPorShoes(int shoeId)
        {
            return _context.ShoeSizes.Include(_ => _.Size)
                .Where(s => s.ShoeId == shoeId)
                .Select(s => s.Size)
                .ToList();
        }

        bool IShoeRepository.ExisteRelacion(Shoe shoe, Size size)
        {
            if (shoe is null || size is null) return false;
            var existerelación = _context.Shoes.Include(ss => ss.ShoeSize)
                .ThenInclude(ss => ss.Size)
                .Any(ss => ss.ShoeId == shoe.ShoeId &&
                ss.ShoeSize.Any(ss => ss.SizeId == size.SizeId));
            return existerelación;
        }
    }
}
