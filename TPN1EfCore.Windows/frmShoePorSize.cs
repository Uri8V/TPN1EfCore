using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TPN1EfCore.Datos.Migrations;
using TPN1EfCore.Entidades;
using TPN1EfCore.Entidades.DTO;
using TPN1EfCore.Servicios.Interfaces;
using TPN1EfCore.Windows.Helpers;
using Size = TPN1EfCore.Entidades.Size;

namespace TPN1EfCore.Windows
{
    public partial class frmShoePorSize : Form
    {
        private readonly ISizeService sizeService;
        private  List<ShoeListDto> shoeList;
        private Size _size;
        public frmShoePorSize(ISizeService _sizeService, Size size)
        {
            InitializeComponent();
            sizeService = _sizeService;
            _size = size;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmShoePorSize_Load(object sender, EventArgs e)
        {
            shoeList=new List<ShoeListDto>();
            shoeList = sizeService.GetShoePorSize(_size);
            RecargarGrilla();
        }

        private void RecargarGrilla()
        {
            GridHelper.LimpiarGrilla(dgvDatos);
            foreach (var shoe in shoeList)
            {
                var r = GridHelper.ConstruirFila(dgvDatos);
                GridHelper.SetearFila(r, shoe);
                GridHelper.AgregarFila(r,dgvDatos);
            }

        }
    }
}
