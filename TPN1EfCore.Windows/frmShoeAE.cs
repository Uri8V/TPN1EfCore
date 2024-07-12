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
using Size = TPN1EfCore.Entidades.Size;

namespace TPN1EfCore.Windows
{
    public partial class frmShoeAE : Form
    {
        private readonly IServiceProvider? _serviceProvider;
        private readonly ISizeService? _sizeService;
        private Shoe? shoe;
        private Brand? brand;
        private Sport? sport;
        private Genre? genre;
        private Colour? colour;
        private List<Size>? _lista;
        private List<Size>? _listaParaCrearShoe;
        private List<int> stock;
        private bool? editado;
        public frmShoeAE(IServiceProvider? serviceProvider, ISizeService? sizeService, List<Size>? lista, bool editar)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
            _sizeService = sizeService;
            _lista = lista;
            editado = editar;
        }

        private void frmShoeAE_Load(object sender, EventArgs e)
        {
            _listaParaCrearShoe = new List<Size>();
            stock = new List<int>();
            CombosHelper.CargarComboBrand(_serviceProvider, ref cbBrand);
            CombosHelper.CargarComboSport(_serviceProvider, ref cbSport);
            CombosHelper.CargarComboGenre(_serviceProvider, ref cbGenre);
            CombosHelper.CargarComboColor(_serviceProvider, ref cbColor);
            MostrarDatosEnGrilla();
            if (shoe != null)
            {
                cbBrand.SelectedValue = shoe.BrandId;
                cbSport.SelectedValue = shoe.SportId;
                cbGenre.SelectedValue = shoe.GenreId;
                cbColor.SelectedValue = shoe.ColourId;
                txtModelo.Text = shoe.Model;
                txtPrecio.Text = shoe.Price.ToString();
                txtDescripcion.Text = shoe.Descripcion;
            }

        }

