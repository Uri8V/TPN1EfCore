namespace TPN1EfCore.Windows
{
    partial class frmSportAE
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
            txtSport = new TextBox();
            label1 = new Label();
            btnConfirmar = new Button();
            brnSalir = new Button();
            errorProvider1 = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // txtSport
            // 
            txtSport.Location = new Point(160, 21);
            txtSport.Name = "txtSport";
            txtSport.Size = new Size(141, 23);
            txtSport.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(25, 24);
            label1.Name = "label1";
            label1.Size = new Size(127, 15);
            label1.TabIndex = 5;
            label1.Text = "Ingrese el nuevo Sport:";
            // 
            // btnConfirmar
            // 
            btnConfirmar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnConfirmar.Location = new Point(25, 69);
            btnConfirmar.Name = "btnConfirmar";
            btnConfirmar.Size = new Size(86, 41);
            btnConfirmar.TabIndex = 3;
            btnConfirmar.Text = "CONFIRMAR";
            btnConfirmar.UseVisualStyleBackColor = true;
            btnConfirmar.Click += btnConfirmar_Click;
            // 
            // brnSalir
            // 
            brnSalir.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            brnSalir.Location = new Point(232, 69);
            brnSalir.Name = "brnSalir";
            brnSalir.Size = new Size(69, 41);
            brnSalir.TabIndex = 4;
            brnSalir.Text = "SALIR";
            brnSalir.UseVisualStyleBackColor = true;
            brnSalir.Click += brnSalir_Click;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // frmSportAE
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(349, 122);
            ControlBox = false;
            Controls.Add(txtSport);
            Controls.Add(label1);
            Controls.Add(btnConfirmar);
            Controls.Add(brnSalir);
            MaximumSize = new Size(365, 161);
            MinimumSize = new Size(365, 161);
            Name = "frmSportAE";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmSportAE";
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtSport;
        private Label label1;
        private Button btnConfirmar;
        private Button brnSalir;
        private ErrorProvider errorProvider1;
    }
}