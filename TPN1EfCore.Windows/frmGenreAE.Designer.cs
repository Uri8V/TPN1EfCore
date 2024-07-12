namespace TPN1EfCore.Windows
{
    partial class frmGenreAE
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
            txtGenre = new TextBox();
            label1 = new Label();
            btnConfirmar = new Button();
            brnSalir = new Button();
            errorProvider1 = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // txtGenre
            // 
            txtGenre.Location = new Point(154, 30);
            txtGenre.Name = "txtGenre";
            txtGenre.Size = new Size(141, 23);
            txtGenre.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(19, 33);
            label1.Name = "label1";
            label1.Size = new Size(130, 15);
            label1.TabIndex = 5;
            label1.Text = "Ingrese el nuevo Genre:";
            // 
            // btnConfirmar
            // 
            btnConfirmar.Anchor = AnchorStyles.None;
            btnConfirmar.Image = Properties.Resources.ok_45px;
            btnConfirmar.Location = new Point(19, 82);
            btnConfirmar.MaximumSize = new Size(94, 79);
            btnConfirmar.MinimumSize = new Size(94, 79);
            btnConfirmar.Name = "btnConfirmar";
            btnConfirmar.Size = new Size(94, 79);
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
            brnSalir.Location = new Point(201, 82);
            brnSalir.MaximumSize = new Size(94, 79);
            brnSalir.MinimumSize = new Size(94, 79);
            brnSalir.Name = "brnSalir";
            brnSalir.Size = new Size(94, 79);
            brnSalir.TabIndex = 4;
            brnSalir.Text = "SALIR";
            brnSalir.TextImageRelation = TextImageRelation.ImageAboveText;
            brnSalir.UseVisualStyleBackColor = true;
            brnSalir.Click += brnSalir_Click;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // frmGenreAE
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(319, 173);
            ControlBox = false;
            Controls.Add(txtGenre);
            Controls.Add(label1);
            Controls.Add(btnConfirmar);
            Controls.Add(brnSalir);
            MaximumSize = new Size(335, 212);
            MinimumSize = new Size(335, 212);
            Name = "frmGenreAE";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmGenreAE";
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtGenre;
        private Label label1;
        private Button btnConfirmar;
        private Button brnSalir;
        private ErrorProvider errorProvider1;
    }
}