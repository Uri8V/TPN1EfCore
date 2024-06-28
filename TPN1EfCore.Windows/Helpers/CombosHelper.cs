using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPN1EfCore.Entidades;
using TPN1EfCore.Servicios.Interfaces;

namespace TPN1EfCore.Windows.Helpers
{
    public static class CombosHelper
    {
        public static void CargarCombosPaginas(int pageCount, ref ComboBox cbo)
        {
            cbo.Items.Clear();
            for (int page = 1; page <= pageCount; page++)
            {
                cbo.Items.Add(page.ToString());
            }
            cbo.SelectedIndex = 0;
        }

        public static void CargarComboBrand(IServiceProvider serviceProvider, ref ComboBox cbo)
        {
            var servicio = serviceProvider.GetService<IBrandService>();

            var lista = servicio?.GetBrands();
            var defaultBrand = new Brand
            {
                BrandName = "Seleccione la Brand"
            };
            lista.Insert(0, defaultBrand);
            cbo.DataSource = lista;
            cbo.DisplayMember = "BrandName";
            cbo.ValueMember = "BrandId";
            cbo.SelectedIndex = 0;
        }

        public static void CargarComboSport(IServiceProvider serviceProvider, ref ComboBox cbo)
        {
            var servicio = serviceProvider.GetService<ISportService>();

            var lista = servicio?.GetSports();
            var defaultSport = new Sport
            {
                SportName = "Seleccione el Sport"
            };
            lista.Insert(0, defaultSport);
            cbo.DataSource = lista;
            cbo.DisplayMember = "SportName";
            cbo.ValueMember = "SportId";
            cbo.SelectedIndex = 0;
        }

        public static void CargarComboGenre(IServiceProvider serviceProvider, ref ComboBox cbo)
        {
            var servicio = serviceProvider.GetService<IGenreService>();

            var lista = servicio?.GetGenres();
            var defaultGenre = new Genre
            {
                GenreName = "Seleccione el Genre"
            };
            lista.Insert(0, defaultGenre);

            cbo.DataSource = lista;
            cbo.DisplayMember = "GenreName";
            cbo.ValueMember = "GenreId";
            cbo.SelectedIndex = 0;
        }

        public static void CargarComboColor(IServiceProvider serviceProvider, ref ComboBox cbo)
        {
            var servicio = serviceProvider.GetService<IColorService>();

            var lista = servicio?.GetColours();
            var defaultColor = new Colour
            {
                ColorName = "Seleccione el Color"

            };
            lista.Insert(0, defaultColor);

            cbo.DataSource = lista;
            cbo.DisplayMember = "ColorName";
            cbo.ValueMember = "ColourId";
            cbo.SelectedIndex = 0;
        }

        //public static void CargarComboFormBrand(IServiceProvider serviceProvider, ref ToolStripComboBox cbo)
        //{
        //    var servicio = serviceProvider.GetService<IBrandService>();
        //    // Obtener la lista de tipos de envases del repositorio

        //    var lista = servicio?.GetBrands();
        //    var defaultBrand = new Brand
        //    {
        //        BrandName = "Seleccione"
        //    };



        //    // Limpiar el ToolStripComboBox
        //    cbo.Items.Clear();
        //    lista?.Insert(0, defaultBrand);
        //    // Agregar los tipos de envases al ToolStripComboBox
        //    foreach (Brand brand in lista)
        //    {
        //        cbo.Items.Add(brand.BrandName);
        //    }

        //    // Seleccionar el primer elemento del ToolStripComboBox si hay elementos
        //    if (lista.Count > 0)
        //    {
        //        cbo.SelectedIndex = 0;
        //    }
        //}
        //public static void CargarComboFormSport(IServiceProvider serviceProvider, ref ToolStripComboBox cbo)
        //{
        //    var servicio = serviceProvider.GetService<ISportService>();
        //    // Obtener la lista de tipos de envases del repositorio

        //    var lista = servicio?.GetSports();
        //    var defaultSport = new Sport
        //    {
        //        SportName = "Seleccione"
        //    };



        //    // Limpiar el ToolStripComboBox
        //    cbo.Items.Clear();
        //    lista.Insert(0, defaultSport);
        //    // Agregar los tipos de envases al ToolStripComboBox
        //    foreach (Sport sport in lista)
        //    {
        //        cbo.Items.Add(sport.SportName);
        //    }

        //    // Seleccionar el primer elemento del ToolStripComboBox si hay elementos
        //    if (lista.Count > 0)
        //    {
        //        cbo.SelectedIndex = 0;
        //    }
        //}
        //public static void CargarComboFormGenre(IServiceProvider serviceProvider, ref ToolStripComboBox cbo)
        //{
        //    var servicio = serviceProvider.GetService<IGenreService>();
        //    // Obtener la lista de tipos de envases del repositorio

        //    var lista = servicio?.GetGenres();
        //    var defaultGenre = new Genre
        //    { 
        //        GenreName = "Seleccione"
        //    };



        //    // Limpiar el ToolStripComboBox
        //    cbo.Items.Clear();
        //    lista.Insert(0, defaultGenre);
        //    // Agregar los tipos de envases al ToolStripComboBox
        //    foreach (Genre  genre in lista)
        //    {
        //        cbo.Items.Add(genre.GenreName);
        //    }

        //    // Seleccionar el primer elemento del ToolStripComboBox si hay elementos
        //    if (lista.Count > 0)
        //    {
        //        cbo.SelectedIndex = 0;
        //    }
        //}

        //public static void CargarComboFormColor(IServiceProvider serviceProvider, ref ToolStripComboBox cbo)
        //{
        //    var servicio = serviceProvider.GetService<IColorService>();
        //    // Obtener la lista de tipos de envases del repositorio

        //    var lista = servicio?.GetColours();
        //    var defaultColor = new Colour
        //    {
        //        ColorName = "Seleccione"
        //    };



        //    // Limpiar el ToolStripComboBox
        //    cbo.Items.Clear();
        //    lista.Insert(0, defaultColor);
        //    // Agregar los tipos de envases al ToolStripComboBox
        //    foreach (Colour colour in lista)
        //    {
        //        cbo.Items.Add(colour.ColorName);
        //    }

        //    // Seleccionar el primer elemento del ToolStripComboBox si hay elementos
        //    if (lista.Count > 0)
        //    {
        //        cbo.SelectedIndex = 0;
        //    }
        //}

    }
}
