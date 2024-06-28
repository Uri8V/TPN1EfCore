namespace TPN1EfCore.Windows
{
    partial class frmGenre
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGenre));
            toolStrip1 = new ToolStrip();
            toolStripButtonSalir = new ToolStripButton();
            toolStripButtonAgregar = new ToolStripButton();
            toolStripButtonBorrar = new ToolStripButton();
            toolStripButtonEditar = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            toolStripButtonConsulta = new ToolStripButton();
            splitContainer1 = new SplitContainer();
            dgvDatosGenre = new DataGridView();
            colGenreName = new DataGridViewTextBoxColumn();
            label1 = new Label();
            txtcantidad = new TextBox();
            toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDatosGenre).BeginInit();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripButtonSalir, toolStripButtonAgregar, toolStripButtonBorrar, toolStripButtonEditar, toolStripSeparator1, toolStripButtonConsulta });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(757, 38);
            toolStrip1.TabIndex = 2;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonSalir
            // 
            toolStripButtonSalir.Alignment = ToolStripItemAlignment.Right;
            toolStripButtonSalir.Image = (Image)resources.GetObject("toolStripButtonSalir.Image");
            toolStripButtonSalir.ImageScaling = ToolStripItemImageScaling.None;
            toolStripButtonSalir.ImageTransparentColor = Color.Magenta;
            toolStripButtonSalir.Name = "toolStripButtonSalir";
            toolStripButtonSalir.Size = new Size(41, 35);
            toolStripButtonSalir.Text = "SALIR";
            toolStripButtonSalir.TextImageRelation = TextImageRelation.ImageAboveText;
            toolStripButtonSalir.Click += toolStripButtonSalir_Click;
            // 
            // toolStripButtonAgregar
            // 
            toolStripButtonAgregar.Image = (Image)resources.GetObject("toolStripButtonAgregar.Image");
            toolStripButtonAgregar.ImageScaling = ToolStripItemImageScaling.None;
            toolStripButtonAgregar.ImageTransparentColor = Color.Magenta;
            toolStripButtonAgregar.Name = "toolStripButtonAgregar";
            toolStripButtonAgregar.Size = new Size(53, 35);
            toolStripButtonAgregar.Text = "Agregar";
            toolStripButtonAgregar.TextImageRelation = TextImageRelation.ImageAboveText;
            toolStripButtonAgregar.Click += toolStripButtonAgregar_Click;
            // 
            // toolStripButtonBorrar
            // 
            toolStripButtonBorrar.Image = (Image)resources.GetObject("toolStripButtonBorrar.Image");
            toolStripButtonBorrar.ImageScaling = ToolStripItemImageScaling.None;
            toolStripButtonBorrar.ImageTransparentColor = Color.Magenta;
            toolStripButtonBorrar.Name = "toolStripButtonBorrar";
            toolStripButtonBorrar.Size = new Size(43, 35);
            toolStripButtonBorrar.Text = "Borrar";
            toolStripButtonBorrar.TextImageRelation = TextImageRelation.ImageAboveText;
            toolStripButtonBorrar.Click += toolStripButtonBorrar_Click;
            // 
            // toolStripButtonEditar
            // 
            toolStripButtonEditar.Image = (Image)resources.GetObject("toolStripButtonEditar.Image");
            toolStripButtonEditar.ImageScaling = ToolStripItemImageScaling.None;
            toolStripButtonEditar.ImageTransparentColor = Color.Magenta;
            toolStripButtonEditar.Name = "toolStripButtonEditar";
            toolStripButtonEditar.Size = new Size(41, 35);
            toolStripButtonEditar.Text = "Editar";
            toolStripButtonEditar.TextImageRelation = TextImageRelation.ImageAboveText;
            toolStripButtonEditar.Click += toolStripButtonEditar_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 38);
            // 
            // toolStripButtonConsulta
            // 
            toolStripButtonConsulta.Image = (Image)resources.GetObject("toolStripButtonConsulta.Image");
            toolStripButtonConsulta.ImageScaling = ToolStripItemImageScaling.None;
            toolStripButtonConsulta.ImageTransparentColor = Color.Magenta;
            toolStripButtonConsulta.Name = "toolStripButtonConsulta";
            toolStripButtonConsulta.Size = new Size(58, 35);
            toolStripButtonConsulta.Text = "Consulta";
            toolStripButtonConsulta.TextImageRelation = TextImageRelation.ImageAboveText;
            toolStripButtonConsulta.Click += toolStripButtonConsulta_Click;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 38);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(dgvDatosGenre);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(label1);
            splitContainer1.Panel2.Controls.Add(txtcantidad);
            splitContainer1.Size = new Size(757, 343);
            splitContainer1.SplitterDistance = 252;
            splitContainer1.TabIndex = 3;
            // 
            // dgvDatosGenre
            // 
            dgvDatosGenre.AllowUserToAddRows = false;
            dgvDatosGenre.AllowUserToDeleteRows = false;
            dgvDatosGenre.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDatosGenre.Columns.AddRange(new DataGridViewColumn[] { colGenreName });
            dgvDatosGenre.Dock = DockStyle.Fill;
            dgvDatosGenre.Location = new Point(0, 0);
            dgvDatosGenre.MultiSelect = false;
            dgvDatosGenre.Name = "dgvDatosGenre";
            dgvDatosGenre.ReadOnly = true;
            dgvDatosGenre.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDatosGenre.Size = new Size(757, 252);
            dgvDatosGenre.TabIndex = 1;
            // 
            // colGenreName
            // 
            colGenreName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colGenreName.HeaderText = "Genre";
            colGenreName.Name = "colGenreName";
            colGenreName.ReadOnly = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(41, 38);
            label1.Name = "label1";
            label1.Size = new Size(113, 15);
            label1.TabIndex = 3;
            label1.Text = "Cantidad de Brands:";
            // 
            // txtcantidad
            // 
            txtcantidad.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            txtcantidad.Location = new Point(160, 35);
            txtcantidad.Name = "txtcantidad";
            txtcantidad.ReadOnly = true;
            txtcantidad.Size = new Size(46, 23);
            txtcantidad.TabIndex = 2;
            txtcantidad.Text = "0";
            // 
            // frmGenre
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(757, 381);
            ControlBox = false;
            Controls.Add(splitContainer1);
            Controls.Add(toolStrip1);
            Name = "frmGenre";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmGenre";
            Load += frmGenre_Load;
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvDatosGenre).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStrip toolStrip1;
        private ToolStripButton toolStripButtonSalir;
        private ToolStripButton toolStripButtonAgregar;
        private ToolStripButton toolStripButtonBorrar;
        private ToolStripButton toolStripButtonEditar;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton toolStripButtonConsulta;
        private SplitContainer splitContainer1;
        private DataGridView dgvDatosGenre;
        private DataGridViewTextBoxColumn colGenreName;
        private Label label1;
        private TextBox txtcantidad;
    }
}