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
using TPN1EfCore.Servicios.Servicios;
using TPN1EfCore.Windows.Helpers;

namespace TPN1EfCore.Windows
{
    public partial class frmColor : Form
    {
        public frmColor(IColorService ColorService, IShoeService shoeService)
        {
            InitializeComponent();
            _colorService = ColorService;
            servicioShoe = shoeService;
        }
        private readonly IColorService _colorService;
        private List<Colour> listaColors;
        private readonly IShoeService servicioShoe;
        private int pageCount;
        private int pageSize = 1;
        private int pageNum = 0;
        private int recordCount;


        private void toolStripButtonSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmColor_Load(object sender, EventArgs e)
        {
            Actualizarcantidad();
            listaColors = _colorService?.GetColours();
            MostrarDatosEnGrilla();
        }
        public void Actualizarcantidad()
        {
            txtcantidad.Text = _colorService.GetCantidad().ToString();
        }
        private void MostrarDatosEnGrilla()
        {
            GridHelper.LimpiarGrilla(dgvDatosColor);
            if (listaColors != null)
            {
                foreach (var item in listaColors)
                {
                    var r = GridHelper.ConstruirFila(dgvDatosColor);
                    GridHelper.SetearFila(r, item);
                    GridHelper.AgregarFila(r, dgvDatosColor);
                }
            }
        }

        private void toolStripButtonAgregar_Click(object sender, EventArgs e)
        {
            frmColorAE frm = new frmColorAE();
            DialogResult dr = frm.ShowDialog();
            if (dr == DialogResult.Cancel)
            {
                return;
            }
            Colour Color = frm.GetColor();
            try
            {
                if (Color != null)
                {
                    if (!_colorService.Existe(Color))
                    {
                        _colorService.Guardar(Color);
                        Actualizarcantidad();
                        DataGridViewRow r = GridHelper.ConstruirFila(dgvDatosColor);
                        GridHelper.SetearFila(r, Color);
                        GridHelper.AgregarFila(r, dgvDatosColor);
                        MessageBox.Show("Se agrego la nueva Color con exito", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Esta Color ya esxiste!!!!");
                    }
                }
                else
                {
                    MessageBox.Show("La Color es null");
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine($"ERROR:{ex.Message}");
            }
        }

        private void toolStripButtonBorrar_Click(object sender, EventArgs e)
        {
            if (dgvDatosColor.SelectedRows.Count == 0)
            {
                return;
            }
            var r = dgvDatosColor.SelectedRows[0];
            if (r.Tag is not null)
            {
                Colour Color = (Colour)r.Tag;
                DialogResult dr = MessageBox.Show($"¿Desea dar de baja a {Color.ColorName}?",
                    "Confirmar Operación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2);
                if (dr == DialogResult.No)
                {
                    return;
                }
                try
                {


                    if (!_colorService.EstaRelacionado(Color))
                    {
                        _colorService.Borrar(Color);
                        Actualizarcantidad();
                        GridHelper.QuitarFila(r, dgvDatosColor);
                        MessageBox.Show("Registro Borrado Satisfactoriamente!!!",
                            "Mensaje",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Registro Relacionado...Baja denegada!!!",
                            "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message,
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        private void toolStripButtonEditar_Click(object sender, EventArgs e)
        {
            if (dgvDatosColor.SelectedRows.Count == 0)
            {
                return;
            }
            var r = dgvDatosColor.SelectedRows[0];
            if (r is null)
            {
                return;
            }
            Colour Color = (Colour)r.Tag;
            frmColorAE frm = new frmColorAE();
            frm.SetColor(Color);
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;
            }
            try
            {
                Color = frm.GetColor();

                if (!_colorService.Existe(Color))
                {
                    _colorService.Guardar(Color);
                    GridHelper.SetearFila(r, Color);
                    MessageBox.Show("Registro Editado Satisfactoriamente!!!", "Mensaje",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Registro duplicado", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void toolStripButtonConsulta_Click(object sender, EventArgs e)
        {
            if (dgvDatosColor.SelectedRows.Count == 0)
            {
                return;
            }
            var r = dgvDatosColor.SelectedRows[0];
            if (r is null)
            {
                return;
            }
            Colour Color = (Colour)r.Tag;
            var color = _colorService.GetColourPorId(Color.ColourId);
            recordCount = servicioShoe.GetCantidad(s => s.Color == Color);
            pageCount = FormHelper.CalcularPaginas(recordCount, pageSize);
            var lista = servicioShoe.GetListaPaginadaOrdenadaFiltrada(pageNum, pageSize, null, null, null, null, color);

            frmShoesPorColor frm = new frmShoesPorColor(servicioShoe);
            frm.SetDatosParaElPaginadoYFiltro(pageCount, pageNum, pageSize, recordCount, Color);
            frm.SetLista(lista);
            frm.ShowDialog();
        }
    }
}
