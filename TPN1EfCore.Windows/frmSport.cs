using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TPN1EfCore.Entidades;
using TPN1EfCore.Servicios.Interfaces;
using TPN1EfCore.Windows.Helpers;

namespace TPN1EfCore.Windows
{
    public partial class frmSport : Form
    {
        private readonly ISportService _sportService;
        private List<Sport> listaSports;
        private readonly IShoeService servicioShoe;
        private int pageCount;
        private int pageSize = 8;
        private int pageNum = 0;
        private int recordCount;
        public frmSport(ISportService sportService, IShoeService shoeservice)
        {
            InitializeComponent();
            _sportService = sportService;
            servicioShoe = shoeservice;
        }
        public void Actualizarcantidad()
        {
            txtcantidad.Text = _sportService.GetCantidad().ToString();
        }
        private void MostrarDatosEnGrilla()
        {
            GridHelper.LimpiarGrilla(dgvDatosSport);
            if (listaSports != null)
            {
                foreach (var item in listaSports)
                {
                    var r = GridHelper.ConstruirFila(dgvDatosSport);
                    GridHelper.SetearFila(r, item);
                    GridHelper.AgregarFila(r, dgvDatosSport);
                }
            }
        }

        private void toolStripButtonAgregar_Click(object sender, EventArgs e)
        {
            frmSportAE frm = new frmSportAE();
            DialogResult dr = frm.ShowDialog();
            if (dr == DialogResult.Cancel)
            {
                return;
            }
            Sport sport = frm.GetSport();
            try
            {
                if (sport != null)
                {
                    if (!_sportService.Existe(sport))
                    {
                        _sportService.Guardar(sport);
                        Actualizarcantidad();
                        DataGridViewRow r = GridHelper.ConstruirFila(dgvDatosSport);
                        GridHelper.SetearFila(r, sport);
                        GridHelper.AgregarFila(r, dgvDatosSport);
                        MessageBox.Show("Se agrego el nuevo Sport con exito", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Este Sport ya esxiste!!!!");
                    }
                }
                else
                {
                    MessageBox.Show("El Sport es null");
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine($"ERROR:{ex.Message}");
            }
        }

        private void toolStripButtonBorrar_Click(object sender, EventArgs e)
        {
            if (dgvDatosSport.SelectedRows.Count == 0)
            {
                return;
            }
            var r = dgvDatosSport.SelectedRows[0];
            if (r.Tag is not null)
            {
                Sport sport = (Sport)r.Tag;
                DialogResult dr = MessageBox.Show($"¿Desea dar de baja a {sport.SportName}?",
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


                    if (!_sportService.EstaRelacionado(sport))
                    {
                        _sportService.Borrar(sport);
                        Actualizarcantidad();
                        GridHelper.QuitarFila(r, dgvDatosSport);
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
            if (dgvDatosSport.SelectedRows.Count == 0)
            {
                return;
            }
            var r = dgvDatosSport.SelectedRows[0];
            if (r is null)
            {
                return;
            }
            Sport Sport = (Sport)r.Tag;
            frmSportAE frm = new frmSportAE();
            frm.SetSport(Sport);
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;
            }
            try
            {
                Sport = frm.GetSport();

                if (!_sportService.Existe(Sport))
                {
                    _sportService.Guardar(Sport);
                    GridHelper.SetearFila(r, Sport);
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
            if (dgvDatosSport.SelectedRows.Count == 0)
            {
                return;
            }
            var r = dgvDatosSport.SelectedRows[0];
            if (r is null)
            {
                return;
            }
            Sport Sport = (Sport)r.Tag;
            var sport = _sportService.GetSportPorId(Sport.SportId);
            recordCount = servicioShoe.GetCantidad(s => s.Sports == sport);
            pageCount = FormHelper.CalcularPaginas(recordCount, pageSize);
            var lista = servicioShoe.GetListaPaginadaOrdenadaFiltrada(pageNum, pageSize, null, null, sport, null, null);

            frmShoesPorSport frm = new frmShoesPorSport(servicioShoe);
            frm.SetDatosParaElPaginadoYFiltro(pageCount, pageNum, pageSize, recordCount, Sport);
            frm.SetLista(lista);
            frm.ShowDialog();
        }

        private void toolStripButtonSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmSport_Load(object sender, EventArgs e)
        {
            Actualizarcantidad();
            listaSports = _sportService?.GetSports();
            MostrarDatosEnGrilla();
        }
    }
}
