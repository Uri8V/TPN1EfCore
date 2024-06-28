// See https://aka.ms/new-console-template for more information
using ConsoleTables;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using TPN1EfCore.Entidades;
using TPN1EfCore.Entidades.DTO;
using TPN1EfCore.Entidades.Enums;
using TPN1EfCore.IOC;
using TPN1EfCore.Servicios.Interfaces;
using TPN1EfCore.Shared;

namespace TPN1EfCore.Consola
{
    internal class Program
    {
        private static IServiceProvider? _serviceProvider; //Creo la variable para utilizar más tarde
        static int pageSize = 1;
        static void Main(string[] args)
        {
            _serviceProvider = DI.ConfiguracionServicios();//La instancio para después usar los servicios necesarios
            bool fin = true;
            while (fin)
            {
                Console.Clear();
                Console.WriteLine("Menú Principal:");
                Console.WriteLine("1. Listado de Brands");
                Console.WriteLine("2. Ingresar Brand");
                Console.WriteLine("3. Borrar Brand");
                Console.WriteLine("4. Editar Brand");
                Console.WriteLine("b. Lista de Shoes Por Brand");
                Console.WriteLine("ba.Agrupar Shoes por Brand");
                Console.WriteLine("=======================");
                Console.WriteLine("5. Listado de Sports");
                Console.WriteLine("6. Ingresar Sport");
                Console.WriteLine("7. Borrar Sport");
                Console.WriteLine("8. Editar Sport");
                Console.WriteLine("s. Lista de Shoes Por Sport");
                Console.WriteLine("sa.Agrupar Shoes por Sport");
                Console.WriteLine("=======================");
                Console.WriteLine("9. Listado de Genres");
                Console.WriteLine("10. Ingresar Genre");
                Console.WriteLine("11. Borrar Genre");
                Console.WriteLine("12. Editar Genre");
                Console.WriteLine("g. Lista de Shoes Por Genre");
                Console.WriteLine("ga.Agrupar Shoes por Genre");
                Console.WriteLine("=======================");
                Console.WriteLine("13. Listado de Colors");
                Console.WriteLine("14. Ingresar Color");
                Console.WriteLine("15. Borrar Color");
                Console.WriteLine("16. Editar Color");
                Console.WriteLine("c. Lista de Shoes Por Color");
                Console.WriteLine("ca.Agrupar Shoes por Color");
                Console.WriteLine("=======================");
                Console.WriteLine("17. Listado de Shoes");
                Console.WriteLine("18. Ingresar Shoe");
                Console.WriteLine("19. Borrar Shoe");
                Console.WriteLine("20. Editar Shoe");
                Console.WriteLine("21. Lista Filtrada y Ordenada");
                Console.WriteLine("22. Asignar Size a Shoe");
                Console.WriteLine("=======================");
                Console.WriteLine("25. Listado de Size");
                Console.WriteLine("26. Listado de Size con sus Shoes");
                Console.WriteLine("ssa.Agrupar Shoes por Size");
                Console.Write("Por favor, seleccione una opción: ");
                string? input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Console.Clear();
                        ListaBrands();
                        break;
                    case "2":
                        InsertarBrand();
                        break;
                    case "3":
                        BorrarBrand();
                        break;
                    case "4":
                        EditarBrand();
                        break;
                    case "b":
                        ListaShoesPorBrans();
                        break;
                    case "B":
                        ListaShoesPorBrans();
                        break;
                    case "ba":
                        AgruparShoePorBrand();
                        break;
                    case "BA":
                        AgruparShoePorBrand();
                        break;
                    case "5":
                        Console.Clear();
                        ListaSports();
                        break;
                    case "6":
                        InsertarSport();
                        break;
                    case "7":
                        BorrarSport();
                        break;
                    case "8":
                        EditarSport();
                        break;
                    case "s":
                        ListaShoesPorSports();
                        break;
                    case "S":
                        ListaShoesPorSports();
                        break;
                    case "sa":
                        AgruparShoePorSport();
                        break;
                    case "SA":
                        AgruparShoePorSport();
                        break;
                    case "9":
                        Console.Clear();
                        ListaGenres();
                        break;
                    case "10":
                        InsertarGenre();
                        break;
                    case "11":
                        BorrarGenre();
                        break;
                    case "12":
                        EditarGenre();
                        break;
                    case "g":
                        ListaShoesPorGenres();
                        break;
                    case "G":
                        ListaShoesPorGenres();
                        break;
                    case "ga":
                        AgruparShoesPorGenre();
                        break;
                    case "GA":
                        AgruparShoesPorGenre();
                        break;
                    case "13":
                        Console.Clear();
                        ListaColors();
                        break;
                    case "14":
                        InsertarColor();
                        break;
                    case "15":
                        BorrarColor();
                        break;
                    case "16":
                        EditarColor();
                        break;
                    case "c":
                        ListaShoesPorColors();
                        break;
                    case "C":
                        ListaShoesPorColors();
                        break;
                    case "ca":
                        AgruparShoesPorColor();
                        break;
                    case "CA":
                        AgruparShoesPorColor();
                        break;
                    case "17":
                        Console.Clear();
                        ListaShoes();
                        break;
                    case "18":
                        InsertarShoe();
                        break;
                    case "19":
                        BorrarShoe();
                        break;
                    case "20":
                        EditarShoe();
                        break;
                    case "21":
                        ListaFiltradaYOrdenada();
                        break;
                    case "22":
                        AsignarSizeAShoe();
                        break;
                    case "25":
                        ListaSize();
                        break;
                    case "26":
                        ListaSizeConShoes();
                        break;
                    case "ssa":
                        AgruparShoesPorSize();
                        break;
                    case "SSA":
                        AgruparShoesPorSize();
                        break;
                    default:
                        fin = false;
                        Console.Clear();
                        Console.WriteLine("Usted a Salido del programa");
                        break;

                }
            }
        }

