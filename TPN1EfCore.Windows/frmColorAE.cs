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
    public partial class frmColorAE : Form
    {
        public frmColorAE()
        {
            InitializeComponent();
        }
        private Colour? _Colour;
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (_Colour != null)
            {
                txtColour.Text = _Colour.ColorName;
            }
        }
        public Colour? GetColor()
        {
            return _Colour;
        }

        public void SetColor(Colour? color)
        {
            _Colour = color;
        }
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (_Colour == null)
                {
                    _Colour = new Colour();
                }
                _Colour.ColorName = txtColour.Text;
                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidarDatos()
        {
            errorProvider1.Clear();
            bool validar = true;
            if (string.IsNullOrEmpty(txtColour.Text) || string.IsNullOrWhiteSpace(txtColour.Text))
            {
                errorProvider1.SetError(txtColour, "Debe ingresar una Marca");
                validar = false;
            }
            return validar;
        }

        private void brnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
