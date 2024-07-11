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
    public partial class frmSizesAndStock : Form
    {
        private readonly IShoeService? _shoeService;
        private readonly ShoeListDto? _shoe;
        public frmSizesAndStock(IShoeService? shoeService, ShoeListDto? shoe)
        {
            InitializeComponent();
            _shoeService = shoeService;
            _shoe = shoe;
        }

        private void frmSizesAndStock_Load(object sender, EventArgs e)
        {
            RecargarGrilla();
        }

        private void RecargarGrilla()
        {
            GridHelper.LimpiarGrilla(dgvDatos);
            for (int i = 0; i < _shoe.size.Count(); i++)
            {
                var r = GridHelper.ConstruirFila(dgvDatos);
                r.Cells[0].Value=_shoe.size[i];
                r.Cells[1].Value = _shoe.Stock[i];
                GridHelper.AgregarFila(r, dgvDatos);
            }
            
        }

        private void toolStripButtonSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
