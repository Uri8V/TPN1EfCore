using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TPN1EfCore.Entidades;
using TPN1EfCore.Servicios.Interfaces;
using TPN1EfCore.Windows.Helpers;

namespace TPN1EfCore.Windows
{
    public partial class frmBrand : Form
    {
        private readonly IBrandService _brandService;
        private List<Brand> listaBrands;
        private readonly IShoeService servicioShoe;
        private int pageCount;
        private int pageSize = 8;
        private int pageNum = 0;
        private int recordCount;
        public frmBrand(IBrandService brandService, IShoeService shoeService)
        {
            InitializeComponent();
            _brandService = brandService;
            servicioShoe= shoeService;
        }

        private void toolStripButtonSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmBrand_Load(object sender, EventArgs e)
        {
            Actualizarcantidad();
            listaBrands = _brandService.GetBrands();
            MostrarDatosEnGrilla();
        }
        public void Actualizarcantidad()
        {
            txtcantidad.Text = _brandService.GetCantidad().ToString();
        }
        private void MostrarDatosEnGrilla()
        {
            GridHelper.LimpiarGrilla(dgvDatosBrand);
            if (listaBrands != null)
            {
                foreach (var item in listaBrands)
                {
                    var r = GridHelper.ConstruirFila(dgvDatosBrand);
                    GridHelper.SetearFila(r, item);
                    GridHelper.AgregarFila(r, dgvDatosBrand);
                }
            }
        }

        private void toolStripButtonAgregar_Click(object sender, EventArgs e)
        {
            frmBrandAE frm = new frmBrandAE();
            DialogResult dr = frm.ShowDialog();
            if (dr == DialogResult.Cancel)
            {
                return;
            }
            Brand brand = frm.GetBrand();
            try
            {
                if (brand != null)
                {
                    if (!_brandService.Existe(brand))
                    {
                        _brandService.Guardar(brand);
                        Actualizarcantidad();
                        DataGridViewRow r = GridHelper.ConstruirFila(dgvDatosBrand);
                        GridHelper.SetearFila(r, brand);
                        GridHelper.AgregarFila(r, dgvDatosBrand);
                        MessageBox.Show("Se agrego la nueva Brand con exito", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Esta Brand ya esxiste!!!!");
                    }
                }
                else
                {
                    MessageBox.Show("La Brand es null");
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine($"ERROR:{ex.Message}");
            }
        }

        private void toolStripButtonBorrar_Click(object sender, EventArgs e)
        {
            if (dgvDatosBrand.SelectedRows.Count == 0)
            {
                return;
            }
            var r = dgvDatosBrand.SelectedRows[0];
            if (r.Tag is not null)
            {
                Brand brand = (Brand)r.Tag;
                DialogResult dr = MessageBox.Show($"¿Desea dar de baja a {brand.BrandName}?",
                    "Confirmar Operación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2);
                if (dr == DialogResult.No)
                {
                    return;
                }
                try
                {


                    if (!_brandService.EstaRelacionado(brand))
                    {
                        _brandService.Borrar(brand);
                        Actualizarcantidad();
                        GridHelper.QuitarFila(r, dgvDatosBrand);
                        MessageBox.Show("Registro Borrado Satisfactoriamente!!!",
                            "Mensaje",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Registro Relacionado...Baja denegada!!!",
                            "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message,
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        private void toolStripButtonEditar_Click(object sender, EventArgs e)
        {
            if (dgvDatosBrand.SelectedRows.Count == 0)
            {
                return;
            }
            var r = dgvDatosBrand.SelectedRows[0];
            if (r is null)
            {
                return;
            }
            Brand brand = (Brand)r.Tag;
            frmBrandAE frm = new frmBrandAE();
            frm.SetBrand(brand);
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel)
            {
                return;
            }
            try
            {
                brand = frm.GetBrand();

                if (!_brandService.Existe(brand))
                {
                    _brandService.Guardar(brand);
                    GridHelper.SetearFila(r, brand);
                    MessageBox.Show("Registro Editado Satisfactoriamente!!!", "Mensaje",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Registro duplicado", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void toolStripButtonConsulta_Click(object sender, EventArgs e)
        {
            if (dgvDatosBrand.SelectedRows.Count == 0)
            {
                return;
            }
            var r = dgvDatosBrand.SelectedRows[0];
            if (r is null)
            {
                return;
            }
            Brand brand = (Brand)r.Tag;
            var Brand = _brandService.GetBrandPorId(brand.BrandId);
            recordCount = servicioShoe.GetCantidad(s => s.Brands == Brand);
            pageCount = FormHelper.CalcularPaginas(recordCount, pageSize);
            var lista = servicioShoe.GetListaPaginadaOrdenadaFiltrada(pageNum,pageSize,null,Brand,null,null,null);

            frmShoesPorBrand frm = new frmShoesPorBrand(servicioShoe);
            frm.SetDatosParaElPaginadoYFiltro(pageCount, pageNum, pageSize, recordCount, Brand);
            frm.SetLista(lista);
            frm.ShowDialog();
        }
    }
}
