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
    public partial class frmGenre : Form
    {
        public frmGenre(IGenreService genreService, IShoeService shoeservice)
        {
            InitializeComponent();
            _GenreService = genreService;
            servicioShoe = shoeservice;
        }

        private void toolStripButtonSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
        private readonly IGenreService _GenreService;
        private List<Genre> listaGenres;
        private readonly IShoeService servicioShoe;
        private int pageCount;
        private int pageSize = 8;
        private int pageNum = 0;
        private int recordCount;

        public void Actualizarcantidad()
        {
            txtcantidad.Text = _GenreService.GetCantidad().ToString();
        }
        private void MostrarDatosEnGrilla()
        {
            GridHelper.LimpiarGrilla(dgvDatosGenre);
            if (listaGenres != null)
            {
                foreach (var item in listaGenres)
                {
                    var r = GridHelper.ConstruirFila(dgvDatosGenre);
                    GridHelper.SetearFila(r, item);
                    GridHelper.AgregarFila(r, dgvDatosGenre);
                }
            }
        }

        private void toolStripButtonAgregar_Click(object sender, EventArgs e)
        {
            frmGenreAE frm = new frmGenreAE();
            DialogResult dr = frm.ShowDialog();
            if (dr == DialogResult.Cancel)
            {
                return;
            }
            Genre Genre = frm.GetGenre();
            try
            {
                if (Genre != null)
                {
                    if (!_GenreService.Existe(Genre))
                    {
                        _GenreService.Guardar(Genre);
                        Actualizarcantidad();
                        DataGridViewRow r = GridHelper.ConstruirFila(dgvDatosGenre);
                        GridHelper.SetearFila(r, Genre);
                        GridHelper.AgregarFila(r, dgvDatosGenre);
                        MessageBox.Show("Se agrego el nuevo Genre con exito", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Este Genre ya esxiste!!!!");
                    }
                }
                else
                {
                    MessageBox.Show("El Genre es null");
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine($"ERROR:{ex.Message}");
            }
        }

        private void toolStripButtonBorrar_Click(object sender, EventArgs e)
        {
            if (dgvDatosGenre.SelectedRows.Count == 0)
            {
                return;
            }
            var r = dgvDatosGenre.SelectedRows[0];
            if (r.Tag is not null)
            {
                Genre Genre = (Genre)r.Tag;
                DialogResult dr = MessageBox.Show($"¿Desea dar de baja a {Genre.GenreName}?",
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


                    if (!_GenreService.EstaRelacionado(Genre))
                    {
                        _GenreService.Borrar(Genre);
                        Actualizarcantidad();
                        GridHelper.QuitarFila(r, dgvDatosGenre);
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
            if (dgvDatosGenre.SelectedRows.Count == 0)
            {
                return;
            }
            var r = dgvDatosGenre.SelectedRows[0];
            if (r is null)
            {
                return;
            }
            Genre Genre = (Genre)r.Tag;
            frmGenreAE frm = new frmGenreAE();
            frm.SetGenre(Genre);
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;
            }
            try
            {
                Genre = frm.GetGenre();

                if (!_GenreService.Existe(Genre))
                {
                    _GenreService.Guardar(Genre);
                    GridHelper.SetearFila(r, Genre);
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
            if (dgvDatosGenre.SelectedRows.Count == 0)
            {
                return;
            }
            var r = dgvDatosGenre.SelectedRows[0];
            if (r is null)
            {
                return;
            }
            Genre Genre = (Genre)r.Tag;
            var genre = _GenreService.GetGenrePorId(Genre.GenreId);
            recordCount = servicioShoe.GetCantidad(s => s.Genres == genre);
            pageCount = FormHelper.CalcularPaginas(recordCount, pageSize);
            var lista = servicioShoe.GetListaPaginadaOrdenadaFiltrada(pageNum, pageSize, null, null, null, genre, null);

            frmShoesPorGenre frm = new frmShoesPorGenre(servicioShoe);
            frm.SetDatosParaElPaginadoYFiltro(pageCount, pageNum, pageSize, recordCount, genre);
            frm.SetLista(lista);
            frm.ShowDialog();
        }


        private void frmGenre_Load(object sender, EventArgs e)
        {
            Actualizarcantidad();
            listaGenres = _GenreService?.GetGenres();
            MostrarDatosEnGrilla();
        }

    }
}
