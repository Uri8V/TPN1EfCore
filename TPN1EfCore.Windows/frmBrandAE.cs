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

namespace TPN1EfCore.Windows
{
    public partial class frmBrandAE : Form
    {
      
        public frmBrandAE()
        {
            InitializeComponent();

        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (brand != null)
            {
                txtBrand.Text = brand.BrandName;
            }
        }
        private void brnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
        private Brand brand;
        private void brnConfirmar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (brand == null)
                {
                    brand = new Brand();
                }
                brand.BrandName = txtBrand.Text;
                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidarDatos()
        {
            errorProvider1.Clear();
            bool validar = true;
            if (string.IsNullOrEmpty(txtBrand.Text) || string.IsNullOrWhiteSpace(txtBrand.Text))
            {
                errorProvider1.SetError(txtBrand, "Debe ingresar una Marca");
                validar = false;
            }
            return validar;
        }

        public Brand GetBrand()
        {
            return brand;
        }

        public void SetBrand(Brand _brand)
        {
            brand = _brand;
        }

        private void frmBrandAE_Load(object sender, EventArgs e)
        {

        }
    }
}
