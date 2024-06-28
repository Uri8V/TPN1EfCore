using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TPN1EfCore.Entidades.DTO;
using TPN1EfCore.Entidades;
using TPN1EfCore.Servicios.Interfaces;
using TPN1EfCore.Windows.Helpers;

namespace TPN1EfCore.Windows
{
    public partial class frmShoesPorColor : Form
    {
        public frmShoesPorColor(IShoeService shoeService)
        {
            InitializeComponent();
            _shoeService = shoeService;

        }
        private readonly IShoeService _shoeService;
        private int pageSize;
        private int pageNum;
        private int recordCount;
        private int pageCount;
        private Colour? ColourFiltro;
        private List<ShoeListDto> shoeListDtos;

        private void frmShoesPorColor_Load(object sender, EventArgs e)
        {
            if (shoeListDtos != null)
            {
                MostrarDatosEnGRilla();
            }
        }

        private void MostrarDatosEnGRilla()
        {
            GridHelper.LimpiarGrilla(dgvConsulta);
            foreach (var item in shoeListDtos)
            {
                var r = GridHelper.ConstruirFila(dgvConsulta);
                GridHelper.SetearFila(r, item);
                GridHelper.AgregarFila(r, dgvConsulta);
            }
        }

        public void SetLista(List<ShoeListDto> lista)
        {
            shoeListDtos = lista;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            // Ir a la siguiente página
            pageNum++;
            if (pageNum > pageCount - 1) { pageNum = pageCount - 1; }
            ActualizarListaPaginada();
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            // Ir a la página anterior
            pageNum--;
            if (pageNum < 0) { pageNum = 0; }
            ActualizarListaPaginada();
        }

        private void btnPrimero_Click(object sender, EventArgs e)
        {
            // Ir a la primera página
            pageNum = 0;
            ActualizarListaPaginada();
        }

        private void btnUltimo_Click(object sender, EventArgs e)
        {
            // Ir a la última página
            pageNum = pageCount - 1;
            ActualizarListaPaginada();
        }
        private void ActualizarListaPaginada()
        {
            // Actualizar la lista paginada según la página actual y tamaño de página
            shoeListDtos = _shoeService
                .GetListaPaginadaOrdenadaFiltrada(pageNum, pageSize, null, null
                , null, null, ColourFiltro);
            MostrarDatosEnGRilla();
        }

        internal void SetDatosParaElPaginadoYFiltro(int _pageCount, int _pageNum, int _pageSize, int _recordCount, Colour? Colour)
        {
            pageCount = _pageCount;
            pageNum = _pageNum;
            pageSize = _pageSize;
            recordCount = _recordCount;
            ColourFiltro = Colour;
        }

    }
}
