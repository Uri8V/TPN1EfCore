using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TPN1EfCore.Datos;
using TPN1EfCore.Datos.Interfaces;
using TPN1EfCore.Datos.Repositories;
using TPN1EfCore.Servicios.Interfaces;
using TPN1EfCore.Servicios.Servicios;

namespace TPN1EfCore.IOC
{
    public static class DI
    {
        //Esto me permite Inicializar los servicios y repositorios una sola vez y después utilizarlos
        //injecctando, además esta clase va a cerrar sus recursos automaticamente como sucedia cuando usamos los using
        public static IServiceProvider ConfiguracionServicios()
        {
            var servicios = new ServiceCollection();// En esta variable se van a cargar todos los servicios que yo quiera inyectar
             //Para que el escope funcione las clases deben heredar de las interfaces
            servicios.AddScoped <IBrandRepository, BrandRepository> ();//Cada vez que nosotros le pidamos un IbranRepo, nos va mandar un BrandRepo, lo mismo con los demás
            servicios.AddScoped<IBrandService, BrandService> ();

            servicios.AddScoped<ISportRepository, SportRepository>();
            servicios.AddScoped<ISportService, SportService>();

            servicios.AddScoped<IGenreRepository, GenreRepository> ();
            servicios.AddScoped<IGenreService, GenreService> ();    

            servicios.AddScoped<IColorRepository, ColorRepository> ();
            servicios.AddScoped<IColorService, ColorService> ();

            servicios.AddScoped<IShoeRepository, ShoeRepository> ();
            servicios.AddScoped<IShoeService, ShoeService> ();

            servicios.AddScoped<ISizeRepository, SizeRepository> ();
            servicios.AddScoped<ISizeService, SizeService> ();

            servicios.AddScoped<IShoeSizeRepository,ShoeSizeRepository> ();
            servicios.AddScoped<IShoeSizeService, ShoeSizeService> (); 

            servicios.AddScoped<IUnitOfWork, UnitOfWork>();

            servicios.AddDbContext<ShoesDbContext>(opciones =>
            {
                opciones.UseSqlServer(@"Data Source=.; 
                        Initial Catalog=ShoesEFCore; 
                        Trusted_Connection=true; 
                        TrustServerCertificate=true;");
            });

            return servicios.BuildServiceProvider();
        }
    }
}
