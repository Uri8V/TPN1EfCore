// See https://aka.ms/new-console-template for more information
using ConsoleTables;
using Microsoft.Extensions.DependencyInjection;
using TPN1EfCore.Entidades;
using TPN1EfCore.IOC;
using TPN1EfCore.Servicios.Interfaces;
internal class Program 
{
    private static IServiceProvider? _serviceProvider; //Creo la variable para utilizar más tarde
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
            Console.WriteLine("=======================");
            Console.WriteLine("5. Listado de Sports");
            Console.WriteLine("6. Ingresar Sport");
            Console.WriteLine("7. Borrar Sport");
            Console.WriteLine("8. Editar Sport");
            Console.WriteLine("=======================");
            Console.WriteLine("9. Listado de Genres");
            Console.WriteLine("10. Ingresar Genre");
            Console.WriteLine("11. Borrar Genre");
            Console.WriteLine("12. Editar Genre");
            Console.WriteLine("=======================");
            Console.WriteLine("13. Listado de Colors");
            Console.WriteLine("14. Ingresar Color");
            Console.WriteLine("15. Borrar Color");
            Console.WriteLine("16. Editar Color");
            Console.WriteLine("=======================");
            Console.WriteLine("17. Listado de Shoes");
            Console.WriteLine("18. Ingresar Shoe");
            Console.WriteLine("19. Borrar Shoe");
            Console.WriteLine("20. Editar Shoe");
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
                case "17":
                    Console.Clear();
                    ListaShoes();
                    break;
                case "18":
                    InsertarShoe();
                    break;
                case "19":
                    BorrarColor();
                    break;
                case "20":
                    EditarColor();
                    break;
                default:
                    fin = false;
                    Console.Clear();
                    Console.WriteLine("Usted a Salido del programa");
                    break;

            }
        }
    }

    private static void InsertarShoe()
    {
        Console.Clear();
        Console.WriteLine("Ingrese un nuevo Color");
        var Color = Console.ReadLine();
        if (string.IsNullOrEmpty(Color) || string.IsNullOrWhiteSpace(Color))
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

    private static void ListaShoes()
    {
        var servicio = _serviceProvider?.GetService<IShoeService>();
        var tabla = new ConsoleTable("ID", "Brand","Sport","Genre","Color","Model","Descripción","Precio" );
        if (servicio?.GetShoes() != null)
        {
            foreach (var item in servicio.GetShoes())
            {
                tabla.AddRow(item.ShoeId, item.Brands, item.Sports,item.Genres, item.Color,item.Model,item.Descripcion,item.Price);
            }
            tabla.Options.EnableCount = false;
            tabla.Write();
        }
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
            var ColoraBorrar = servicio?
                .GetColourPorNombre(ColorName);
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
            Genre  gernenueva = new Genre()
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
        Console.ReadLine();
    }

    private static void EditarBrand()
    {
        Console.Clear();
        Console.WriteLine("Ingreso de Brand a editar");
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
        Console.WriteLine("Ingrese Brand a borrar");
        var BrandName = Console.ReadLine();
        try
        {
            var servicio = _serviceProvider?.GetService<IBrandService>();
            var BrandABorrar = servicio?
                .GetBrandPorNombre(BrandName);
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
        var servicio=_serviceProvider?.GetService<IBrandService>();
        var tabla = new ConsoleTable("ID","Brand Name");
        if (servicio?.GetBrands()!=null)
        {
            foreach (var item in servicio.GetBrands())
            {
                tabla.AddRow(item.BrandId,item.BrandName);
        
            }
            tabla.Options.EnableCount = false;
            tabla.Write();
        }
        Console.ReadLine();
    }
}
