namespace TPN1EfCore.Windows
{
    partial class frmBrandAE
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
            brnSalir = new Button();
            btnConfirmar = new Button();
            errorProvider1 = new ErrorProvider(components);
            label1 = new Label();
            txtBrand = new TextBox();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // brnSalir
            // 
            brnSalir.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            brnSalir.Image = Properties.Resources.cancel_45px;
            brnSalir.Location = new Point(211, 74);
            brnSalir.Name = "brnSalir";
            brnSalir.Size = new Size(86, 72);
            brnSalir.TabIndex = 0;
            brnSalir.Text = "SALIR";
            brnSalir.TextImageRelation = TextImageRelation.ImageAboveText;
            brnSalir.UseVisualStyleBackColor = true;
            brnSalir.Click += brnSalir_Click;
            // 
            // btnConfirmar
            // 
            btnConfirmar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnConfirmar.Image = Properties.Resources.ok_45px;
            btnConfirmar.Location = new Point(21, 74);
            btnConfirmar.Name = "btnConfirmar";
            btnConfirmar.Size = new Size(86, 72);
            btnConfirmar.TabIndex = 0;
            btnConfirmar.Text = "CONFIRMAR";
            btnConfirmar.TextImageRelation = TextImageRelation.ImageAboveText;
            btnConfirmar.UseVisualStyleBackColor = true;
            btnConfirmar.Click += brnConfirmar_Click;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(20, 21);
            label1.Name = "label1";
            label1.Size = new Size(129, 15);
            label1.TabIndex = 1;
            label1.Text = "Ingrese la nueva Brand:";
            // 
            // txtBrand
            // 
            txtBrand.Location = new Point(155, 18);
            txtBrand.Name = "txtBrand";
            txtBrand.Size = new Size(141, 23);
            txtBrand.TabIndex = 2;
            // 
            // frmBrandAE
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(309, 149);
            ControlBox = false;
            Controls.Add(txtBrand);
            Controls.Add(label1);
            Controls.Add(btnConfirmar);
            Controls.Add(brnSalir);
            MaximumSize = new Size(325, 188);
            MinimumSize = new Size(325, 188);
            Name = "frmBrandAE";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmBrandAE";
            Load += frmBrandAE_Load;
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button brnSalir;
        private Button btnConfirmar;
        private ErrorProvider errorProvider1;
        private TextBox txtBrand;
        private Label label1;
    }
}