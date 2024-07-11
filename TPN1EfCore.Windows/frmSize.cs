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
using TPN1EfCore.Entidades.DTO;
using TPN1EfCore.Servicios.Interfaces;
using TPN1EfCore.Servicios.Servicios;
using TPN1EfCore.Windows.Helpers;
using Size = TPN1EfCore.Entidades.Size;

namespace TPN1EfCore.Windows
{
    public partial class frmSize : Form
    {
        ISizeService _sizeService1;
        List<Size> lista;
        public frmSize(ISizeService sizeService)
        {
            InitializeComponent();
            _sizeService1 = sizeService;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmSize_Load(object sender, EventArgs e)
        {
            RecargarGrilla();
        }

        private void RecargarGrilla()
        {
            lista = _sizeService1.GetSizes();
            MostrarDatosEnGrilla();
        }

        private void MostrarDatosEnGrilla()
        {
            GridHelper.LimpiarGrilla(dgvDatos);
            foreach (var item in lista)
            {
                var r = GridHelper.ConstruirFila(dgvDatos);
                GridHelper.SetearFila(r, item);
                r.Cells[1].Value = "Ver Shoes";
                GridHelper.AgregarFila(r, dgvDatos);
            }
        }

        private void dgvDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                if (dgvDatos.SelectedRows.Count == 0) { return; }
                var r = dgvDatos.SelectedRows[0];
                Size? size = (Size?)r.Tag;
                frmShoePorSize frm= new frmShoePorSize(_sizeService1, size);
                DialogResult dr = frm.ShowDialog(this);
            }
        }
    }
}
