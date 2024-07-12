namespace TPN1EfCore.Windows
{
    partial class frmColorAE
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
            txtColour = new TextBox();
            label1 = new Label();
            btnConfirmar = new Button();
            brnSalir = new Button();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // txtColour
            // 
            txtColour.Location = new Point(152, 28);
            txtColour.Name = "txtColour";
            txtColour.Size = new Size(141, 23);
            txtColour.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(17, 31);
            label1.Name = "label1";
            label1.Size = new Size(128, 15);
            label1.TabIndex = 5;
            label1.Text = "Ingrese el nuevo Color:";
            // 
            // btnConfirmar
            // 
            btnConfirmar.Anchor = AnchorStyles.None;
            btnConfirmar.Image = Properties.Resources.ok_45px;
            btnConfirmar.Location = new Point(17, 71);
            btnConfirmar.Name = "btnConfirmar";
            btnConfirmar.Size = new Size(102, 81);
            btnConfirmar.TabIndex = 3;
            btnConfirmar.Text = "CONFIRMAR";
            btnConfirmar.TextImageRelation = TextImageRelation.ImageAboveText;
            btnConfirmar.UseVisualStyleBackColor = true;
            btnConfirmar.Click += btnConfirmar_Click;
            // 
            // brnSalir
            // 
            brnSalir.Anchor = AnchorStyles.None;
            brnSalir.Image = Properties.Resources.cancel_45px;
            brnSalir.Location = new Point(191, 71);
            brnSalir.Name = "brnSalir";
            brnSalir.Size = new Size(102, 81);
            brnSalir.TabIndex = 4;
            brnSalir.Text = "SALIR";
            brnSalir.TextImageRelation = TextImageRelation.ImageAboveText;
            brnSalir.UseVisualStyleBackColor = true;
            brnSalir.Click += brnSalir_Click;
            // 
            // frmColorAE
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(314, 164);
            ControlBox = false;
            Controls.Add(txtColour);
            Controls.Add(label1);
            Controls.Add(btnConfirmar);
            Controls.Add(brnSalir);
            MaximumSize = new Size(330, 203);
            MinimumSize = new Size(330, 203);
            Name = "frmColorAE";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmColorAE";
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ErrorProvider errorProvider1;
        private TextBox txtColour;
        private Label label1;
        private Button btnConfirmar;
        private Button brnSalir;
    }
}