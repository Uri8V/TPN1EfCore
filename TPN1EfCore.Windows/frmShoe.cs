using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TPN1EfCore.Datos.Interfaces;
using TPN1EfCore.Entidades;
using TPN1EfCore.Entidades.DTO;
using TPN1EfCore.Entidades.Enums;
using TPN1EfCore.Servicios.Interfaces;
using TPN1EfCore.Servicios.Servicios;
using TPN1EfCore.Windows.Helpers;
using TPN1EfCore.Windows.Properties;
using Size = TPN1EfCore.Entidades.Size;

namespace TPN1EfCore.Windows
{
    public partial class frmShoe : Form
    {
        public frmShoe(IShoeService? shoeService, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
            _servicio = shoeService;
        }

        private void dgvDatosShoe_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private readonly IServiceProvider _serviceProvider;
        private readonly IShoeService? _servicio;
        private List<ShoeListDto>? lista;
        private List<Size>? listaSize;
        private Orden orden = Orden.AZ;
        private Brand? brandFiltro = null;
        private Sport? sportFiltro = null;
        private Genre? genreFiltro = null;
        private Colour? colourFiltro = null;
        private Size? sizeSeleccionad = null;
        private Size? sizeMaximo = null;
        private Func<Shoe, bool>? filtro = null;
        private decimal? maximo=null;
        private decimal? minimo=null;

        private int pageCount;
        private int pageSize = 16;
        private int pageNum = 0;
        private int recordCount;


