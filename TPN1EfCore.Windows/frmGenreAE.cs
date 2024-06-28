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
    public partial class frmGenreAE : Form
    {
        public frmGenreAE()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (_genre!=null)
            {
                txtGenre.Text = _genre.GenreName;
            }
        }
        private Genre? _genre;
        private void brnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void SetGenre(Genre? genre)
        {
            _genre = genre;
        }

        public Genre? GetGenre()
        {
            return _genre;
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (_genre == null)
                {
                    _genre = new Genre();
                }
                _genre.GenreName = txtGenre.Text;
                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidarDatos()
        {
            errorProvider1.Clear();
            bool validar = true;
            if (string.IsNullOrEmpty(txtGenre.Text) || string.IsNullOrWhiteSpace(txtGenre.Text))
            {
                errorProvider1.SetError(txtGenre, "Debe ingresar una Marca");
                validar = false;
            }
            return validar;
        }
    }
}
