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
using TPN1EfCore.Servicios.Interfaces;

namespace TPN1EfCore.Windows
{
    public partial class FrmPrincipal : Form
    {
        private readonly IServiceProvider? _serviceProvider;
        public FrmPrincipal(IServiceProvider? serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            //pbShoes.Image = Image.FromFile(@"C:\Users\uri8m\OneDrive\Escritorio\3er Año ASI\Maquina para hacer Cafe\TPN1EfCore\botas-de-combate.gif");
            //pbShoes.SizeMode = PictureBoxSizeMode.AutoSize;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnBrand_Click(object sender, EventArgs e)
        {
            frmBrand frm = new frmBrand(_serviceProvider?.GetService<IBrandService>(), _serviceProvider?.GetService<IShoeService>());
            frm.ShowDialog();
        }

        private void btnSport_Click(object sender, EventArgs e)
        {
            frmSport frm = new frmSport(_serviceProvider?.GetService<ISportService>(), _serviceProvider?.GetService<IShoeService>());
            frm.ShowDialog();
        }

        private void btnGenre_Click(object sender, EventArgs e)
        {
            frmGenre frm = new frmGenre(_serviceProvider?.GetService<IGenreService>(), _serviceProvider?.GetService<IShoeService>());
            frm.ShowDialog();
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            frmColor frm = new frmColor(_serviceProvider?.GetService<IColorService>(), _serviceProvider?.GetService<IShoeService>());
            frm.ShowDialog();
        }

        private void btnShoe_Click(object sender, EventArgs e)
        {
            frmShoe frm = new frmShoe(_serviceProvider?.GetService<IShoeService>(), _serviceProvider?.GetService<IServiceProvider>());
            frm.ShowDialog();
        }

        private void btnTalles_Click(object sender, EventArgs e)
        {
            frmSize frm = new frmSize(_serviceProvider?.GetService<ISizeService>());
            frm.ShowDialog();
        }
    }
}
