using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TPN1EfCore.Entidades;
using TPN1EfCore.Entidades.DTO;
using TPN1EfCore.Servicios.Interfaces;
using TPN1EfCore.Windows.Helpers;
using Size = TPN1EfCore.Entidades.Size;

namespace TPN1EfCore.Windows
{
    public partial class frmAsignarSizeAShoe : Form
    {
        private readonly ISizeService _sizeService;
        private List<Size> _listaParaCrearShoe;
        private List<Size> listaDeSizeARelacionar;
        private List<int> stocklist;
        private ShoeListDto? shoe;
        private int stock = 0;
        public frmAsignarSizeAShoe(ISizeService sizeService, List<Size> lista, ShoeListDto shoeList)
        {
            InitializeComponent();
            _sizeService = sizeService;
            _listaParaCrearShoe = lista;
            shoe = shoeList;
        }

        private void toolStripButtonSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void frmAsignarSizeAShoe_Load(object sender, EventArgs e)
        {
            RecargarGrilla();
        }

        private void RecargarGrilla()
        {
            MostrarDatosEnGrillaSize();
            MostrarDatosEnGrillaShoe();
            stocklist = new List<int>();
            listaDeSizeARelacionar = new List<Size>();
        }

        private void MostrarDatosEnGrillaShoe()
        {
            GridHelper.LimpiarGrilla(dataGridView1);
            DataGridViewRow r = GridHelper.ConstruirFila(dataGridView1);
            GridHelper.SetearFila(r, shoe);
            GridHelper.AgregarFila(r, dataGridView1);
        }
        private void MostrarDatosEnGrillaSize()
        {
            GridHelper.LimpiarGrilla(dgvDatos);
            foreach (var item in _listaParaCrearShoe)
            {
                var r = GridHelper.ConstruirFila(dgvDatos);
                GridHelper.SetearFila(r, item);
                r.Cells[1].Value = "Agregar";
                r.Cells[2].Value = 0.ToString();
                GridHelper.AgregarFila(r, dgvDatos);
            }

        }

        private void dgvDatos_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                var r = dgvDatos.SelectedRows[0];
                Size? size = _sizeService?.GetSizePorDecimal((decimal)r.Cells[0].Value);
                if (!listaDeSizeARelacionar.Contains(size))
                {
                    frmIngresarStock frm = new frmIngresarStock();
                    DialogResult dr = frm.ShowDialog(this);
                    stock = frm.GetStock();
                    stocklist.Add(stock);
                    listaDeSizeARelacionar?.Add(size);
                }
                r.Cells[2].Value = stock.ToString();
            }
        }

        private void toolStripButtonCancelar_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("¿Desea cancelar toda la operación?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.Yes) { RecargarGrilla(); return; }
            DialogResult dr2 = MessageBox.Show("¿Desea cancelar solo la opción seleccionada?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (dr2 == DialogResult.Yes)
            {
                var r = dgvDatos.SelectedRows[0];
                stock = 0;
                stocklist.RemoveAt(stocklist.Count-1);
                listaDeSizeARelacionar.Remove(_sizeService?.GetSizePorDecimal((decimal)r.Cells[0].Value));
                r.Cells[2].Value = stock.ToString();
            }
        }

        private void toolStripButtonConfirmar_Click(object sender, EventArgs e)
        {
            if (listaDeSizeARelacionar.Count!=0)
            {
                DialogResult = DialogResult.OK;
            }
        }

        internal List<Size>? GetSizes()
        {
            return listaDeSizeARelacionar;
        }

        internal List<int> GetStock()
        {
            return stocklist;
        }
    }
}