        private static void AgruparShoesPorSize()
        {
            Console.Clear();
            var shoeservice = _serviceProvider?.GetService<IShoeService>();
            var sizeservice = _serviceProvider?.GetService<ISizeService>();

            var agrupacion = shoeservice?.GetShoesAgrupadasPorSize();
            foreach (var sho in agrupacion)
            {
                Console.WriteLine($"Size {sizeservice?.GetSizePorId(sho.Key)?.SizeNumber}");
                foreach (var item in sho)
                {
                    Console.WriteLine($"Descripción:{shoeservice?.GetShoePorId(item.ShoeId)?.Descripcion} ,Precio: {shoeservice?.GetShoePorId(item.ShoeId)?.Price},Modelo: {shoeservice?.GetShoePorId(item.ShoeId)?.Model} ");
                }
                Console.WriteLine("");
                Console.WriteLine("");
            }
            Console.WriteLine($"Cantidad: {agrupacion.Count()}");
            Console.WriteLine("APRETE ENTER PARA CONTINUAR");
            Console.ReadLine();
        }

        private static void AgruparShoesPorColor()
        {
            Console.Clear();
            var shoeservice = _serviceProvider?.GetService<IShoeService>();
            var colorservice = _serviceProvider?.GetService<IColorService>();

            var agrupacion = shoeservice?.GetShoesAgrupadasPorColor();
            foreach (var sho in agrupacion)
            {
                Console.WriteLine($"Color {colorservice?.GetColourPorId(sho.Key)?.ColorName}");
                foreach (var item in sho)
                {
                    Console.WriteLine($"Descripción:{item.Descripcion} ,Precio: {item.Price},Modelo: {item.Model} ");
                }
                Console.WriteLine("");
                Console.WriteLine("");
            }
            Console.WriteLine($"Cantidad: {agrupacion.Count()}");
            Console.WriteLine("APRETE ENTER PARA CONTINUAR");
            Console.ReadLine();
        }

        private static void AgruparShoesPorGenre()
        {
            Console.Clear();
            var shoeservice = _serviceProvider?.GetService<IShoeService>();
            var genreservice = _serviceProvider?.GetService<IGenreService>();

            var agrupacion = shoeservice?.GetShoesAgrupadasPorGenre();
            foreach (var sho in agrupacion)
            {
                Console.WriteLine($"Genre {genreservice?.GetGenrePorId(sho.Key)?.GenreName}");
                foreach (var item in sho)
                {
                    Console.WriteLine($"Descripción:{item.Descripcion} ,Precio: {item.Price},Modelo: {item.Model} ");
                }
                Console.WriteLine("");
                Console.WriteLine("");
            }
            Console.WriteLine($"Cantidad: {agrupacion.Count()}");
            Console.WriteLine("APRETE ENTER PARA CONTINUAR");
            Console.ReadLine();
        }

        private static void AgruparShoePorSport()
        {
            Console.Clear();
            var shoeservice = _serviceProvider?.GetService<IShoeService>();
            var sportservice=_serviceProvider?.GetService<ISportService>();

            var agrupacion = shoeservice?.GetShoesAgrupadasPorSport();
            foreach (var sho in agrupacion)
            {
                Console.WriteLine($"Sport {sportservice?.GetSportPorId(sho.Key)?.SportName}");
                foreach (var item in sho)
                {
                    Console.WriteLine($"Descripción:{item.Descripcion} ,Precio: {item.Price},Modelo: {item.Model} ");
                }
                Console.WriteLine("");
                Console.WriteLine("");
            }
            Console.WriteLine($"Cantidad: {agrupacion.Count()}");
            Console.WriteLine("APRETE ENTER PARA CONTINUAR");
            Console.ReadLine();
        }

        private static void AgruparShoePorBrand()
        {
            Console.Clear();
            Console.Clear();
            var shoeservice = _serviceProvider?.GetService<IShoeService>();
            var brandservice=_serviceProvider?.GetService<IBrandService>();

            var agrupacion = shoeservice?.GetShoesAgrupadasPorBrand();
            foreach ( var sho in agrupacion)
            {
                Console.WriteLine($"Brand {brandservice?.GetBrandPorId(sho.Key)?.BrandName}");
                foreach (var item in sho)
                {
                    Console.WriteLine($"Descripción:{item.Descripcion} ,Precio: {item.Price},Modelo: {item.Model} ");
                }
                Console.WriteLine("");
                Console.WriteLine("");
            }
            Console.WriteLine($"Cantidad: {agrupacion.Count()}");
            Console.WriteLine("APRETE ENTER PARA CONTINUAR");
            Console.ReadLine();
        }

        private static void AsignarSizeAShoe()
        {
            // Inicializar los servicios
            var shoeservice = _serviceProvider?.GetService<IShoeService>();
            var sizeservice = _serviceProvider?.GetService<ISizeService>();

            if (shoeservice == null || sizeservice == null)
            {
                Console.WriteLine("Servicios no disponibles.");
                return;
            }

            // Obtener los Shoes sin size asignado
            var shoesSinSize = shoeservice.GetListaDeShoeSinSize();
            if (shoesSinSize?.Count > 0)
            {
                MostrarListaShoes(shoesSinSize);
                // Solicitar al usuario seleccionar un Shoe de la lista
                var opcionshoe = ValidarDatos.GetValidOptions("Seleccione un Shoe:",
                    shoesSinSize.Select(x => x.shoeId.ToString()).ToList());

                var shoeSinSize = shoeservice
                    .GetShoePorId(Convert.ToInt32(opcionshoe));

                // Verificar si se encontró un Shoe sin Size
                if (shoeSinSize != null)
                {
                    // Mostrar la Shoe sin Size
                    Console.WriteLine("Shoe sin size encontrado:");
                    Console.WriteLine($"ID: {shoeSinSize.ShoeId}");
                    Console.WriteLine($"Descripción: {shoeSinSize.Descripcion}");
                    Console.WriteLine();

                    // Obtener la lista de Sizes y
                    // Mostrar la lista de Size
                    Console.WriteLine("Lista de Sizes:");
                    foreach (var size in sizeservice.GetSizes())
                    {
                        Console.WriteLine($"ID: {size.SizeId}, Size Number: {size.SizeNumber}");
                    }
                    Console.WriteLine();

                    // Solicitar al usuario seleccionar un proveedor existente o crear uno nuevo
                    var opcion = ValidarDatos.GetValidOptions("Seleccione un Size:",
                        sizeservice.GetSizes().Select(x => x.SizeId.ToString()).ToList());
              
                        // Obtener el Size seleccionado
                        var sizeSeleccionado = sizeservice.GetSizes()
                            .FirstOrDefault(x => x.SizeId.ToString() == opcion);

                    //Asigno el stock
                    var stock = ValidarDatos.ReadInt("Ingrese el stock: ");
                        // Asignar el size existente al Shoe
                        shoeservice.AsignarSizealShoe(shoeSinSize,
                            sizeSeleccionado, stock);
                    
                }
                else
                {
                    Console.WriteLine("No se encontraron Shoes sin Size.");
                }

            }
            else
            {
                Console.WriteLine("No hay Shoe sin Size!!!");
            }

        }

