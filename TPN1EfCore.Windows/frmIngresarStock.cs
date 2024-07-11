using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPN1EfCore.Windows
{
    public partial class frmIngresarStock : Form
    {
        public frmIngresarStock()
        {
            InitializeComponent();
        }
        private int stock = 0;
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                stock = int.Parse(textBox1.Text);
                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidarDatos()
        {
           bool valid = true;
            if (!int.TryParse(textBox1.Text, out int stock) || stock <=0)
            {
                errorProvider1.SetError(textBox1, "Debe ingresar un Stock mayor a 0");
                valid = false;
            }
            return valid;
        }

        internal int GetStock()
        {
            return stock;
        }
    }
}
