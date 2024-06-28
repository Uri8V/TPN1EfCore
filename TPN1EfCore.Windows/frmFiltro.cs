using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TPN1EfCore.Entidades;
using TPN1EfCore.Servicios.Interfaces;
using TPN1EfCore.Windows.Helpers;

namespace TPN1EfCore.Windows
{
    public partial class frmFiltro : Form
    {
        private readonly IServiceProvider? _serviceProvider;
        public frmFiltro(IServiceProvider? serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmFiltro_Load(object sender, EventArgs e)
        {
            CombosHelper.CargarComboBrand(_serviceProvider, ref cbBrand);
            CombosHelper.CargarComboSport(_serviceProvider, ref cbSport);
            CombosHelper.CargarComboGenre(_serviceProvider, ref cbGenre);
            CombosHelper.CargarComboColor(_serviceProvider, ref cbColor);
        }
        private Func<Shoe, bool>? filtro;
        private Brand? brandFiltro;
        private Sport? sportFiltro;
        private Genre? genreFiltro;
        private Colour? colorFiltro;
        private decimal precioMinimo;
        private decimal precioMaximo;
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            var _serviceBrand = _serviceProvider?.GetService<IBrandService>();
            var _serviceSport = _serviceProvider?.GetService<ISportService>();
            var _serviceGenre = _serviceProvider?.GetService<IGenreService>();
            var _serviceColor = _serviceProvider?.GetService<IColorService>();
            if (ValidarDatos())
            {
                if (cbBrand.SelectedIndex != 0)
                {
                    brandFiltro = _serviceBrand?.GetBrandPorId(((Brand?)cbBrand.SelectedItem).BrandId);
                    Func<Shoe, bool> brandfiltro = p => p.Brands == brandFiltro;
                    filtro = filtro == null ? brandfiltro : filtro.And(brandfiltro);
                }
                if (cbSport.SelectedIndex != 0)
                {
                    sportFiltro = _serviceSport?.GetSportPorId(((Sport?)cbSport.SelectedItem).SportId);
                    Func<Shoe, bool> sportfiltro = p => p.Sports == sportFiltro;
                    filtro = filtro == null ? sportfiltro : filtro.And(sportfiltro);
                }
                if (cbGenre.SelectedIndex != 0)
                {
                    genreFiltro = _serviceGenre?.GetGenrePorId(((Genre?)cbGenre.SelectedItem).GenreId);
                    Func<Shoe, bool> genrefiltro = p => p.Genres == genreFiltro;
                    filtro = filtro == null ? genrefiltro : filtro.And(genrefiltro);
                }
                if (cbColor.SelectedIndex != 0)
                {
                    colorFiltro = _serviceColor?.GetColourPorId(((Colour?)cbColor.SelectedItem).ColourId);
                    Func<Shoe, bool> colorfiltro = p => p.Color == colorFiltro;
                    filtro = filtro == null ? colorfiltro : filtro.And(colorfiltro);
                }
                if (checkSi.Checked==true)
                {
                    precioMaximo = decimal.Parse(txtMaximo.Text);
                    Func<Shoe, bool> preciofiltromax = p => p.Price <= precioMaximo;
                    filtro =filtro==null? preciofiltromax: filtro.And(preciofiltromax);
                    precioMinimo=decimal.Parse(txtMinimo.Text);
                    Func<Shoe,bool> preciofiltroMin= p=>p.Price>=precioMinimo;
                    filtro.And(preciofiltroMin);
                }
                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidarDatos()
        {
            errorProvider1.Clear();
            bool valido = true;
            if (cbBrand.SelectedIndex == 0 && cbSport.SelectedIndex == 0 && cbGenre.SelectedIndex == 0 && cbColor.SelectedIndex == 0 && checkSi.Checked==false)
            {
                errorProvider1.SetError(cbBrand, "Debe seleccionar aunque sea un filtro");
                valido = false;
            }
            if (checkSi.Checked==true) 
            {
                if (!decimal.TryParse(txtMaximo.Text,out precioMaximo))
                {
                    errorProvider1.SetError(txtMaximo, "Debe ingresar un precio");
                    valido = false;
                }
                if (precioMaximo<precioMinimo)
                {
                    errorProvider1.SetError(txtMaximo, "El precio Minimo NO puede ser superioral precio máximo");
                    valido = false;
                }
                if (precioMaximo<0 || precioMinimo<0)
                {
                    errorProvider1.SetError(txtMinimo, "Los precios no pueden ser menores a cero");
                    errorProvider1.SetError(txtMaximo, "Los precios no pueden ser menores a cero");
                    valido=false;
                }
                if (precioMaximo==precioMinimo)
                {
                    errorProvider1.SetError(txtMaximo, "Los precios no pueden ser iguales");
                    errorProvider1.SetError(txtMinimo, "Los precios no pueden ser iguales");
                    valido=false;
                }
                if (!decimal.TryParse(txtMinimo.Text, out  precioMinimo))
                {
                    errorProvider1.SetError(txtMinimo, "Debe ingresar un precio");
                    valido = false;
                }

            }
            return valido;
        }

        public Func<Shoe, bool>? GetFiltro()
        {
            return filtro;
        }

        internal Brand? GetFiltroBrand()
        {
            return brandFiltro;
        }

        internal Sport? GetFiltroSport()
        {
            return sportFiltro;
        }

        internal Genre? GetFiltroGenre()
        {
            return genreFiltro;
        }

        internal Colour? GetFiltroColor()
        {
            return colorFiltro;
        }

        private void checkSi_CheckedChanged(object sender, EventArgs e)
        {
            if (checkSi.Checked==true)
            {
                txtMaximo.Enabled = true;
                txtMinimo.Enabled = true;
            }
            else
            {
                txtMaximo.Enabled = false;
                txtMinimo.Enabled = false;
            }
        }

        internal decimal? GetMaximo()
        {
            return precioMaximo;
        }

        internal decimal? GetMinimo()
        {
            return precioMinimo;
        }
    }
}
