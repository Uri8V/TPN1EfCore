namespace TPN1EfCore.Windows
{
    partial class frmBrand
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBrand));
            toolStrip1 = new ToolStrip();
            toolStripButtonSalir = new ToolStripButton();
            toolStripButtonAgregar = new ToolStripButton();
            toolStripButtonBorrar = new ToolStripButton();
            toolStripButtonEditar = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            toolStripButtonConsulta = new ToolStripButton();
            splitContainer1 = new SplitContainer();
            dgvDatosBrand = new DataGridView();
            colBrandName = new DataGridViewTextBoxColumn();
            label1 = new Label();
            txtcantidad = new TextBox();
            toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDatosBrand).BeginInit();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripButtonSalir, toolStripButtonAgregar, toolStripButtonBorrar, toolStripButtonEditar, toolStripSeparator1, toolStripButtonConsulta });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(448, 67);
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonSalir
            // 
            toolStripButtonSalir.Alignment = ToolStripItemAlignment.Right;
            toolStripButtonSalir.Image = (Image)resources.GetObject("toolStripButtonSalir.Image");
            toolStripButtonSalir.ImageScaling = ToolStripItemImageScaling.None;
            toolStripButtonSalir.ImageTransparentColor = Color.Magenta;
            toolStripButtonSalir.Name = "toolStripButtonSalir";
            toolStripButtonSalir.Size = new Size(49, 64);
            toolStripButtonSalir.Text = "SALIR";
            toolStripButtonSalir.TextImageRelation = TextImageRelation.ImageAboveText;
            toolStripButtonSalir.Click += toolStripButtonSalir_Click;
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
            toolStripButtonAgregar.Click += toolStripButtonAgregar_Click;
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
            toolStripButtonBorrar.Click += toolStripButtonBorrar_Click;
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
            toolStripButtonEditar.Click += toolStripButtonEditar_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 67);
            // 
            // toolStripButtonConsulta
            // 
            toolStripButtonConsulta.Image = Properties.Resources.Consultar_45px;
            toolStripButtonConsulta.ImageScaling = ToolStripItemImageScaling.None;
            toolStripButtonConsulta.ImageTransparentColor = Color.Magenta;
            toolStripButtonConsulta.Name = "toolStripButtonConsulta";
            toolStripButtonConsulta.Size = new Size(58, 64);
            toolStripButtonConsulta.Text = "Consulta";
            toolStripButtonConsulta.TextImageRelation = TextImageRelation.ImageAboveText;
            toolStripButtonConsulta.Click += toolStripButtonConsulta_Click;
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
            splitContainer1.Panel1.Controls.Add(dgvDatosBrand);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(label1);
            splitContainer1.Panel2.Controls.Add(txtcantidad);
            splitContainer1.Size = new Size(448, 260);
            splitContainer1.SplitterDistance = 200;
            splitContainer1.TabIndex = 1;
            // 
            // dgvDatosBrand
            // 
            dgvDatosBrand.AllowUserToAddRows = false;
            dgvDatosBrand.AllowUserToDeleteRows = false;
            dgvDatosBrand.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDatosBrand.Columns.AddRange(new DataGridViewColumn[] { colBrandName });
            dgvDatosBrand.Dock = DockStyle.Fill;
            dgvDatosBrand.Location = new Point(0, 0);
            dgvDatosBrand.MultiSelect = false;
            dgvDatosBrand.Name = "dgvDatosBrand";
            dgvDatosBrand.ReadOnly = true;
            dgvDatosBrand.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDatosBrand.Size = new Size(448, 200);
            dgvDatosBrand.TabIndex = 0;
            // 
            // colBrandName
            // 
            colBrandName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colBrandName.HeaderText = "Brand";
            colBrandName.Name = "colBrandName";
            colBrandName.ReadOnly = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(62, 32);
            label1.Name = "label1";
            label1.Size = new Size(113, 15);
            label1.TabIndex = 1;
            label1.Text = "Cantidad de Brands:";
            // 
            // txtcantidad
            // 
            txtcantidad.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            txtcantidad.Location = new Point(181, 29);
            txtcantidad.Name = "txtcantidad";
            txtcantidad.ReadOnly = true;
            txtcantidad.Size = new Size(46, 23);
            txtcantidad.TabIndex = 0;
            txtcantidad.Text = "0";
            // 
            // frmBrand
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(448, 327);
            ControlBox = false;
            Controls.Add(splitContainer1);
            Controls.Add(toolStrip1);
            MaximumSize = new Size(464, 366);
            MinimumSize = new Size(464, 366);
            Name = "frmBrand";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmBrand";
            Load += frmBrand_Load;
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvDatosBrand).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStrip toolStrip1;
        private ToolStripButton toolStripButtonSalir;
        private SplitContainer splitContainer1;
        private ToolStripButton toolStripButtonAgregar;
        private ToolStripButton toolStripButtonBorrar;
        private ToolStripButton toolStripButtonEditar;
        private DataGridView dgvDatosBrand;
        private DataGridViewTextBoxColumn colBrandName;
        private Label label1;
        private TextBox txtcantidad;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton toolStripButtonConsulta;
    }
}