        private static void ListaSizeConShoes()
        {
            var servicioSize = _serviceProvider?.GetService<ISizeService>();

            Console.Clear();
            ListaSize();
            var Size = ValidarDatos.ReadInt("Ingrese el ID de Size: ");
            Size? size = servicioSize?.GetSizePorId(Size, true);
            if (size == null)
            {
                Console.WriteLine("Debe ingresar el Id correcto");
                Console.WriteLine("Aprete ENTER para continuar");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine($"El Size es: {size?.SizeNumber}");
                var tabla = new ConsoleTable("ID", "Brand", "Sport", "Genre", "Color", "Descripción", "Price");
                if (size?.ShoeSize != null)
                {
                    foreach (var item in size.ShoeSize)
                    {
                        tabla.AddRow(item.Shoe.ShoeId,
                            item.Shoe.Brands?.BrandName,
                            item.Shoe.Sports?.SportName,
                            item.Shoe.Genres?.GenreName,
                            item.Shoe.Color?.ColorName,
                            item.Shoe.Descripcion,
                            item.Shoe.Price);
                    }
                    tabla.Options.EnableCount = false;
                    tabla.Write();
                }
                Console.WriteLine("Aprete ENTER para continuar");
                Console.ReadLine();
            }
        }

        private static void ListaSize()
        {
            Console.Clear();
            var servicio = _serviceProvider?.GetService<ISizeService>();
            var tabla = new ConsoleTable("ID", "Size");
            if (servicio?.GetSizes() != null)
            {
                foreach (var item in servicio.GetSizes())
                {
                    tabla.AddRow(item.SizeId, item.SizeNumber);
                }
                tabla.Options.EnableCount = false;
                tabla.Write();
            }
            Console.WriteLine("Aprete ENTER para continuar");
            Console.ReadLine();
            
        }

        private static void ListaShoesPorColors()
        {
            var servicioColor = _serviceProvider?.GetService<IColorService>();
            Console.Clear();
            ListaColors();
            var Color = ValidarDatos.ReadInt("Ingrese el ID de Color : ");
            Colour? colorFiltro = servicioColor?.GetColourPorId(Color);
            var servicio = _serviceProvider?.GetService<IShoeService>();
            MostrarListaShoes(servicio?.GetListaPorPropiedadDeseada(null, null, null, colorFiltro));
        }

        private static void ListaShoesPorGenres()
        {
            var servicioGenre = _serviceProvider?.GetService<IGenreService>();
            Console.Clear();
            ListaGenres();
            var genre = ValidarDatos.ReadInt("Ingrese el ID de Genre : ");
            Genre? genreFiltro = servicioGenre?.GetGenrePorId(genre);
            var servicio = _serviceProvider?.GetService<IShoeService>();
            MostrarListaShoes(servicio?.GetListaPorPropiedadDeseada(null, null, genreFiltro));
        }

        private static void ListaShoesPorSports()
        {
            var servicioSport = _serviceProvider?.GetService<ISportService>();
            Console.Clear();
            ListaSports();
            var sport = ValidarDatos.ReadInt("Ingrese el ID del Sport : ");
            Sport? sportFiltro = servicioSport?.GetSportPorId(sport);
            var servicio = _serviceProvider?.GetService<IShoeService>();
            MostrarListaShoes(servicio?.GetListaPorPropiedadDeseada(null, sportFiltro));
        }

        private static void ListaShoesPorBrans()
        {
            var servicioBrand = _serviceProvider?.GetService<IBrandService>();
            Console.Clear();
            ListaBrands();
            var brand = ValidarDatos.ReadInt("Ingrese el ID de Brand : ");
            Brand? brandFiltro = servicioBrand?.GetBrandPorId(brand);
            var servicio = _serviceProvider?.GetService<IShoeService>();
            MostrarListaShoes(servicio?.GetListaPorPropiedadDeseada(brandFiltro));

        }

