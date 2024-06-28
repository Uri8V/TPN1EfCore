namespace TPN1EfCore.Windows
{
    partial class frmShoeAE
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
            components = new System.ComponentModel.Container();
            errorProvider1 = new ErrorProvider(components);
            label1 = new Label();
            cbBrand = new ComboBox();
            cbColor = new ComboBox();
            label2 = new Label();
            cbGenre = new ComboBox();
            label3 = new Label();
            cbSport = new ComboBox();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            txtPrecio = new TextBox();
            txtModelo = new TextBox();
            txtDescripcion = new TextBox();
            btnConfirmar = new Button();
            btnCancelar = new Button();
            btnAgregarBrand = new Button();
            btnAgregarSport = new Button();
            btnAgregarGenre = new Button();
            btnAgregarColor = new Button();
            lblBrandNueva = new Label();
            lblSportNuevo = new Label();
            lblGenreNuevo = new Label();
            lblColorNuevo = new Label();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(16, 15);
            label1.Name = "label1";
            label1.Size = new Size(123, 15);
            label1.TabIndex = 0;
            label1.Text = "Seleccione una Brand:";
            // 
            // cbBrand
            // 
            cbBrand.DropDownStyle = ComboBoxStyle.DropDownList;
            cbBrand.FormattingEnabled = true;
            cbBrand.Location = new Point(145, 12);
            cbBrand.MaximumSize = new Size(205, 0);
            cbBrand.MinimumSize = new Size(205, 0);
            cbBrand.Name = "cbBrand";
            cbBrand.Size = new Size(205, 23);
            cbBrand.TabIndex = 1;
            cbBrand.SelectedIndexChanged += cbBrand_SelectedIndexChanged;
            // 
            // cbColor
            // 
            cbColor.DropDownStyle = ComboBoxStyle.DropDownList;
            cbColor.FormattingEnabled = true;
            cbColor.Location = new Point(145, 154);
            cbColor.MaximumSize = new Size(205, 0);
            cbColor.MinimumSize = new Size(205, 0);
            cbColor.Name = "cbColor";
            cbColor.Size = new Size(205, 23);
            cbColor.TabIndex = 3;
            cbColor.SelectedIndexChanged += cbColor_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(16, 157);
            label2.Name = "label2";
            label2.Size = new Size(115, 15);
            label2.TabIndex = 2;
            label2.Text = "Seleccione un Color:";
            // 
            // cbGenre
            // 
            cbGenre.DropDownStyle = ComboBoxStyle.DropDownList;
            cbGenre.FormattingEnabled = true;
            cbGenre.Location = new Point(145, 107);
            cbGenre.MaximumSize = new Size(205, 0);
            cbGenre.MinimumSize = new Size(205, 0);
            cbGenre.Name = "cbGenre";
            cbGenre.Size = new Size(205, 23);
            cbGenre.TabIndex = 5;
            cbGenre.SelectedIndexChanged += cbGenre_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(16, 110);
            label3.Name = "label3";
            label3.Size = new Size(117, 15);
            label3.TabIndex = 4;
            label3.Text = "Seleccione un Genre:";
            // 
            // cbSport
            // 
            cbSport.DropDownStyle = ComboBoxStyle.DropDownList;
            cbSport.FormattingEnabled = true;
            cbSport.Location = new Point(145, 61);
            cbSport.MaximumSize = new Size(205, 0);
            cbSport.MinimumSize = new Size(205, 0);
            cbSport.Name = "cbSport";
            cbSport.Size = new Size(205, 23);
            cbSport.TabIndex = 7;
            cbSport.SelectedIndexChanged += comboBox4_SelectedIndexChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(16, 64);
            label4.Name = "label4";
            label4.Size = new Size(114, 15);
            label4.TabIndex = 6;
            label4.Text = "Seleccione un Sport:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(453, 15);
            label5.Name = "label5";
            label5.Size = new Size(96, 15);
            label5.TabIndex = 8;
            label5.Text = "Ingrese el Precio:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(453, 64);
            label6.Name = "label6";
            label6.Size = new Size(104, 15);
            label6.TabIndex = 9;
            label6.Text = "Ingrese el Modelo:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(453, 110);
            label7.Name = "label7";
            label7.Size = new Size(125, 15);
            label7.TabIndex = 10;
            label7.Text = "Ingrese la Descripción:";
            // 
            // txtPrecio
            // 
            txtPrecio.Location = new Point(570, 12);
            txtPrecio.MaximumSize = new Size(100, 23);
            txtPrecio.MaxLength = 50;
            txtPrecio.MinimumSize = new Size(100, 23);
            txtPrecio.Name = "txtPrecio";
            txtPrecio.Size = new Size(100, 23);
            txtPrecio.TabIndex = 11;
            // 
            // txtModelo
            // 
            txtModelo.Location = new Point(582, 64);
            txtModelo.MaxLength = 100;
            txtModelo.Name = "txtModelo";
            txtModelo.Size = new Size(121, 23);
            txtModelo.TabIndex = 12;
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(584, 102);
            txtDescripcion.MaxLength = 250;
            txtDescripcion.Multiline = true;
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(132, 70);
            txtDescripcion.TabIndex = 13;
            // 
            // btnConfirmar
            // 
            btnConfirmar.Location = new Point(127, 240);
            btnConfirmar.MaximumSize = new Size(96, 54);
            btnConfirmar.MinimumSize = new Size(96, 54);
            btnConfirmar.Name = "btnConfirmar";
            btnConfirmar.Size = new Size(96, 54);
            btnConfirmar.TabIndex = 14;
            btnConfirmar.Text = "CONFIRMAR";
            btnConfirmar.UseVisualStyleBackColor = true;
            btnConfirmar.Click += btnConfirmar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(520, 240);
            btnCancelar.MaximumSize = new Size(96, 54);
            btnCancelar.MinimumSize = new Size(96, 54);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(96, 54);
            btnCancelar.TabIndex = 14;
            btnCancelar.Text = "CANCELAR";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnAgregarBrand
            // 
            btnAgregarBrand.Location = new Point(373, 3);
            btnAgregarBrand.MaximumSize = new Size(96, 54);
            btnAgregarBrand.Name = "btnAgregarBrand";
            btnAgregarBrand.Size = new Size(46, 39);
            btnAgregarBrand.TabIndex = 14;
            btnAgregarBrand.Text = "Agregar Brand";
            btnAgregarBrand.UseVisualStyleBackColor = true;
            btnAgregarBrand.Click += btnAgregarBrand_Click;
            // 
            // btnAgregarSport
            // 
            btnAgregarSport.Location = new Point(373, 52);
            btnAgregarSport.MaximumSize = new Size(96, 54);
            btnAgregarSport.Name = "btnAgregarSport";
            btnAgregarSport.Size = new Size(46, 39);
            btnAgregarSport.TabIndex = 14;
            btnAgregarSport.Text = "Agregar Sport";
            btnAgregarSport.UseVisualStyleBackColor = true;
            btnAgregarSport.Click += btnAgregarSport_Click;
            // 
            // btnAgregarGenre
            // 
            btnAgregarGenre.Location = new Point(373, 98);
            btnAgregarGenre.MaximumSize = new Size(96, 54);
            btnAgregarGenre.Name = "btnAgregarGenre";
            btnAgregarGenre.Size = new Size(46, 39);
            btnAgregarGenre.TabIndex = 14;
            btnAgregarGenre.Text = "Agregar Genre";
            btnAgregarGenre.UseVisualStyleBackColor = true;
            btnAgregarGenre.Click += btnAgregarGenre_Click;
            // 
            // btnAgregarColor
            // 
            btnAgregarColor.Location = new Point(373, 145);
            btnAgregarColor.MaximumSize = new Size(96, 54);
            btnAgregarColor.Name = "btnAgregarColor";
            btnAgregarColor.Size = new Size(46, 39);
            btnAgregarColor.TabIndex = 14;
            btnAgregarColor.Text = "Agregar Color";
            btnAgregarColor.UseVisualStyleBackColor = true;
            btnAgregarColor.Click += btnAgregarColor_Click;
            // 
            // lblBrandNueva
            // 
            lblBrandNueva.AutoSize = true;
            lblBrandNueva.Enabled = false;
            lblBrandNueva.Location = new Point(157, 38);
            lblBrandNueva.Name = "lblBrandNueva";
            lblBrandNueva.Size = new Size(150, 15);
            lblBrandNueva.TabIndex = 0;
            lblBrandNueva.Text = "Nueva Brand Seleccionada:";
            lblBrandNueva.Visible = false;
            // 
            // lblSportNuevo
            // 
            lblSportNuevo.AutoSize = true;
            lblSportNuevo.Enabled = false;
            lblSportNuevo.Location = new Point(157, 87);
            lblSportNuevo.Name = "lblSportNuevo";
            lblSportNuevo.Size = new Size(148, 15);
            lblSportNuevo.TabIndex = 0;
            lblSportNuevo.Text = "Nuevo Sport Seleccionada:";
            lblSportNuevo.Visible = false;
            // 
            // lblGenreNuevo
            // 
            lblGenreNuevo.AutoSize = true;
            lblGenreNuevo.Enabled = false;
            lblGenreNuevo.Location = new Point(157, 133);
            lblGenreNuevo.Name = "lblGenreNuevo";
            lblGenreNuevo.Size = new Size(152, 15);
            lblGenreNuevo.TabIndex = 0;
            lblGenreNuevo.Text = "Nuevo Genre Seleccionado:";
            lblGenreNuevo.Visible = false;
            // 
            // lblColorNuevo
            // 
            lblColorNuevo.AutoSize = true;
            lblColorNuevo.Enabled = false;
            lblColorNuevo.Location = new Point(157, 180);
            lblColorNuevo.Name = "lblColorNuevo";
            lblColorNuevo.Size = new Size(150, 15);
            lblColorNuevo.TabIndex = 0;
            lblColorNuevo.Text = "Nuevo Color Seleccionado:";
            lblColorNuevo.Visible = false;
            // 
            // frmShoeAE
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(780, 308);
            ControlBox = false;
            Controls.Add(btnAgregarColor);
            Controls.Add(btnAgregarGenre);
            Controls.Add(btnAgregarSport);
            Controls.Add(btnAgregarBrand);
            Controls.Add(btnCancelar);
            Controls.Add(btnConfirmar);
            Controls.Add(txtDescripcion);
            Controls.Add(txtModelo);
            Controls.Add(txtPrecio);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(cbSport);
            Controls.Add(label4);
            Controls.Add(cbGenre);
            Controls.Add(label3);
            Controls.Add(cbColor);
            Controls.Add(label2);
            Controls.Add(cbBrand);
            Controls.Add(lblColorNuevo);
            Controls.Add(lblGenreNuevo);
            Controls.Add(lblSportNuevo);
            Controls.Add(lblBrandNueva);
            Controls.Add(label1);
            MaximumSize = new Size(796, 347);
            MinimumSize = new Size(796, 347);
            Name = "frmShoeAE";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmShoeAE";
            Load += frmShoeAE_Load;
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ErrorProvider errorProvider1;
        private ComboBox cbSport;
        private Label label4;
        private ComboBox cbGenre;
        private Label label3;
        private ComboBox cbColor;
        private Label label2;
        private ComboBox cbBrand;
        private Label label1;
        private Label label5;
        private TextBox txtPrecio;
        private Label label7;
        private Label label6;
        private TextBox txtModelo;
        private Button btnConfirmar;
        private TextBox txtDescripcion;
        private Button btnCancelar;
        private Button btnAgregarBrand;
        private Button btnAgregarColor;
        private Button btnAgregarGenre;
        private Button btnAgregarSport;
        private Label lblBrandNueva;
        private Label lblColorNuevo;
        private Label lblGenreNuevo;
        private Label lblSportNuevo;
    }
}