using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPN1EfCore.Entidades;

namespace TPN1EfCore.Datos
{
    public class ShoesDbContext:DbContext
    {
        public ShoesDbContext()
        {
            
        }
        public ShoesDbContext(DbContextOptions<ShoesDbContext> options):base(options)
        {
            
        }
        //Creo la conexión para la base de datos que voy a crear y postereormente usar
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=.; Initial Catalog=ShoesEFCore; Trusted_Connection=True;
                        TrustServerCertificate=True");
        }
        //Estos DbSet se los podría considerar tablas que se van a crear en la Base de Datos
        //estos son muy importantes ya que de estos la migración puede darse una idea de como crear la entidad en la BD
        //las propiedades de las entidades son las que le dan forma a las tablas, le indican cuantas columnas y sus respectivos tipos de datos 
        public DbSet<Brand> Brands { get; set; } //Acordarse de poner los DbSet como publicos para poder usarlas en otras capas
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Sport> Sports { get; set; }
        public DbSet<Colour> Colors { get; set; }
        public DbSet<Shoe> Shoes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var brandList = new List<Brand>()
            {
                new Brand()
                {
                    BrandId = 1,
                    BrandName="Nike"
                },
                new Brand()
                {
                    BrandId=2,
                    BrandName="Adidas"
                },
                new Brand()
                {
                    BrandId=3,
                    BrandName="Puma"
                }
            };
            var colorList = new List<Colour>()
            {
                new Colour()
                {
                    ColourId=1,
                    ColorName="Lila"
                },
                new Colour()
                {
                    ColourId=2,
                    ColorName="Violeta"
                },
                new Colour()
                {
                    ColourId=3,
                    ColorName="Purpura"
                }
            };
            var genreList = new List<Genre>()
            {
                new()
                {
                    GenreId=1,
                    GenreName="Masculino"
                },
                new()
                {
                    GenreId=2,
                    GenreName="Femenino"
                },
                new()
                {
                    GenreId=3,
                    GenreName="Unisex"
                }
            };
            var sportList = new List<Sport>()
            {
                new()
                {
                    SportId=1,
                    SportName="Futbol"
                },
                new()
                {
                    SportId=2,
                    SportName="Voley"
                },
                new()
                {
                    SportId=3,
                    SportName="Hokey"
                }
            };
            
            modelBuilder.Entity<Brand>(entity =>
            {
                entity.ToTable("Brands");//Le decimos en que tabla trabajar
                entity.HasIndex(p => p.BrandName).IsUnique();//Acá hicimos que la propiedad sea única
                entity.Property(p => p.BrandName).HasMaxLength(50);//Le decimos que esta propiedad tenga un máximo de longitud de 50
                entity.HasData(brandList);//Agregamos una lista de datos a la tabla
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.ToTable("Genres");
                entity.HasIndex(p => p.GenreName).IsUnique();
                entity.Property(p => p.GenreName).HasMaxLength(10);
                entity.HasData(genreList);
            });

            modelBuilder.Entity<Sport>(entity =>
            {
                entity.ToTable("Sports");
                entity.HasIndex(p => p.SportName).IsUnique();
                entity.Property(p => p.SportName).HasMaxLength(20);
                entity.HasData(sportList);
            });
            modelBuilder.Entity<Colour>(entity =>
            {
                entity.ToTable("Colors");
                entity.HasIndex(p => p.ColorName).IsUnique();
                entity.Property(p => p.ColorName).HasMaxLength(50);
                entity.HasData(colorList);
            });

            //Acá modificamos las propiedades que deseamos
            modelBuilder.Entity<Shoe>(entity => 
            {
                entity.Property(p => p.Price).HasColumnType("decimal (10,2)");
                entity.Property(p => p.Model).HasMaxLength(150);
            });

        }
    }
}