        private static void ListaFiltradaYOrdenada()
        {
            var servicioBrand = _serviceProvider?.GetService<IBrandService>();
            Brand? brandFiltro = null;
            var servicioSport = _serviceProvider?.GetService<ISportService>();
            Sport? sportFiltro = null;
            var servicioGenre = _serviceProvider?.GetService<IGenreService>();
            Genre? genreFiltro = null;
            var servicioColor = _serviceProvider?.GetService<IColorService>();
            Colour? colorFiltro = null;
            Func<Shoe, bool>? filtro = null;
            List<ShoeListDto>? shoeList = null;
            decimal? preciomaximo = null;
            decimal? preciominimo = null;
            Console.Clear();
            Console.WriteLine("Listado de Shoes Ordenada Por Precio y Modelo");
            var respuesta = ValidarDatos.ReadString("Desea Filtrar por algun dato? (S)Yes (N)No: ");
            if (respuesta == "S" || respuesta == "s")
            {
                Console.Clear();
                var resBrand = ValidarDatos.ReadString("Desea Filtrar por Brand? (S)Yes (N)No: ");
                if (resBrand == "s" || resBrand == "S")
                {
                    ListaBrands();
                    var brandIdFiltro = ValidarDatos.ReadInt("Ingrese el ID de la Brand a Filtrar: ");
                    brandFiltro = servicioBrand?.GetBrandPorId(brandIdFiltro);
                    Func<Shoe, bool> brandfiltro = p => p.Brands == brandFiltro;
                    //filtro = filtro == null ? brandfiltro : filtro.And(brandfiltro);
                }
                Console.Clear();
                var resSport = ValidarDatos.ReadString("Desea Filtrar por Sport? (S)Yes (N)No: ");
                if (resSport == "s" || resSport == "S")
                {
                    ListaSports();
                    var sportIdFiltro = ValidarDatos.ReadInt("Ingrese el ID de la Sport a Filtrar: ");
                    sportFiltro = servicioSport?.GetSportPorId(sportIdFiltro);
                }
                Console.Clear();
                var resGenre = ValidarDatos.ReadString("Desea Filtrar por Genre? (S)Yes (N)No: ");
                if (resGenre == "s" || resGenre == "S")
                {
                    ListaGenres();
                    var genreIdFiltro = ValidarDatos.ReadInt("Ingrese el ID de la Genre a Filtrar: ");
                    genreFiltro = servicioGenre?.GetGenrePorId(genreIdFiltro);
                }
                Console.Clear();
                var resColor = ValidarDatos.ReadString("Desea Filtrar por Color? (S)Yes (N)No: ");
                if (resColor == "s" || resColor == "S")
                {
                    ListaColors();
                    var colorIdFiltro = ValidarDatos.ReadInt("Ingrese el ID de la Color a Filtrar: ");
                    colorFiltro = servicioColor?.GetColourPorId(colorIdFiltro);
                }

            }
            var respuestaprecio = ValidarDatos.ReadString("Desea Filtrar por precio? (S)Yes (N)No: ");
            if (respuestaprecio == "S" || respuestaprecio == "s")
            {
                bool valido = false;
                do
                {
                    preciominimo = ValidarDatos.ReadDecimal("Ingrese un valor minimo: ");
                    preciomaximo = ValidarDatos.ReadDecimal("Ingrese un valor maximo: ");
                    if (preciominimo >= preciomaximo || preciomaximo < 0 || preciominimo < 0)
                    {
                        valido = true;
                        Console.Clear();
                    }
                    else
                    {
                        valido = false;
                    }
                } while (valido);
            }
            var orden = ValidarDatos.ReadInt("(1)AZ (2)ZA (3)Menor Precio (4)Mayor Precio:");

            var servicio = _serviceProvider?.GetService<IShoeService>();
            pageSize = ValidarDatos.ReadInt("Ingrese la cantidad por página:");

            var recordCount = servicio?.GetCantidad(null) ?? 0;//Los doble signos de interrogación se ponen para evitar las advertencias y significan que puede ser null
            var pageCount = CalcularCantidadPaginas(recordCount, pageSize);

            for (int page = 0; page < pageCount; page++)
            {
                Console.Clear();
                switch (orden)
                {
                    case 1:
                        shoeList = servicio?.GetListaPaginadaOrdenadaFiltrada(page, pageSize, Orden.AZ, brandFiltro, sportFiltro, genreFiltro, colorFiltro, preciomaximo, preciominimo);
                        MostrarListaShoes(shoeList);
                        break;
                    case 2:
                        shoeList = servicio?.GetListaPaginadaOrdenadaFiltrada(page, pageSize, Orden.ZA, brandFiltro, sportFiltro, genreFiltro, colorFiltro, preciomaximo, preciominimo);
                        MostrarListaShoes(shoeList);
                        break;
                    case 3:
                        shoeList = servicio?.GetListaPaginadaOrdenadaFiltrada(page, pageSize, Orden.MenorPrecio, brandFiltro, sportFiltro, genreFiltro, colorFiltro, preciomaximo, preciominimo);
                        MostrarListaShoes(shoeList);
                        break;
                    default:
                        shoeList = servicio?.GetListaPaginadaOrdenadaFiltrada(page, pageSize, Orden.MayorPrecio, brandFiltro, sportFiltro, genreFiltro, colorFiltro, preciomaximo, preciominimo);
                        MostrarListaShoes(shoeList);
                        break;
                }
                if (shoeList?.Count < pageSize)
                {
                    break;
                }

            }
        }

        private static void MostrarListaShoes(List<ShoeListDto>? shoeListDtos)
        {
            Console.Clear();
            var tabla = new ConsoleTable("Id", "Brand", "Sport", "Genre", "Color", "Descripción", "Price", "Model");
            if (shoeListDtos != null)
            {
                if (shoeListDtos.Count > 0)
                {
                    foreach (var item in shoeListDtos)
                    {
                        tabla.AddRow(item.shoeId, item.brand, item.sport, item.genre, item.color, item.descripcion, item.price, item.model);
                    }
                    tabla.Options.EnableCount = false;
                    tabla.Write();
                }
                else
                {
                    Console.WriteLine("Todavía no hay datos con esas propiedades o ya ha visto todos los registros");
                }
                Console.ReadKey();
            }
        }

        private static int CalcularCantidadPaginas(int cantidadRegistros,
               int cantidadPorPagina)
        {
            if (cantidadRegistros < cantidadPorPagina)
            {
                return 1;
            }
            else if (cantidadRegistros % cantidadPorPagina == 0)
            {
                return cantidadRegistros / cantidadPorPagina;
            }
            else
            {
                return cantidadRegistros / cantidadPorPagina + 1;
            }
        }

        private static void BorrarShoe()
        {
            Console.Clear();
            var servicioShoe = _serviceProvider?.GetService<IShoeService>();
            ListaShoes();
            var shoeId = ValidarDatos.ReadInt("Ingrese el ID del Shoe a Borrar: ");
            var shoe = servicioShoe?.GetShoePorId(shoeId);
            try
            {
                if (shoe != null)
                {
                    servicioShoe?.Borrar(shoe);
                }
                else
                {
                    Console.WriteLine("El ID del Shoe es erroneo");
                    Console.ReadKey();

                }
            }
            catch (Exception ex)
            {

                Console.WriteLine($"ERROR: {ex.Message}");
            }
        }