        private void MostrarDatosEnGrilla()
        {
            GridHelper.LimpiarGrilla(dgvDatos);
            foreach (var item in _lista)
            {
                var r = GridHelper.ConstruirFila(dgvDatos);
                GridHelper.SetearFila(r, item);
                r.Cells[1].Value = "Agregar";
                GridHelper.AgregarFila(r, dgvDatos);
            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSport.SelectedIndex != 0)
            {
                sport = (Sport?)cbSport.SelectedItem;
            }
            else
            {
                sport = null;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        public Shoe? GetShoe()
        {
            return shoe;
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (shoe == null)
                {
                    shoe = new Shoe();
                }
                shoe.Model = txtModelo.Text;
                shoe.Descripcion = txtDescripcion.Text;
                shoe.Price = decimal.Parse(txtPrecio.Text);
                //shoe.Brands = (Brand?)cbBrand.SelectedItem; Ya no podemos hacerlo de esta forma ya que si queremos ingresar una entidad nueva
                //shoe.BrandId = cbBrand.SelectedIndex;       no la va a tomar y va crear una con el mensaje "Seleccione una Brand" y va a tomar su ID
                //shoe.Sports=(Sport?)cbSport.SelectedItem;   por lo cual la entidad que queríamos crear no va a poder existir porque va a ser reemplazada
                //shoe.SportId = cbSport.SelectedIndex;       por el mensaje.
                shoe.Brands = brand;
                shoe.BrandId = brand.BrandId;
                shoe.Sports = sport;
                shoe.SportId = sport.SportId;
                shoe.Genres = genre;
                shoe.GenreId = genre.GenreId;
                shoe.Color = colour;
                shoe.ColourId = colour.ColourId;
                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (cbBrand.SelectedIndex == 0 && brand == null)
            {
                errorProvider1.SetError(cbBrand, "Debe selecionar una Brand");
                valido = false;
            }
            if (cbSport.SelectedIndex == 0 && sport == null)
            {
                errorProvider1.SetError(cbSport, "Debe seleccionar un Sport");
                valido = false;
            }
            if (cbGenre.SelectedIndex == 0 && genre == null)
            {
                errorProvider1.SetError(cbGenre, "Debe seleccionar un Genre");
                valido = false;
            }
            if (cbColor.SelectedIndex == 0 && colour == null)
            {
                errorProvider1.SetError(cbColor, "Debe seleccionar un Color");
                valido = false;
            }
            if (!decimal.TryParse(txtPrecio.Text, out decimal precio) || precio <= 0)
            {
                errorProvider1.SetError(txtPrecio, "Debe ingrsar un precio y debe ser mayor a 0");
                valido = false;
            }
            if (string.IsNullOrEmpty(txtModelo.Text) || string.IsNullOrWhiteSpace(txtModelo.Text))
            {
                errorProvider1.SetError(txtModelo, "Debe ingresar un Modelo de Shoe");
                valido = false;
            }
            if (string.IsNullOrEmpty(txtDescripcion.Text) || string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                errorProvider1.SetError(txtDescripcion, "Debe ingresar una descripción para la Shoe");
                valido = false;
            }
            if (editado==false)
            {
                if (_listaParaCrearShoe?.Count == 0)
                {
                    errorProvider1.SetError(dgvDatos, "Debe seleccionar un Size");
                    valido = false;
                } 
            }
            return valido;

        }

        private void btnAgregarBrand_Click(object sender, EventArgs e)
        {
            frmBrandAE frm = new frmBrandAE();
            DialogResult dr = frm.ShowDialog();
            if (dr == DialogResult.Cancel) { return; }
            brand = frm.GetBrand();
            lblBrandNueva.Visible = true;
        }

        private void btnAgregarSport_Click(object sender, EventArgs e)
        {
            frmSportAE frm = new frmSportAE();
            DialogResult dr = frm.ShowDialog();
            if (dr == DialogResult.Cancel) { return; }
            sport = frm.GetSport();
            lblSportNuevo.Visible = true;
        }

        private void btnAgregarGenre_Click(object sender, EventArgs e)
        {
            frmGenreAE frm = new frmGenreAE();
            DialogResult dr = frm.ShowDialog();
            if (dr == DialogResult.Cancel) { return; }
            genre = frm.GetGenre();
            lblGenreNuevo.Visible = true;
        }

        private void btnAgregarColor_Click(object sender, EventArgs e)
        {
            frmColorAE frm = new frmColorAE();
            DialogResult dr = frm.ShowDialog();
            if (dr == DialogResult.Cancel) { return; }
            colour = frm.GetColor();
            lblColorNuevo.Visible = true;
        }

        private void cbColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbColor.SelectedIndex != 0)
            {
                colour = (Colour?)cbColor.SelectedItem;
            }
            else
            {
                colour = null;
            }
        }

        private void cbGenre_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbGenre.SelectedIndex != 0)
            {
                genre = (Genre?)cbGenre.SelectedItem;
            }
            else
            {
                genre = null;
            }
        }

        private void cbBrand_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbBrand.SelectedIndex != 0)
            {
                brand = (Brand?)cbBrand.SelectedItem;
            }
            else
            {
                brand = null;
            }
        }

        public void SetShoe(Shoe? _shoe)
        {
            shoe = _shoe;
        }

        private void dgvDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                var r = dgvDatos.SelectedRows[0];
                Size? size = _sizeService?.GetSizePorDecimal((decimal)r.Cells[0].Value);
                _listaParaCrearShoe?.Add(size);
                frmIngresarStock frm= new frmIngresarStock();
                DialogResult dr= frm.ShowDialog(this);
                stock.Add(frm.GetStock());
                dgvDatos.Rows.Remove(r);
            }
        }

        internal List<Size>? GetSizesSeleccionados()
        {
            return _listaParaCrearShoe;
        }

        internal List<int> GetStockSeleccionado()
        {
            return stock;
        }
    }
}
