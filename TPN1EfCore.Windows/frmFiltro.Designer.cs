namespace TPN1EfCore.Windows
{
    partial class frmFiltro
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
            btnCancelar = new Button();
            btnConfirmar = new Button();
            cbSport = new ComboBox();
            label4 = new Label();
            cbGenre = new ComboBox();
            label3 = new Label();
            cbColor = new ComboBox();
            label2 = new Label();
            cbBrand = new ComboBox();
            label1 = new Label();
            errorProvider1 = new ErrorProvider(components);
            label5 = new Label();
            txtMinimo = new TextBox();
            txtMaximo = new TextBox();
            label6 = new Label();
            label7 = new Label();
            checkSi = new CheckBox();
            chekSize = new CheckBox();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            cbSize = new ComboBox();
            cbSizeMaximo = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(266, 221);
            btnCancelar.MaximumSize = new Size(96, 54);
            btnCancelar.MinimumSize = new Size(96, 54);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(96, 54);
            btnCancelar.TabIndex = 23;
            btnCancelar.Text = "CANCELAR";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnConfirmar
            // 
            btnConfirmar.Location = new Point(53, 221);
            btnConfirmar.MaximumSize = new Size(96, 54);
            btnConfirmar.MinimumSize = new Size(96, 54);
            btnConfirmar.Name = "btnConfirmar";
            btnConfirmar.Size = new Size(96, 54);
            btnConfirmar.TabIndex = 24;
            btnConfirmar.Text = "CONFIRMAR";
            btnConfirmar.UseVisualStyleBackColor = true;
            btnConfirmar.Click += btnConfirmar_Click;
            // 
            // cbSport
            // 
            cbSport.DropDownStyle = ComboBoxStyle.DropDownList;
            cbSport.FormattingEnabled = true;
            cbSport.Location = new Point(157, 61);
            cbSport.MaximumSize = new Size(205, 0);
            cbSport.MinimumSize = new Size(205, 0);
            cbSport.Name = "cbSport";
            cbSport.Size = new Size(205, 23);
            cbSport.TabIndex = 22;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(28, 64);
            label4.Name = "label4";
            label4.Size = new Size(114, 15);
            label4.TabIndex = 21;
            label4.Text = "Seleccione un Sport:";
            // 
            // cbGenre
            // 
            cbGenre.DropDownStyle = ComboBoxStyle.DropDownList;
            cbGenre.FormattingEnabled = true;
            cbGenre.Location = new Point(157, 107);
            cbGenre.MaximumSize = new Size(205, 0);
            cbGenre.MinimumSize = new Size(205, 0);
            cbGenre.Name = "cbGenre";
            cbGenre.Size = new Size(205, 23);
            cbGenre.TabIndex = 20;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(28, 110);
            label3.Name = "label3";
            label3.Size = new Size(117, 15);
            label3.TabIndex = 19;
            label3.Text = "Seleccione un Genre:";
            // 
            // cbColor
            // 
            cbColor.DropDownStyle = ComboBoxStyle.DropDownList;
            cbColor.FormattingEnabled = true;
            cbColor.Location = new Point(157, 154);
            cbColor.MaximumSize = new Size(205, 0);
            cbColor.MinimumSize = new Size(205, 0);
            cbColor.Name = "cbColor";
            cbColor.Size = new Size(205, 23);
            cbColor.TabIndex = 18;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(28, 157);
            label2.Name = "label2";
            label2.Size = new Size(115, 15);
            label2.TabIndex = 17;
            label2.Text = "Seleccione un Color:";
            // 
            // cbBrand
            // 
            cbBrand.DropDownStyle = ComboBoxStyle.DropDownList;
            cbBrand.FormattingEnabled = true;
            cbBrand.Location = new Point(157, 12);
            cbBrand.MaximumSize = new Size(205, 0);
            cbBrand.MinimumSize = new Size(205, 0);
            cbBrand.Name = "cbBrand";
            cbBrand.Size = new Size(205, 23);
            cbBrand.TabIndex = 16;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(28, 15);
            label1.Name = "label1";
            label1.Size = new Size(123, 15);
            label1.TabIndex = 15;
            label1.Text = "Seleccione una Brand:";
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(401, 40);
            label5.Name = "label5";
            label5.Size = new Size(141, 15);
            label5.TabIndex = 25;
            label5.Text = "Ingrese el precio minimo:";
            // 
            // txtMinimo
            // 
            txtMinimo.Enabled = false;
            txtMinimo.Location = new Point(548, 37);
            txtMinimo.MaximumSize = new Size(145, 23);
            txtMinimo.MaxLength = 100;
            txtMinimo.MinimumSize = new Size(145, 23);
            txtMinimo.Name = "txtMinimo";
            txtMinimo.Size = new Size(145, 23);
            txtMinimo.TabIndex = 26;
            // 
            // txtMaximo
            // 
            txtMaximo.Enabled = false;
            txtMaximo.Location = new Point(548, 76);
            txtMaximo.MaximumSize = new Size(145, 23);
            txtMaximo.MaxLength = 100;
            txtMaximo.MinimumSize = new Size(145, 23);
            txtMaximo.Name = "txtMaximo";
            txtMaximo.Size = new Size(145, 23);
            txtMaximo.TabIndex = 26;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(399, 79);
            label6.Name = "label6";
            label6.Size = new Size(143, 15);
            label6.TabIndex = 25;
            label6.Text = "Ingrese el precio maximo:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(411, 16);
            label7.Name = "label7";
            label7.Size = new Size(131, 15);
            label7.TabIndex = 27;
            label7.Text = "Desea filtrar por precio?";
            // 
            // checkSi
            // 
            checkSi.AutoSize = true;
            checkSi.Location = new Point(548, 12);
            checkSi.Name = "checkSi";
            checkSi.Size = new Size(35, 19);
            checkSi.TabIndex = 28;
            checkSi.Text = "Si";
            checkSi.UseVisualStyleBackColor = true;
            checkSi.CheckedChanged += checkSi_CheckedChanged;
            // 
            // chekSize
            // 
            chekSize.AutoSize = true;
            chekSize.Location = new Point(581, 130);
            chekSize.Name = "chekSize";
            chekSize.Size = new Size(35, 19);
            chekSize.TabIndex = 34;
            chekSize.Text = "Si";
            chekSize.UseVisualStyleBackColor = true;
            chekSize.Visible = false;
            chekSize.CheckedChanged += chekSize_CheckedChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(402, 131);
            label8.Name = "label8";
            label8.Size = new Size(173, 15);
            label8.TabIndex = 33;
            label8.Text = "Desea filtrar por rango de Sizes?";
            label8.Visible = false;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(399, 199);
            label9.Name = "label9";
            label9.Size = new Size(140, 15);
            label9.TabIndex = 29;
            label9.Text = "Seleccionar Size Maximo:";
            label9.Visible = false;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(401, 160);
            label10.Name = "label10";
            label10.Size = new Size(110, 15);
            label10.TabIndex = 30;
            label10.Text = "Seleccionar un Size:";
            label10.Visible = false;
            // 
            // cbSize
            // 
            cbSize.FormattingEnabled = true;
            cbSize.Location = new Point(517, 157);
            cbSize.Name = "cbSize";
            cbSize.Size = new Size(121, 23);
            cbSize.TabIndex = 35;
            cbSize.Visible = false;
            // 
            // cbSizeMaximo
            // 
            cbSizeMaximo.Enabled = false;
            cbSizeMaximo.FormattingEnabled = true;
            cbSizeMaximo.Location = new Point(545, 196);
            cbSizeMaximo.Name = "cbSizeMaximo";
            cbSizeMaximo.Size = new Size(121, 23);
            cbSizeMaximo.TabIndex = 36;
            cbSizeMaximo.Visible = false;
            // 
            // frmFiltro
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(736, 310);
            ControlBox = false;
            Controls.Add(cbSizeMaximo);
            Controls.Add(cbSize);
            Controls.Add(chekSize);
            Controls.Add(label8);
            Controls.Add(label9);
            Controls.Add(label10);
            Controls.Add(checkSi);
            Controls.Add(label7);
            Controls.Add(txtMaximo);
            Controls.Add(label6);
            Controls.Add(txtMinimo);
            Controls.Add(label5);
            Controls.Add(btnCancelar);
            Controls.Add(btnConfirmar);
            Controls.Add(cbSport);
            Controls.Add(label4);
            Controls.Add(cbGenre);
            Controls.Add(label3);
            Controls.Add(cbColor);
            Controls.Add(label2);
            Controls.Add(cbBrand);
            Controls.Add(label1);
            MinimumSize = new Size(413, 326);
            Name = "frmFiltro";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmFiltro";
            Load += frmFiltro_Load;
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCancelar;
        private Button btnConfirmar;
        private ComboBox cbSport;
        private Label label4;
        private ComboBox cbGenre;
        private Label label3;
        private ComboBox cbColor;
        private Label label2;
        private ComboBox cbBrand;
        private Label label1;
        private ErrorProvider errorProvider1;
        private TextBox txtMaximo;
        private Label label6;
        private TextBox txtMinimo;
        private Label label5;
        private CheckBox checkSi;
        private Label label7;
        private CheckBox chekSize;
        private Label label8;
        private Label label9;
        private Label label10;
        private ComboBox cbSizeMaximo;
        private ComboBox cbSize;
    }
}