        private static void EditarShoe()
        {
            Console.Clear();
            var servicioShoe = _serviceProvider?.GetService<IShoeService>();
            var servicioBrand = _serviceProvider?.GetService<IBrandService>();
            var servicioSport = _serviceProvider?.GetService<ISportService>();
            var servicioGenre = _serviceProvider?.GetService<IGenreService>();
            var servicioColor = _serviceProvider?.GetService<IColorService>();
            var servicioSize= _serviceProvider?.GetService<ISizeService>();
            Brand? brand;
            Sport? sport;
            Genre? genre;
            Colour? colour;
            Size? size;

            // Obtener el Shoe a editar
            var shoeId = ValidarDatos.ReadInt("Ingrese el ID de la Shoe a editar:");
            var shoe = servicioShoe?.GetShoePorId(shoeId);

            if (shoe == null)
            {
                Console.WriteLine("Shoe no encontrada.");
                return;
            }
            Console.WriteLine($"Descripción: {shoe.Descripcion}");
            Console.WriteLine($"Brand: {servicioBrand?.GetBrandPorId(shoe.BrandId)?.BrandName}");
            Console.WriteLine($"Color: {servicioColor?.GetColourPorId(shoe.ColourId)?.ColorName}");
            Console.WriteLine($"Genre: {servicioGenre?.GetGenrePorId(shoe.GenreId)?.GenreName}");
            Console.WriteLine($"Sport: {servicioSport?.GetSportPorId(shoe.SportId)?.SportName}");
            Console.WriteLine($"Precio: {shoe.Price}");
            // Editar los detalles de la planta
            shoe.Descripcion = ValidarDatos.ReadString("Ingrese la nueva descripción:");
            shoe.Price = ValidarDatos.ReadDecimal("Ingrese el nuevo precio de costo:");
            // Agregar más propiedades si es necesario
            ListaBrands();
            shoe.BrandId = ValidarDatos.ReadInt("Ingrese el ID de la nueva Brand: ");
            if (shoe.BrandId == 0)
            {
                var brandName = ValidarDatos.ReadString("Ingrese la nueva Brand: ");
                brand = new Brand()
                {
                    BrandId = 0,
                    BrandName = brandName
                };
            }
            else
            {
                brand = servicioBrand?.GetBrandPorId(shoe.BrandId);
            }
            shoe.Brands = brand;
            ListaColors();
            shoe.ColourId = ValidarDatos.ReadInt("Ingrese el ID del nuevo Color: ");
            if (shoe.ColourId == 0)
            {
                var colorName = ValidarDatos.ReadString("Ingrese el nuevo Color: ");
                colour = new Colour()
                {
                    ColourId = 0,
                    ColorName = colorName
                };
            }
            else
            {
                colour = servicioColor?.GetColourPorId(shoe.ColourId);
            }
            shoe.Color = colour;
            ListaGenres();
            shoe.GenreId = ValidarDatos.ReadInt("Ingrese el Id del nuevo Genre: ");
            if (shoe.GenreId == 0)
            {
                var genreName = ValidarDatos.ReadString("Ingrese el nuevo Genre: ");
                genre = new Genre()
                {
                    GenreId = 0,
                    GenreName = genreName
                };
            }
            else
            {
                genre = servicioGenre?.GetGenrePorId(shoe.GenreId);
            }
            shoe.Genres = genre;
            ListaSports();
            shoe.SportId = ValidarDatos.ReadInt("Ingrese el nuevo Sport: ");
            if (shoe.SportId == 0)
            {
                var sportName = ValidarDatos.ReadString("Ingrese el ID del Sport: ");
                sport = new Sport()
                {
                    SportId = 0,
                    SportName = sportName
                };
            }
            else
            {
                sport = servicioSport?.GetSportPorId(shoeId);
            }
            shoe.Sports = sport;
            //Listar Sizes existentes
           var listaSizes = servicioSize?.GetSizes();
            Console.WriteLine("Proveedores disponibles:");
            foreach (var item in listaSizes)
            {
                Console.WriteLine($"ID: {item.SizeId}, Size Number: {item.SizeNumber}");
            }

           // Asignar un nuevo Size
            var SizeId = ValidarDatos
                .ReadInt("Ingrese el ID del nuevo Size (0 para omitir):");

            try
            {
                if (SizeId == 0)
                {
                    servicioShoe?.Editar(shoe, null);
                }
                else
                {
                    servicioShoe?.Editar(shoe, SizeId);
                }

                Console.WriteLine("Shoe actualizado   exitosamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        private static void InsertarShoe()
        {
            Console.Clear();
            //Llamo a los servicios de cada Entidad
            var servicioBrand = _serviceProvider?.GetService<IBrandService>();
            var servcioSport = _serviceProvider?.GetService<ISportService>();
            var servicioGenre = _serviceProvider?.GetService<IGenreService>();
            var servicioColor = _serviceProvider?.GetService<IColorService>();
            var servicioShoe = _serviceProvider?.GetService<IShoeService>();
            var servicioSize = _serviceProvider?.GetService<ISizeService>();
            var shoesizeser = _serviceProvider?.GetService<IShoeSizeService>();


            //Defino variables que voy a utilizar para guardar los datos de la Shoe
            Brand? brand;
            Sport? sport;
            Genre? genre;
            Colour? colour;
            Size? size;
            int cantidad = 0;

            Console.WriteLine("Agregar Shoe");
            //Muestro la lista de Brands y decido si utilizo una Brand que ya existe
            ListaBrands();
            var listaChar = servicioBrand?
                .GetBrands()?
                .Select(x => x.BrandId.ToString()).ToList();
            var brandId = ValidarDatos
                .GetValidOptions("Seleccione el ID de la Brand (N para nuevo):", listaChar);
            //O creo una Nueva Brand para mi Shoe
            if (brandId == "N")
            {
                brandId = "0";
                Console.WriteLine("Ingrese la nueva Brand");
                var brandName = ValidarDatos.ReadString("Ingrese Brand:");

                brand = new Brand()
                {
                    BrandId = 0,
                    BrandName = brandName
                };

            }
            else
            {
                brand = servicioBrand?
                    .GetBrandPorId(Convert.ToInt32(brandId));
            }
            Console.Clear();
            //Muestro la lista de Colors y decido si utilizo un Color que ya existe
            ListaColors();
            var listaColor = servicioColor?.GetColours()?
                .Select(x => x.ColourId.ToString()).ToList();
            var colorId = ValidarDatos.GetValidOptions("Seleccione Color (N para nuevo):",
                listaColor);
            //O creo un Nuevo Color para mi Shoe
            if (colorId == "N")
            {
                colorId = "0";
                var colorName = ValidarDatos.ReadString("Ingrese el nuevo Color:");

                colour = new Colour()
                {
                    ColourId = 0,
                    ColorName = colorName
                };

            }
            else
            {
                colour = servicioColor?
                    .GetColourPorId(Convert.ToInt32(colorId));
            }
            Console.Clear();
            //Muestro la lista de Genres y decido si utilizo un Genre que ya existe
            ListaGenres();
            var listagenre = servicioGenre?.GetGenres()?
                .Select(x => x.GenreId.ToString()).ToList();
            var genreId = ValidarDatos.GetValidOptions("Seleccione Genre (N para nuevo):",
                listagenre);
            //O creo un Nuevo Genre para mi Shoe
            if (genreId == "N")
            {
                genreId = "0";
                Console.WriteLine("Ingreso el nuevo Genre");
                var genreName = ValidarDatos.ReadString("Ingrese el nuevo Genre:");

                genre = new Genre()
                {
                    GenreId = 0,
                    GenreName = genreName
                };

            }
            else
            {
                genre = servicioGenre?
                    .GetGenrePorId(Convert.ToInt32(genreId));
            }
            Console.Clear();
            //Muestro la lista de Sports y decido si utilizo un Sport que ya existe
            ListaSports();
            var listaSport = servcioSport?.GetSports()?
                .Select(x => x.SportId.ToString()).ToList();
            var sportId = ValidarDatos.GetValidOptions("Seleccione Sport (N para nuevo):",
                listaSport);
            //O creo un Nuevo Sport para mi Shoe
            if (sportId == "N")
            {
                sportId = "0";
                var sportName = ValidarDatos.ReadString("Ingrese el nuevo Sport:");

                sport = new Sport()
                {
                    SportId = 0,
                    SportName = sportName
                };
            }
            else
            {
                sport = servcioSport?.GetSportPorId(Convert.ToInt32(sportId));
            }
            Console.Clear();
            //Ingreso el precio, la descripción y el modelo para mi Shoe
            var precio = ValidarDatos.ReadDecimal("Ingrese el precio de la Shoe: ");
            var descripcion = ValidarDatos.ReadString("Descripción:");
            var modelo = ValidarDatos.ReadString("Ingrese un Modelo:");
            //Creo mi Shoe
            var shoe = new Shoe()
            {
                Descripcion = descripcion,
                BrandId = Convert.ToInt32(brandId),
                Brands = brand,
                GenreId = Convert.ToInt32(genreId),
                Genres = genre,
                SportId = Convert.ToInt32(sportId),
                Sports = sport,
                ColourId = Convert.ToInt32(colorId),
                Color = colour,
                Price = precio,
                Model = modelo
            };

            if (servicioShoe != null)
            {
                if (!servicioShoe.Existe(shoe))
                {
                    Console.Clear();
                    do
                    {
                        var respuesta = ValidarDatos.ReadString("Desea que este Shoe tenga varios Sizes? YES(S) NO(N): ");
                        ListaSize();
                        if (respuesta == "n" || respuesta == "N")
                        {
                            var sizeId = ValidarDatos.ReadInt("Ingrese el ID: ");
                            size = servicioSize?.GetSizePorId(sizeId);
                            CreandoShoeConSize(servicioShoe, shoesizeser, size, shoe);
                            break;
                        }
                        else
                        {
                            if (respuesta == "s" || respuesta == "S")
                            {
                                bool avanzar = true;
                                do
                                {
                                    cantidad = ValidarDatos.ReadInt("Ingrese con cuantos Sizes (Entre el 1 y el 45) : ");
                                    if (cantidad < 1 || cantidad > 45)
                                    {
                                        Console.WriteLine("Su valor esta fuera de los parametros");
                                    }
                                    else
                                    {
                                        avanzar = false;
                                    }
                                } while (avanzar);
                                for (int i = 0; i < cantidad; i++)
                                {
                                    var id = ValidarDatos.ReadInt("Ingrese el ID del Size: ");
                                    size = servicioSize?.GetSizePorId(id);
                                    CreandoShoeConSize(servicioShoe, shoesizeser, size, shoe);
                                }
                                Console.WriteLine("Shoe Completado");
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Su elección no es valida");
                            }
                        }

                    } while (true);             
                }
                else
                {
                    Console.WriteLine("Registro Duplicado!!!");
                }
            }
            else
            {
                Console.WriteLine("Error: El servicio de Shoe es nulo.");
            }
            Thread.Sleep(2000);
        }

        private static void CreandoShoeConSize(IShoeService? servicioShoe, IShoeSizeService shoesizeser, Size size, Shoe shoe)
        {
            int cantidad;
            Shoe? Shoeagregado = servicioShoe?.GetShoePorId(shoe.ShoeId);
            cantidad = ValidarDatos.ReadInt("Ingrese el Stock de la Shoe: ");
            int id = shoesizeser.GetId();

            ShoeSizes shoeSizes = new ShoeSizes()
            {
                ShoeSizeId = id,
                Size = size,
                Shoe = shoe,
                QuantityInStock = cantidad
            };
            shoe.ShoeSize.Add(shoeSizes);
            servicioShoe?.Guardar(shoe, cantidad);
            Console.WriteLine("Shoe agregada!!!");
        }

        private static void ListaShoes()
        {
            var servicio = _serviceProvider?.GetService<IShoeService>();
            var tabla = new ConsoleTable("ID", "Brand", "Sport", "Genre", "Color", "Model", "Descripción", "Precio","Size");
            if (servicio?.GetShoes() != null)
            {
                foreach (var item in servicio.GetShoes())
                {
                    tabla.AddRow(item.shoeId, item.brand,
                        item.sport, item.genre, item.color, item.model,
                        item.descripcion, item.price);
                }
                tabla.Options.EnableCount = false;
                tabla.Write();
            }
            Console.WriteLine("Aprete ENTER para continuar");
            Console.ReadLine();
        }

        private static void EditarColor()
        {
            Console.Clear();
            Console.WriteLine("Ingreso de Color a editar");
            var ColorName = Console.ReadLine();
            try
            {
                var servicio = _serviceProvider?.GetService<IColorService>();
                var ColoraEditar = servicio?.GetColourPorNombre(ColorName);
                if (ColoraEditar != null)
                {
                    Console.WriteLine($"Color:{ColoraEditar.ColorName}");
                    Console.WriteLine("Ingrese el nuevo Color:");
                    var nuevoTipoDescripcion = Console.ReadLine();
                    ColoraEditar.ColorName = nuevoTipoDescripcion;
                    if (servicio != null)
                    {
                        if (!servicio.Existe(ColoraEditar))
                        {
                            servicio.Guardar(ColoraEditar);
                            Console.WriteLine("Registro editado!!!");
                        }
                        else
                        {
                            Console.WriteLine("Registro duplicado!!!");
                        }
                    }
                    else
                    {
                        throw new Exception("Servicio no disponible!!");
                    }
                }
                else
                {
                    Console.WriteLine("Registro inexistente!!!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message); ;
            }
            Thread.Sleep(3000);
        }

        private static void BorrarColor()
        {
            Console.Clear();
            Console.WriteLine("Ingrese Color a borrar");
            var ColorName = Console.ReadLine();
            try
            {
                var servicio = _serviceProvider?.GetService<IColorService>();
                var ColoraBorrar = servicio?.GetColourPorNombre(ColorName);
                if (ColoraBorrar != null)
                {
                    if (servicio != null)
                    {
                        if (!servicio.EstaRelacionado(ColoraBorrar))
                        {
                            servicio.Borrar(ColoraBorrar);
                            Console.WriteLine("Registro borrado!!!");
                        }
                        else
                        {
                            Console.WriteLine("Color relacionada!!! Baja denegada");
                        }
                    }
                    else
                    {
                        throw new Exception("Servicio no disponible");
                    }
                }
                else
                {
                    Console.WriteLine("Registro inexistente!!!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message); ;
            }
            Thread.Sleep(3000);

        }

        private static void InsertarColor()
        {
            Console.Clear();
            Console.WriteLine("Ingrese un nuevo Color");
            var colorName = Console.ReadLine();
            if (string.IsNullOrEmpty(colorName) || string.IsNullOrWhiteSpace(colorName))
            {
                Console.WriteLine("Debe ingresar Color");
            }
            else
            {
                Colour colornueva = new Colour()
                {
                    ColorName = colorName
                };

                try
                {
                    var servicio = _serviceProvider?.GetService<IColorService>();
                    if (servicio != null)
                    {
                        if (!servicio.Existe(colornueva))
                        {
                            servicio.Guardar(colornueva);
                            Console.WriteLine("Registro agregado!!!");

                        }
                        else
                        {
                            Console.WriteLine("Registro existente!!!");
                        }
                    }
                    else { Console.WriteLine("Servicio no disponible"); }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message); ;
                }
            }
            Thread.Sleep(3000);

        }

        private static void ListaColors()
        {
            var servicio = _serviceProvider?.GetService<IColorService>();
            var tabla = new ConsoleTable("ID", "Color Name");
            if (servicio?.GetColours() != null)
            {
                foreach (var item in servicio.GetColours())
                {
                    tabla.AddRow(item.ColourId, item.ColorName);
                }
                tabla.Options.EnableCount = false;
                tabla.Write();
            }
            Console.WriteLine("Aprete ENTER para continuar");
            Console.ReadLine();
        }

        private static void EditarGenre()
        {
            Console.Clear();
            Console.WriteLine("Ingreso de Genre a editar");
            var GenreName = Console.ReadLine();
            try
            {
                var servicio = _serviceProvider?.GetService<IGenreService>();
                var GenreaEditar = servicio?.GetGenrePorNombre(GenreName);
                if (GenreaEditar != null)
                {
                    Console.WriteLine($"Genre:{GenreaEditar.GenreName}");
                    Console.WriteLine("Ingrese el nuevo Genre:");
                    var nuevoTipoDescripcion = Console.ReadLine();
                    GenreaEditar.GenreName = nuevoTipoDescripcion;
                    if (servicio != null)
                    {
                        if (!servicio.Existe(GenreaEditar))
                        {
                            servicio.Guardar(GenreaEditar);
                            Console.WriteLine("Registro editado!!!");
                        }
                        else
                        {
                            Console.WriteLine("Registro duplicado!!!");
                        }
                    }
                    else
                    {
                        throw new Exception("Servicio no disponible!!");
                    }
                }
                else
                {
                    Console.WriteLine("Registro inexistente!!!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message); ;
            }
            Thread.Sleep(3000);
        }

        private static void BorrarGenre()
        {
            Console.Clear();
            Console.WriteLine("Ingrese Genre a borrar");
            var GenreName = Console.ReadLine();
            try
            {
                var servicio = _serviceProvider?.GetService<IGenreService>();
                var GenreaBorrar = servicio?
                    .GetGenrePorNombre(GenreName);
                if (GenreaBorrar != null)
                {
                    if (servicio != null)
                    {
                        if (!servicio.EstaRelacionado(GenreaBorrar))
                        {
                            servicio.Borrar(GenreaBorrar);
                            Console.WriteLine("Registro borrado!!!");
                        }
                        else
                        {
                            Console.WriteLine("Genre relacionada!!! Baja denegada");
                        }
                    }
                    else
                    {
                        throw new Exception("Servicio no disponible");
                    }
                }
                else
                {
                    Console.WriteLine("Registro inexistente!!!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message); ;
            }
            Thread.Sleep(3000);
        }

        private static void InsertarGenre()
        {
            Console.Clear();
            Console.WriteLine("Ingrese un nuevo Genre");
            var genreName = Console.ReadLine();
            if (string.IsNullOrEmpty(genreName) || string.IsNullOrWhiteSpace(genreName))
            {
                Console.WriteLine("Debe ingresar Sport");
            }
            else
            {
                Genre gernenueva = new Genre()
                {
                    GenreName = genreName
                };
                try
                {
                    var servicio = _serviceProvider?.GetService<IGenreService>();
                    if (servicio != null)
                    {
                        if (!servicio.Existe(gernenueva))
                        {
                            servicio.Guardar(gernenueva);
                            Console.WriteLine("Registro agregado!!!");
                        }
                        else
                        {
                            Console.WriteLine("Registro existente!!!");
                        }
                    }
                    else { Console.WriteLine("Servicio no disponible"); }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message); ;
                }
            }
            Thread.Sleep(3000);
        }

        private static void ListaGenres()
        {
            var servicio = _serviceProvider?.GetService<IGenreService>();
            var tabla = new ConsoleTable("ID", "Genre Name");
            if (servicio?.GetGenres() != null)
            {
                foreach (var item in servicio.GetGenres())
                {
                    tabla.AddRow(item.GenreId, item.GenreName);
                }
                tabla.Options.EnableCount = false;
                tabla.Write();
            }
            Console.WriteLine("Aprete ENTER para continuar");
            Console.ReadLine();
        }

        private static void EditarSport()
        {
            Console.Clear();
            Console.WriteLine("Ingreso de Sport a editar");
            var SportName = Console.ReadLine();
            try
            {
                var servicio = _serviceProvider?.GetService<ISportService>();
                var SportaEditar = servicio?.GetSportPorNombre(SportName);
                if (SportaEditar != null)
                {
                    Console.WriteLine($"SPORT:{SportaEditar.SportName}");
                    Console.WriteLine("Ingrese el nuevo Sport:");
                    var nuevoTipoDescripcion = Console.ReadLine();
                    SportaEditar.SportName = nuevoTipoDescripcion;
                    if (servicio != null)
                    {
                        if (!servicio.Existe(SportaEditar))
                        {
                            servicio.Guardar(SportaEditar);
                            Console.WriteLine("Registro editado!!!");
                        }
                        else
                        {
                            Console.WriteLine("Registro duplicado!!!");
                        }
                    }
                    else
                    {
                        throw new Exception("Servicio no disponible!!");
                    }
                }
                else
                {
                    Console.WriteLine("Registro inexistente!!!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message); ;
            }
            Thread.Sleep(3000);
        }

        private static void BorrarSport()
        {
            Console.Clear();
            Console.WriteLine("Ingrese Sport a borrar");
            var SportName = Console.ReadLine();
            try
            {
                var servicio = _serviceProvider?.GetService<ISportService>();
                var SportaBorrar = servicio?
                    .GetSportPorNombre(SportName);
                if (SportaBorrar != null)
                {
                    if (servicio != null)
                    {
                        if (!servicio.EstaRelacionado(SportaBorrar))
                        {
                            servicio.Borrar(SportaBorrar);
                            Console.WriteLine("Registro borrado!!!");
                        }
                        else
                        {
                            Console.WriteLine("Sport relacionada!!! Baja denegada");
                        }

                    }
                    else
                    {
                        throw new Exception("Servicio no disponible");
                    }
                }
                else
                {
                    Console.WriteLine("Registro inexistente!!!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message); ;
            }
            Thread.Sleep(3000);
        }

        private static void InsertarSport()
        {
            Console.Clear();
            Console.WriteLine("Ingrese un nuevo Sport");
            var sportName = Console.ReadLine();
            if (string.IsNullOrEmpty(sportName) || string.IsNullOrWhiteSpace(sportName))
            {
                Console.WriteLine("Debe ingresar Sport");
            }
            else
            {
                Sport sportnueva = new Sport()
                {
                    SportName = sportName
                };
                try
                {
                    var servicio = _serviceProvider?.GetService<ISportService>();
                    if (servicio != null)
                    {
                        if (!servicio.Existe(sportnueva))
                        {
                            servicio.Guardar(sportnueva);
                            Console.WriteLine("Registro agregado!!!");
                        }
                        else
                        {
                            Console.WriteLine("Registro existente!!!");
                        }
                    }
                    else { Console.WriteLine("Servicio no disponible"); }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message); ;
                }
            }
            Thread.Sleep(3000);
        }

        private static void ListaSports()
        {
            var servicio = _serviceProvider?.GetService<ISportService>();
            if (servicio?.GetSports() != null)
            {
                var tabla = new ConsoleTable("ID", "Sport Name");
                foreach (var item in servicio.GetSports())
                {
                    tabla.AddRow(item.SportId, item.SportName);
                }
                tabla.Options.EnableCount = false;
                tabla.Write();
            }
            Console.WriteLine("Aprete ENTER para continuar");
            Console.ReadLine();
        }

        private static void EditarBrand()
        {
            Console.Clear();
            ListaBrands();
            Console.Write("Ingrese el nombre de la Brand a editar: ");
            var BrandName = Console.ReadLine();
            try
            {
                var servicio = _serviceProvider?.GetService<IBrandService>();
                var BrandAEditar = servicio?.GetBrandPorNombre(BrandName);
                if (BrandAEditar != null)
                {
                    Console.WriteLine($"BRAND:{BrandAEditar.BrandName}");
                    Console.WriteLine("Ingrese la nueva Brand:");
                    var nuevoTipoDescripcion = Console.ReadLine();
                    BrandAEditar.BrandName = nuevoTipoDescripcion;
                    if (servicio != null)
                    {
                        if (!servicio.Existe(BrandAEditar))
                        {
                            servicio.Guardar(BrandAEditar);
                            Console.WriteLine("Registro editado!!!");
                        }
                        else
                        {
                            Console.WriteLine("Registro duplicado!!!");
                        }
                    }
                    else
                    {
                        throw new Exception("Servicio no disponible!!");
                    }
                }
                else
                {
                    Console.WriteLine("Registro inexistente!!!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message); ;
            }
            Thread.Sleep(3000);
        }

        private static void BorrarBrand()
        {
            Console.Clear();
            ListaBrands();
            Console.Write("Ingrese el nombre de la Brand a borrar: ");
            var BrandName = Console.ReadLine();
            try
            {
                var servicio = _serviceProvider?.GetService<IBrandService>();
                var BrandABorrar = servicio?.GetBrandPorNombre(BrandName);
                if (BrandABorrar != null)
                {
                    if (servicio != null)
                    {
                        if (!servicio.EstaRelacionado(BrandABorrar))
                        {
                            servicio.Borrar(BrandABorrar);
                            Console.WriteLine("Registro borrado!!!");
                        }
                        else
                        {
                            Console.WriteLine("Brand relacionada!!! Baja denegada");
                        }
                    }
                    else
                    {
                        throw new Exception("Servicio no disponible");
                    }
                }
                else
                {
                    Console.WriteLine("Registro inexistente!!!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message); ;
            }
            Thread.Sleep(3000);
        }

        private static void InsertarBrand()
        {
            Console.Clear();
            Console.WriteLine("Ingrese la Brand: ");
            var BrandName = Console.ReadLine();
            Brand brandnueva = new Brand()
            {
                BrandName = BrandName
            };
            try
            {
                var servicio = _serviceProvider?.GetService<IBrandService>();
                if (servicio != null)
                {
                    if (!servicio.Existe(brandnueva))
                    {
                        servicio.Guardar(brandnueva);
                        Console.WriteLine("Registro agregado!!!");
                    }
                    else
                    {
                        Console.WriteLine("Registro existente!!!");
                    }
                }
                else { Console.WriteLine("Servicio no disponible"); }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message); ;
            }
            Thread.Sleep(3000);
        }

        private static void ListaBrands()
        {
            var servicio = _serviceProvider?.GetService<IBrandService>();
            var tabla = new ConsoleTable("ID", "Brand Name");
            if (servicio?.GetBrands() != null)
            {
                foreach (var item in servicio.GetBrands())
                {
                    tabla.AddRow(item.BrandId, item.BrandName);
                }
                tabla.Options.EnableCount = false;
                tabla.Write();
            }
            Console.WriteLine("Aprete ENTER para continuar");
            Console.ReadLine();
        }

    }
}