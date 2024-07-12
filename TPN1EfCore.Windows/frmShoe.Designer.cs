namespace TPN1EfCore.Windows
{
    partial class frmShoe
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            txtcantidad = new TextBox();
            label1 = new Label();
            label3 = new Label();
            label2 = new Label();
            cboPaginas = new ComboBox();
            txtCantidadRegistros = new TextBox();
            btnPrimero = new Button();
            btnAnterior = new Button();
            btnSiguiente = new Button();
            btnUltimo = new Button();
            dgvDatos = new DataGridView();
            colBrandName = new DataGridViewTextBoxColumn();
            colSport = new DataGridViewTextBoxColumn();
            colGenre = new DataGridViewTextBoxColumn();
            colColor = new DataGridViewTextBoxColumn();
            colModelo = new DataGridViewTextBoxColumn();
            colPrecio = new DataGridViewTextBoxColumn();
            colDescripcion = new DataGridViewTextBoxColumn();
            colDetalles = new DataGridViewButtonColumn();
            splitContainer1 = new SplitContainer();
            toolStripButtonSalir = new ToolStripButton();
            toolStripButtonAgregar = new ToolStripButton();
            toolStripButtonBorrar = new ToolStripButton();
            toolStripButtonEditar = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            toolStripSplitFiltro = new ToolStripButton();
            toolStripButtonRestaurar = new ToolStripButton();
            toolStripDropDownOrden = new ToolStripDropDownButton();
            aZToolStripMenuItem = new ToolStripMenuItem();
            zAToolStripMenuItem = new ToolStripMenuItem();
            menorPrecioToolStripMenuItem = new ToolStripMenuItem();
            mayorPrecioToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            toolStripButtonAsignarShoe = new ToolStripButton();
            toolStrip1 = new ToolStrip();
            ((System.ComponentModel.ISupportInitialize)dgvDatos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // txtcantidad
            // 
            txtcantidad.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            txtcantidad.Location = new Point(751, 32);
            txtcantidad.Name = "txtcantidad";
            txtcantidad.ReadOnly = true;
            txtcantidad.Size = new Size(46, 23);
            txtcantidad.TabIndex = 0;
            txtcantidad.Text = "0";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(632, 35);
            label1.Name = "label1";
            label1.Size = new Size(108, 15);
            label1.TabIndex = 1;
            label1.Text = "Cantidad de Shoes:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(14, 35);
            label3.Name = "label3";
            label3.Size = new Size(33, 15);
            label3.TabIndex = 5;
            label3.Text = "Pág.:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(127, 35);
            label2.Name = "label2";
            label2.Size = new Size(23, 15);
            label2.TabIndex = 4;
            label2.Text = "de:";
            // 
            // cboPaginas
            // 
            cboPaginas.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPaginas.FormattingEnabled = true;
            cboPaginas.Location = new Point(53, 32);
            cboPaginas.Name = "cboPaginas";
            cboPaginas.Size = new Size(68, 23);
            cboPaginas.TabIndex = 6;
            cboPaginas.SelectedIndexChanged += cboPaginas_SelectedIndexChanged;
            // 
            // txtCantidadRegistros
            // 
            txtCantidadRegistros.Location = new Point(156, 32);
            txtCantidadRegistros.Name = "txtCantidadRegistros";
            txtCantidadRegistros.ReadOnly = true;
            txtCantidadRegistros.Size = new Size(85, 23);
            txtCantidadRegistros.TabIndex = 7;
            // 
            // btnPrimero
            // 
            btnPrimero.Image = Properties.Resources.First_45px;
            btnPrimero.Location = new Point(257, 3);
            btnPrimero.Name = "btnPrimero";
            btnPrimero.Size = new Size(75, 67);
            btnPrimero.TabIndex = 11;
            btnPrimero.Text = "Primero";
            btnPrimero.TextImageRelation = TextImageRelation.ImageAboveText;
            btnPrimero.UseVisualStyleBackColor = true;
            btnPrimero.Click += btnPrimero_Click;
            // 
            // btnAnterior
            // 
            btnAnterior.Image = Properties.Resources.return_45px;
            btnAnterior.Location = new Point(349, 3);
            btnAnterior.Name = "btnAnterior";
            btnAnterior.Size = new Size(75, 67);
            btnAnterior.TabIndex = 10;
            btnAnterior.Text = "Anterior";
            btnAnterior.TextImageRelation = TextImageRelation.ImageAboveText;
            btnAnterior.UseVisualStyleBackColor = true;
            btnAnterior.Click += btnAnterior_Click;
            // 
            // btnSiguiente
            // 
            btnSiguiente.Image = Properties.Resources.next_page_45px;
            btnSiguiente.Location = new Point(442, 3);
            btnSiguiente.Name = "btnSiguiente";
            btnSiguiente.Size = new Size(75, 67);
            btnSiguiente.TabIndex = 9;
            btnSiguiente.Text = "Siguiente";
            btnSiguiente.TextImageRelation = TextImageRelation.ImageAboveText;
            btnSiguiente.UseVisualStyleBackColor = true;
            btnSiguiente.Click += btnSiguiente_Click;
            // 
            // btnUltimo
            // 
            btnUltimo.Image = Properties.Resources.last_45px;
            btnUltimo.Location = new Point(533, 3);
            btnUltimo.Name = "btnUltimo";
            btnUltimo.Size = new Size(75, 67);
            btnUltimo.TabIndex = 8;
            btnUltimo.Text = "Último";
            btnUltimo.TextImageRelation = TextImageRelation.ImageAboveText;
            btnUltimo.UseVisualStyleBackColor = true;
            btnUltimo.Click += btnUltimo_Click;
            // 
            // dgvDatos
            // 
            dgvDatos.AccessibleRole = AccessibleRole.None;
            dgvDatos.AllowUserToAddRows = false;
            dgvDatos.AllowUserToDeleteRows = false;
            dgvDatos.AllowUserToResizeColumns = false;
            dgvDatos.AllowUserToResizeRows = false;
            dgvDatos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
            dgvDatos.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            dgvDatos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDatos.Columns.AddRange(new DataGridViewColumn[] { colBrandName, colSport, colGenre, colColor, colModelo, colPrecio, colDescripcion, colDetalles });
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Window;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvDatos.DefaultCellStyle = dataGridViewCellStyle1;
            dgvDatos.Dock = DockStyle.Fill;
            dgvDatos.Location = new Point(0, 0);
            dgvDatos.MultiSelect = false;
            dgvDatos.Name = "dgvDatos";
            dgvDatos.ReadOnly = true;
            dgvDatos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDatos.Size = new Size(963, 306);
            dgvDatos.TabIndex = 0;
            dgvDatos.CellContentClick += dgvDatos_CellContentClick;
            // 
            // colBrandName
            // 
            colBrandName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colBrandName.HeaderText = "Brand";
            colBrandName.Name = "colBrandName";
            colBrandName.ReadOnly = true;
            // 
            // colSport
            // 
            colSport.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colSport.HeaderText = "Sport";
            colSport.Name = "colSport";
            colSport.ReadOnly = true;
            // 
            // colGenre
            // 
            colGenre.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colGenre.HeaderText = "Genre";
            colGenre.Name = "colGenre";
            colGenre.ReadOnly = true;
            // 
            // colColor
            // 
            colColor.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colColor.HeaderText = "Color";
            colColor.Name = "colColor";
            colColor.ReadOnly = true;
            // 
            // colModelo
            // 
            colModelo.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colModelo.HeaderText = "Modelo";
            colModelo.Name = "colModelo";
            colModelo.ReadOnly = true;
            // 
            // colPrecio
            // 
            colPrecio.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colPrecio.HeaderText = "Price";
            colPrecio.Name = "colPrecio";
            colPrecio.ReadOnly = true;
            // 
            // colDescripcion
            // 
            colDescripcion.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colDescripcion.HeaderText = "Descripción";
            colDescripcion.Name = "colDescripcion";
            colDescripcion.ReadOnly = true;
            // 
            // colDetalles
            // 
            colDetalles.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colDetalles.HeaderText = "";
            colDetalles.Name = "colDetalles";
            colDetalles.ReadOnly = true;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 67);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(dgvDatos);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(btnUltimo);
            splitContainer1.Panel2.Controls.Add(btnSiguiente);
            splitContainer1.Panel2.Controls.Add(btnAnterior);
            splitContainer1.Panel2.Controls.Add(btnPrimero);
            splitContainer1.Panel2.Controls.Add(txtCantidadRegistros);
            splitContainer1.Panel2.Controls.Add(cboPaginas);
            splitContainer1.Panel2.Controls.Add(label2);
            splitContainer1.Panel2.Controls.Add(label3);
            splitContainer1.Panel2.Controls.Add(label1);
            splitContainer1.Panel2.Controls.Add(txtcantidad);
            splitContainer1.Size = new Size(963, 383);
            splitContainer1.SplitterDistance = 306;
            splitContainer1.TabIndex = 3;
            // 
            // toolStripButtonSalir
            // 
            toolStripButtonSalir.Alignment = ToolStripItemAlignment.Right;
            toolStripButtonSalir.Image = Properties.Resources.Logout_45px;
            toolStripButtonSalir.ImageScaling = ToolStripItemImageScaling.None;
            toolStripButtonSalir.ImageTransparentColor = Color.Magenta;
            toolStripButtonSalir.Name = "toolStripButtonSalir";
            toolStripButtonSalir.Size = new Size(49, 64);
            toolStripButtonSalir.Text = "SALIR";
            toolStripButtonSalir.TextImageRelation = TextImageRelation.ImageAboveText;
            toolStripButtonSalir.Click += tsbCerrar_Click;
            // 
            // toolStripButtonAgregar
            // 
            toolStripButtonAgregar.Image = Properties.Resources.New_45px;
            toolStripButtonAgregar.ImageScaling = ToolStripItemImageScaling.None;
            toolStripButtonAgregar.ImageTransparentColor = Color.Magenta;
            toolStripButtonAgregar.Name = "toolStripButtonAgregar";
            toolStripButtonAgregar.Size = new Size(53, 64);
            toolStripButtonAgregar.Text = "Agregar";
            toolStripButtonAgregar.TextImageRelation = TextImageRelation.ImageAboveText;
            toolStripButtonAgregar.Click += tsbNuevo_Click;
            // 
            // toolStripButtonBorrar
            // 
            toolStripButtonBorrar.Image = Properties.Resources.delete_document_45px;
            toolStripButtonBorrar.ImageScaling = ToolStripItemImageScaling.None;
            toolStripButtonBorrar.ImageTransparentColor = Color.Magenta;
            toolStripButtonBorrar.Name = "toolStripButtonBorrar";
            toolStripButtonBorrar.Size = new Size(49, 64);
            toolStripButtonBorrar.Text = "Borrar";
            toolStripButtonBorrar.TextImageRelation = TextImageRelation.ImageAboveText;
            toolStripButtonBorrar.Click += tsbBorrar_Click;
            // 
            // toolStripButtonEditar
            // 
            toolStripButtonEditar.Image = Properties.Resources.edit_property_45px;
            toolStripButtonEditar.ImageScaling = ToolStripItemImageScaling.None;
            toolStripButtonEditar.ImageTransparentColor = Color.Magenta;
            toolStripButtonEditar.Name = "toolStripButtonEditar";
            toolStripButtonEditar.Size = new Size(49, 64);
            toolStripButtonEditar.Text = "Editar";
            toolStripButtonEditar.TextImageRelation = TextImageRelation.ImageAboveText;
            toolStripButtonEditar.Click += tsbEditar_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 67);
            // 
            // toolStripSplitFiltro
            // 
            toolStripSplitFiltro.Image = Properties.Resources.Size_45px;
            toolStripSplitFiltro.ImageScaling = ToolStripItemImageScaling.None;
            toolStripSplitFiltro.ImageTransparentColor = Color.Magenta;
            toolStripSplitFiltro.Name = "toolStripSplitFiltro";
            toolStripSplitFiltro.Size = new Size(49, 64);
            toolStripSplitFiltro.Text = "Filtro";
            toolStripSplitFiltro.TextImageRelation = TextImageRelation.ImageAboveText;
            toolStripSplitFiltro.Click += toolStripSplitFiltro_Click;
            // 
            // toolStripButtonRestaurar
            // 
            toolStripButtonRestaurar.Image = Properties.Resources.Restaurar_45px;
            toolStripButtonRestaurar.ImageScaling = ToolStripItemImageScaling.None;
            toolStripButtonRestaurar.ImageTransparentColor = Color.Magenta;
            toolStripButtonRestaurar.Name = "toolStripButtonRestaurar";
            toolStripButtonRestaurar.Size = new Size(60, 64);
            toolStripButtonRestaurar.Text = "Restaurar";
            toolStripButtonRestaurar.TextImageRelation = TextImageRelation.ImageAboveText;
            toolStripButtonRestaurar.Click += tsbActualizar_Click;
            // 
            // toolStripDropDownOrden
            // 
            toolStripDropDownOrden.DropDownItems.AddRange(new ToolStripItem[] { aZToolStripMenuItem, zAToolStripMenuItem, menorPrecioToolStripMenuItem, mayorPrecioToolStripMenuItem });
            toolStripDropDownOrden.Image = Properties.Resources.Order_45px;
            toolStripDropDownOrden.ImageScaling = ToolStripItemImageScaling.None;
            toolStripDropDownOrden.ImageTransparentColor = Color.Magenta;
            toolStripDropDownOrden.Name = "toolStripDropDownOrden";
            toolStripDropDownOrden.Size = new Size(58, 64);
            toolStripDropDownOrden.Text = "Orden";
            toolStripDropDownOrden.TextImageRelation = TextImageRelation.ImageAboveText;
            // 
            // aZToolStripMenuItem
            // 
            aZToolStripMenuItem.Name = "aZToolStripMenuItem";
            aZToolStripMenuItem.Size = new Size(145, 22);
            aZToolStripMenuItem.Text = "AZ";
            aZToolStripMenuItem.Click += aZToolStripMenuItem_Click;
            // 
            // zAToolStripMenuItem
            // 
            zAToolStripMenuItem.Name = "zAToolStripMenuItem";
            zAToolStripMenuItem.Size = new Size(145, 22);
            zAToolStripMenuItem.Text = "ZA";
            zAToolStripMenuItem.Click += zAToolStripMenuItem_Click;
            // 
            // menorPrecioToolStripMenuItem
            // 
            menorPrecioToolStripMenuItem.Name = "menorPrecioToolStripMenuItem";
            menorPrecioToolStripMenuItem.Size = new Size(145, 22);
            menorPrecioToolStripMenuItem.Text = "Menor Precio";
            menorPrecioToolStripMenuItem.Click += menorPrecioToolStripMenuItem_Click;
            // 
            // mayorPrecioToolStripMenuItem
            // 
            mayorPrecioToolStripMenuItem.Name = "mayorPrecioToolStripMenuItem";
            mayorPrecioToolStripMenuItem.Size = new Size(145, 22);
            mayorPrecioToolStripMenuItem.Text = "Mayor Precio";
            mayorPrecioToolStripMenuItem.Click += mayorPrecioToolStripMenuItem_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 67);
            // 
            // toolStripButtonAsignarShoe
            // 
            toolStripButtonAsignarShoe.Image = Properties.Resources.GiveSize_45px;
            toolStripButtonAsignarShoe.ImageScaling = ToolStripItemImageScaling.None;
            toolStripButtonAsignarShoe.ImageTransparentColor = Color.Magenta;
            toolStripButtonAsignarShoe.Name = "toolStripButtonAsignarShoe";
            toolStripButtonAsignarShoe.Size = new Size(115, 64);
            toolStripButtonAsignarShoe.Text = "Asignar Size al Shoe";
            toolStripButtonAsignarShoe.TextImageRelation = TextImageRelation.ImageAboveText;
            toolStripButtonAsignarShoe.Click += toolStripButtonAsignarShoe_Click;
            // 
            // toolStrip1
            // 
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripButtonSalir, toolStripButtonAgregar, toolStripButtonBorrar, toolStripButtonEditar, toolStripSeparator1, toolStripSplitFiltro, toolStripButtonRestaurar, toolStripDropDownOrden, toolStripSeparator2, toolStripButtonAsignarShoe });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(963, 67);
            toolStrip1.TabIndex = 1;
            toolStrip1.Text = "toolStrip1";
            // 
            // frmShoe
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(963, 450);
            ControlBox = false;
            Controls.Add(splitContainer1);
            Controls.Add(toolStrip1);
            MaximumSize = new Size(979, 489);
            MinimumSize = new Size(979, 489);
            Name = "frmShoe";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmShoe";
            Load += frmShoe_Load;
            ((System.ComponentModel.ISupportInitialize)dgvDatos).EndInit();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtcantidad;
        private Label label1;
        private Label label3;
        private Label label2;
        private ComboBox cboPaginas;
        private TextBox txtCantidadRegistros;
        private Button btnPrimero;
        private Button btnAnterior;
        private Button btnSiguiente;
        private Button btnUltimo;
        private DataGridView dgvDatos;
        private DataGridViewTextBoxColumn colBrandName;
        private DataGridViewTextBoxColumn colSport;
        private DataGridViewTextBoxColumn colGenre;
        private DataGridViewTextBoxColumn colColor;
        private DataGridViewTextBoxColumn colModelo;
        private DataGridViewTextBoxColumn colPrecio;
        private DataGridViewTextBoxColumn colDescripcion;
        private DataGridViewButtonColumn colDetalles;
        private SplitContainer splitContainer1;
        private ToolStripButton toolStripButtonSalir;
        private ToolStripButton toolStripButtonAgregar;
        private ToolStripButton toolStripButtonBorrar;
        private ToolStripButton toolStripButtonEditar;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton toolStripSplitFiltro;
        private ToolStripButton toolStripButtonRestaurar;
        private ToolStripDropDownButton toolStripDropDownOrden;
        private ToolStripMenuItem aZToolStripMenuItem;
        private ToolStripMenuItem zAToolStripMenuItem;
        private ToolStripMenuItem menorPrecioToolStripMenuItem;
        private ToolStripMenuItem mayorPrecioToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton toolStripButtonAsignarShoe;
        private ToolStrip toolStrip1;
    }
}