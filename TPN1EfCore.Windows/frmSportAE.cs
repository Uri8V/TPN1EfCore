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
    public partial class frmSportAE : Form
    {
        public frmSportAE()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (_sport!=null)
            {
                txtSport.Text = _sport.SportName;
            }
        }
        private Sport _sport;
        public Sport? GetSport()
        {
            return _sport;
        }

        public void SetSport(Sport? sport)
        {
            _sport = sport;
        }

        private void brnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (_sport==null)
                {
                    _sport = new Sport();
                }
                _sport.SportName = txtSport.Text;
                DialogResult = DialogResult.OK;
            }
        }
        private bool ValidarDatos()
        {
            errorProvider1.Clear();
            bool validar = true;
            if (string.IsNullOrEmpty(txtSport.Text) || string.IsNullOrWhiteSpace(txtSport.Text))
            {
                errorProvider1.SetError(txtSport, "Debe ingresar un Sport");
                validar = false;
            }
            return validar;
        }
    }
}