        private void frmShoe_Load(object sender, EventArgs e)
        {
            //HACER EL FILTRO EN OTRO FORMULARIO PARA PODER SIMPLIFICARLO
            //NO QUIERE DECIR QUE ESTA MAL, SOLO QUE SERÍA MÁS FÁCIL 
            //CombosHelper.CargarComboFormBrand(_serviceProvider, ref toolStripComboBoxBrand);
            //CombosHelper.CargarComboFormSport(_serviceProvider, ref toolStripComboBoxSport);
            //CombosHelper.CargarComboFormGenre(_serviceProvider, ref toolStripComboBoxGenre);
            //CombosHelper.CargarComboFormColor(_serviceProvider, ref toolStripComboBoxColor);
            RecargarGrillDeTodosLosShoes();
        }
        private void RecargarGrillDeTodosLosShoes()
        {
            try
            {
                recordCount = _servicio.GetCantidad(filtro);
                txtcantidad.Text = recordCount.ToString();
                pageCount = FormHelper.CalcularPaginas(recordCount, pageSize);
                // Obtener la lista paginada ordenada y filtrada por defecto (sin orden ni filtro)
                lista = _servicio.GetListaPaginadaOrdenadaFiltrada(pageNum, pageSize, orden, brandFiltro, sportFiltro, genreFiltro, colourFiltro, maximo, minimo, sizeSeleccionad, sizeMaximo);
                txtCantidadRegistros.Text = pageCount.ToString();
                CombosHelper.CargarCombosPaginas(pageCount, ref cboPaginas);


                MostrarDatosEnGrilla();
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void aZToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Ordenar de forma ascendente (A-Z)
            MostrarOrdenado(Orden.AZ);
        }
        private void zAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Ordenar de forma descendente (Z-A)
            MostrarOrdenado(Orden.ZA);
        }
        private void menorPrecioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Ordenar por menor precio
            MostrarOrdenado(Orden.MenorPrecio);
        }
        private void mayorPrecioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Ordenar por mayor precio
            MostrarOrdenado(Orden.MayorPrecio);
        }
        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            // Ir a la siguiente página
            pageNum++;
            if (pageNum > pageCount - 1) { pageNum = pageCount - 1; }
            cboPaginas.SelectedIndex = pageNum;
            ActualizarListaPaginada();
        }
        private void btnAnterior_Click(object sender, EventArgs e)
        {
            // Ir a la página anterior
            pageNum--;
            if (pageNum < 0) { pageNum = 0; }
            cboPaginas.SelectedIndex = pageNum;
            ActualizarListaPaginada();
        }
        private void btnPrimero_Click(object sender, EventArgs e)
        {
            // Ir a la primera página
            pageNum = 0;
            cboPaginas.SelectedIndex = pageNum;
            ActualizarListaPaginada();
        }
        private void btnUltimo_Click(object sender, EventArgs e)
        {
            // Ir a la última página
            pageNum = pageCount - 1;
            cboPaginas.SelectedIndex = pageNum;
            ActualizarListaPaginada();
        }
        private void cboPaginas_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Cambiar a la página seleccionada
            pageNum = cboPaginas.SelectedIndex;
            ActualizarListaPaginada();
        }
        private void ActualizarListaPaginada()
        {
            // Actualizar la lista paginada según la página actual y tamaño de página
            lista = _servicio?
                .GetListaPaginadaOrdenadaFiltrada(pageNum, pageSize, orden,
                brandFiltro, sportFiltro, genreFiltro, colourFiltro, maximo, minimo, sizeSeleccionad, sizeMaximo);
            MostrarDatosEnGrilla();
        }
        private void MostrarOrdenado(Orden orden)
        {
            // Mostrar la lista ordenada según el criterio seleccionado
            lista = _servicio?.GetListaPaginadaOrdenadaFiltrada(pageNum, pageSize, orden, brandFiltro, sportFiltro, genreFiltro, colourFiltro, maximo, minimo, sizeSeleccionad, sizeMaximo);
            MostrarDatosEnGrilla();
        }
        //TODO:Hacer método Genérico!!!
        private void MostrarDatosEnGrilla()
        {
            // Mostrar los datos en la grilla
            GridHelper.LimpiarGrilla(dgvDatos);
            if (lista is not null)
            {
                foreach (var item in lista)
                {
                    DataGridViewRow r = GridHelper.ConstruirFila(dgvDatos);
                    GridHelper.SetearFila(r, item);
                    r.Cells[7].Value = "Detalle";
                    GridHelper.AgregarFila(r, dgvDatos);
                }
            }
        }
        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            var SizeService = _serviceProvider.GetService<ISizeService>();
            var ShoeSizeService = _serviceProvider.GetService<IShoeSizeService>();
            listaSize = new List<Size>();
            listaSize = SizeService?.GetSizes();
            frmShoeAE frm = new frmShoeAE(_serviceProvider, SizeService, listaSize);
            DialogResult df = frm.ShowDialog(this);
            if (df == DialogResult.Cancel) { return; }
            try
            {
                Shoe? shoe = frm.GetShoe();
                listaSize = frm.GetSizesSeleccionados();
                var stock = frm.GetStockSeleccionado();
                if (!_servicio.Existe(shoe))
                {
                    _servicio.Guardar(shoe, stock, listaSize); // Guardar Shoe con Sizes y stock repetido
                    RecargarGrillDeTodosLosShoes();
                    // Actualizar la lista después de agregar la planta 
                }
                else
                {
                    MessageBox.Show("Shoe existente!!!", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        //private void ActualizarListaDespuesAgregar(Planta plantaAgregada)
        //{
        //    // Obtener la página actual y actualizar la lista
        //    int paginaActual = pageNum;
        //    lista = _servicio.GetListaPaginadaOrdenadaFiltrada(paginaActual, pageSize);

        //    // Mostrar la lista actualizada en la grilla
        //    MostrarDatosEnGrilla();

        //    // Verificar si la planta agregada está en la página actual

        //    bool plantaAgregadaEnPaginaActual = lista
        //        .Any(p => p.PlantaId == plantaAgregada.PlantaId);

        //    if (!plantaAgregadaEnPaginaActual)
        //    {
        //        // Si la planta agregada no está en la página actual,
        //        // seleccionar la última página y actualizar la lista
        //        pageNum = pageCount - 1;
        //        cboPaginas.SelectedIndex = pageNum;
        //        //modifique los parámetros OJO!!!
        //        lista = _servicio
        //            .GetListaPaginadaOrdenadaFiltrada(pageNum, pageSize, orden,
        //            tipoDePlantaFiltro, tipoDeEnvaseFiltro);
        //        MostrarDatosEnGrilla();
        //    }
        //}

        private void tsbBorrar_Click(object sender, EventArgs e)
        {
            var _servicioBrand = _serviceProvider.GetService<IBrandService>();
            var _servicioSport = _serviceProvider.GetService<ISportService>();
            var _servicioGenre = _serviceProvider.GetService<IGenreService>();
            var _servicioColor = _serviceProvider.GetService<IColorService>();
            if (dgvDatos.SelectedRows.Count == 0)
            {
                return;
            }
            var r = dgvDatos.SelectedRows[0];
            if (r.Tag is not null)
            {
                //TERMINAR

                Shoe? shoe = _servicio?.GetShoePorId(((ShoeListDto)r.Tag).shoeId);
                DialogResult dr = MessageBox.Show($"¿Desea dar de baja a la Shoe:{_servicioBrand.GetBrandPorId(shoe.BrandId).BrandName}, {_servicioSport.GetSportPorId(shoe.SportId).SportName}, {_servicioGenre.GetGenrePorId(shoe.GenreId).GenreName}, {_servicioColor.GetColourPorId(shoe.ColourId).ColorName}, {shoe.Model}, {shoe.Descripcion}?",
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
                    _servicio.Borrar(shoe);
                    GridHelper.QuitarFila(r, dgvDatos);
                    RecargarGrillDeTodosLosShoes();
                    MessageBox.Show("Registro Borrado Satisfactoriamente!!!",
                        "Mensaje",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

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

        private void tsbActualizar_Click(object sender, EventArgs e)
        {
            brandFiltro = null;
            sportFiltro = null;
            genreFiltro = null;
            colourFiltro = null;
            filtro = null;
            maximo = null;
            minimo = null;
            sizeSeleccionad = null;
            sizeMaximo = null;
            RecargarGrillDeTodosLosShoes();
            toolStripSplitFiltro.BackColor = SystemColors.Control;

        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            var SizeService = _serviceProvider.GetService<ISizeService>();
            var listaSizeDeShoe = new List<Size>();
            var listaSizeFiltrada = new List<Size>();
            int stocked = 0;
            if (dgvDatos.SelectedRows.Count == 0) { return; }
            var r = dgvDatos.SelectedRows[0];
            ShoeListDto? shoeList = (ShoeListDto?)r.Tag;
            var shoe = _servicio?.GetShoePorId(shoeList.shoeId);
            listaSizeDeShoe = _servicio?.GetSizesPorShoes(shoe.ShoeId);
            listaSizeFiltrada = SizeService?.GetSizes();
            foreach (var item in listaSizeDeShoe)
            {
                listaSizeFiltrada?.Remove(item);
            }
            for (int i = 0; i < shoeList.Stock.Count; i++)
            {
                stocked = shoeList.Stock[i];
            }
            frmShoeAE frm = new frmShoeAE(_serviceProvider, SizeService, listaSizeFiltrada)
            { Text = "Editar shoe" };
            frm.SetShoe(shoe);
            DialogResult dr = frm.ShowDialog(this);
            try
            {
                shoe = frm.GetShoe();
                listaSize = frm.GetSizesSeleccionados();
                var stock = frm.GetStockSeleccionado();
                if (!_servicio.Existe(shoe))
                {
                    _servicio.Guardar(shoe, stock, listaSize);// Arreglar lo de los Talles y el Stock
                    ActualizarListaPaginada();
                }
                else
                {
                    MessageBox.Show("Shoe existente!!!", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void toolStripSplitFiltro_Click(object sender, EventArgs e)
        {
            var sizeservice = _serviceProvider.GetService<ISizeService>();
            frmFiltro frm = new frmFiltro(_serviceProvider, sizeservice);
            DialogResult dr=frm.ShowDialog(this);
            if (dr == DialogResult.Cancel) { return; }
            filtro = frm.GetFiltro();
            brandFiltro = frm.GetFiltroBrand();
            sportFiltro = frm.GetFiltroSport();
            genreFiltro = frm.GetFiltroGenre();
            colourFiltro = frm.GetFiltroColor();
            if (frm.GetMaximo()==0 && frm.GetMinimo()==0)
            {
                maximo = null;
                minimo = null;
            }
            else
            {
                maximo=frm.GetMaximo();
                minimo=frm.GetMinimo();
            }
            sizeSeleccionad = frm.GetSizeSeleccionado();
            sizeMaximo = frm.GetSizeMaximo();
            RecargarGrillDeTodosLosShoes();
        }

        private void dgvDatos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 7)
            {
                if (dgvDatos.SelectedRows.Count == 0) { return; }
                var r = dgvDatos.SelectedRows[0];
                ShoeListDto? shoeList = (ShoeListDto?)r.Tag;
                frmSizesAndStock frm = new frmSizesAndStock(_servicio, shoeList);
                DialogResult dr = frm.ShowDialog(this);
            }
        }

        private void toolStripButtonAsignarShoe_Click(object sender, EventArgs e)
        {
            var SizeService = _serviceProvider.GetService<ISizeService>();
            var listaSizeDeShoe = new List<Size>();
            var listaSizeFiltrada = new List<Size>();
            if (dgvDatos.SelectedRows.Count == 0) { return; }
            var r = dgvDatos.SelectedRows[0];
            ShoeListDto? shoeList = (ShoeListDto?)r.Tag;
            listaSizeDeShoe = _servicio?.GetSizesPorShoes(shoeList.shoeId);
            listaSizeFiltrada = SizeService?.GetSizes();
            foreach (var item in listaSizeDeShoe)
            {
                listaSizeFiltrada?.Remove(item);
            }
            frmAsignarSizeAShoe frm= new frmAsignarSizeAShoe(SizeService, listaSizeFiltrada, shoeList);
            DialogResult dr = frm.ShowDialog(this);
            listaSize = frm.GetSizes();
            var liststock = frm.GetStock();
            Shoe? shoe = _servicio?.GetShoePorId(shoeList.shoeId);
            for (int i = 0; i < listaSize.Count; i++)
            {
                var size = listaSize[i];
                var stock = liststock[i];
                _servicio?.AsignarSizealShoe(shoe, size, stock);
            }
            MessageBox.Show("Sizes relacionados exitosamente", "Mensaje", MessageBoxButtons.OK);
            RecargarGrillDeTodosLosShoes();
        }
        //Func<Shoe, bool>? brandfiltro = null;
        //private void toolStripComboBoxBrand_Click(object sender, EventArgs e)
        //{
        //    if (toolStripComboBoxBrand.SelectedIndex > 0)
        //    {
        //        var servicio = _serviceProvider
        //            .GetService<IBrandService>();
        //        brandFiltro = servicio?
        //            .GetBrandPorNombre(toolStripComboBoxBrand.Text);

        //        // Definir el filtro
        //        brandfiltro = (p => p.Brands == brandFiltro);
        //        filtro = filtro == null ? brandfiltro : filtro.And(brandfiltro);


        //        // Obtener la cantidad de registros después de aplicar el filtro
        //        recordCount = _servicio.GetCantidad(filtro);
        //        txtcantidad.Text = recordCount.ToString();
        //        // Recalcular el número de páginas
        //        pageCount = FormHelper
        //            .CalcularPaginas(recordCount, pageSize);

        //        // Actualizar el texto del cuadro de texto de cantidad de registros
        //        txtCantidadRegistros.Text = pageCount.ToString();

        //        // Recargar el combo de páginas
        //        CombosHelper.CargarCombosPaginas(pageCount,
        //            ref cboPaginas);

        //        // Obtener la lista paginada ordenada y filtrada
        //        //lista = _servicio
        //        //    .GetListaPaginadaOrdenadaFiltrada(pageNum,
        //        //    pageSize, orden, brandFiltro,
        //        //    sportFiltro, genreFiltro, colourFiltro);
        //        //MostrarDatosEnGrilla();
        //        //RecargarGrillDeTodosLosShoes();


        //        toolStripSplitFiltro.BackColor = Color.DarkGray;
        //    }
        //    else
        //    {
        //        if (filtro != null)
        //        {
        //            brandFiltro = null;
        //            filtro = filtro.And(FiltroBuilder.Not(p => p.Brands == brandFiltro));
        //        }
        //        //RecargarGrillDeTodosLosShoes();
        //    }
        //    RecargarGrillDeTodosLosShoes();

        //}
        //Func<Shoe, bool>? sportfiltro = null;
        //private void toolStripComboBoxSport_Click(object sender, EventArgs e)
        //{

        //    if (toolStripComboBoxSport.SelectedIndex > 0)
        //    {
        //        var servicio = _serviceProvider
        //            .GetService<ISportService>();
        //        sportFiltro = servicio?
        //            .GetSportPorNombre(toolStripComboBoxSport.Text);

        //        // Definir el filtro
        //        sportfiltro = p => p.Sports == sportFiltro;
        //        filtro = filtro == null ? sportfiltro : filtro.And(sportfiltro);


        //        // Obtener la cantidad de registros después de aplicar el filtro
        //        recordCount = _servicio.GetCantidad(filtro);
        //        txtcantidad.Text = recordCount.ToString();

        //        // Recalcular el número de páginas
        //        pageCount = FormHelper
        //            .CalcularPaginas(recordCount, pageSize);

        //        // Actualizar el texto del cuadro de texto de cantidad de registros
        //        txtCantidadRegistros.Text = pageCount.ToString();

        //        // Recargar el combo de páginas
        //        CombosHelper.CargarCombosPaginas(pageCount,
        //            ref cboPaginas);

        //        // Obtener la lista paginada ordenada y filtrada
        //        //lista = _servicio
        //        //    .GetListaPaginadaOrdenadaFiltrada(pageNum,
        //        //    pageSize, orden, brandFiltro,
        //        //    sportFiltro, genreFiltro, colourFiltro);
        //        //MostrarDatosEnGrilla();
        //        //RecargarGrillDeTodosLosShoes();

        //        toolStripSplitFiltro.BackColor = Color.Coral;
        //    }
        //    else
        //    {
        //        if (filtro != null)
        //        {
        //            sportFiltro = null;
        //            filtro = filtro.And(FiltroBuilder.Not(p => p.Sports == sportFiltro));
        //        }
        //        //RecargarGrillDeTodosLosShoes();

        //    }
        //    RecargarGrillDeTodosLosShoes();

        //}
        //Func<Shoe, bool>? genrefiltro = null;

        //private void toolStripComboBoxGenre_Click(object sender, EventArgs e)
        //{
        //    if (toolStripComboBoxGenre.SelectedIndex > 0)
        //    {
        //        var servicio = _serviceProvider
        //            .GetService<IGenreService>();
        //        genreFiltro = servicio?
        //            .GetGenrePorNombre(toolStripComboBoxGenre.Text);

        //        // Definir el filtro
        //        genrefiltro = p => p.Genres == genreFiltro;
        //        filtro = filtro == null ? genrefiltro : filtro.And(genrefiltro);

        //        // Obtener la cantidad de registros después de aplicar el filtro
        //        recordCount = _servicio.GetCantidad(filtro);
        //        txtcantidad.Text = recordCount.ToString();

        //        // Recalcular el número de páginas
        //        pageCount = FormHelper
        //            .CalcularPaginas(recordCount, pageSize);

        //        // Actualizar el texto del cuadro de texto de cantidad de registros
        //        txtCantidadRegistros.Text = pageCount.ToString();

        //        // Recargar el combo de páginas
        //        CombosHelper.CargarCombosPaginas(pageCount,
        //            ref cboPaginas);

        //        // Obtener la lista paginada ordenada y filtrada
        //        //lista = _servicio
        //        //    .GetListaPaginadaOrdenadaFiltrada(pageNum,
        //        //    pageSize, orden, brandFiltro,
        //        //    sportFiltro, genreFiltro, colourFiltro);
        //        //MostrarDatosEnGrilla();

        //        toolStripSplitFiltro.BackColor = Color.Aquamarine;
        //    }
        //    else
        //    {
        //        if (filtro != null)
        //        {
        //            genreFiltro = null;
        //            filtro = filtro.And(FiltroBuilder.Not(p => p.Genres == genreFiltro));
        //        }

        //    }
        //    RecargarGrillDeTodosLosShoes();

        //}
        //Func<Shoe, bool>? colorfiltro = null;
        //private void toolStripComboBoxColor_Click(object sender, EventArgs e)
        //{

        //    if (toolStripComboBoxColor.SelectedIndex > 0)
        //    {
        //        var servicio = _serviceProvider
        //            .GetService<IColorService>();
        //        colourFiltro = servicio?
        //            .GetColourPorNombre(toolStripComboBoxColor.Text);

        //        // Definir el filtro
        //        colorfiltro = p => p.Color == colourFiltro;
        //        filtro = filtro == null ? colorfiltro : filtro.And(colorfiltro);

        //        // Obtener la cantidad de registros después de aplicar el filtro
        //        recordCount = _servicio.GetCantidad(filtro);
        //        txtcantidad.Text = recordCount.ToString();

        //        // Recalcular el número de páginas
        //        pageCount = FormHelper
        //            .CalcularPaginas(recordCount, pageSize);

        //        // Actualizar el texto del cuadro de texto de cantidad de registros
        //        txtCantidadRegistros.Text = pageCount.ToString();

        //        // Recargar el combo de páginas
        //        CombosHelper.CargarCombosPaginas(pageCount,
        //            ref cboPaginas);

        //        // Obtener la lista paginada ordenada y filtrada
        //        //lista = _servicio
        //        //    .GetListaPaginadaOrdenadaFiltrada(pageNum,
        //        //    pageSize, orden, brandFiltro,
        //        //    sportFiltro, genreFiltro, colourFiltro);
        //        //MostrarDatosEnGrilla();

        //        toolStripSplitFiltro.BackColor = Color.BlueViolet;
        //    }
        //    else
        //    {
        //        if (filtro != null)
        //        {
        //            colourFiltro = null;
        //            filtro = filtro.And(FiltroBuilder.Not(p => p.Color == colourFiltro));
        //        }
        //        //RecargarGrillDeTodosLosShoes();

        //    }
        //    RecargarGrillDeTodosLosShoes();

        //}
    }
}
