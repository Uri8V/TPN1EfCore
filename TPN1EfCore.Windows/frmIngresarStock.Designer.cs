namespace TPN1EfCore.Windows
{
    partial class frmIngresarStock
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
            textBox1 = new TextBox();
            btnConfirmar = new Button();
            label1 = new Label();
            btnCancelar = new Button();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(101, 29);
            textBox1.MaximumSize = new Size(100, 23);
            textBox1.MinimumSize = new Size(100, 23);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 0;
            // 
            // btnConfirmar
            // 
            btnConfirmar.Image = Properties.Resources.ok_45px;
            btnConfirmar.Location = new Point(12, 69);
            btnConfirmar.Name = "btnConfirmar";
            btnConfirmar.Size = new Size(94, 79);
            btnConfirmar.TabIndex = 1;
            btnConfirmar.Text = "Confirmar";
            btnConfirmar.TextImageRelation = TextImageRelation.ImageAboveText;
            btnConfirmar.UseVisualStyleBackColor = true;
            btnConfirmar.Click += btnConfirmar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(11, 32);
            label1.Name = "label1";
            label1.Size = new Size(84, 15);
            label1.TabIndex = 2;
            label1.Text = "Ingresar Stock:";
            // 
            // btnCancelar
            // 
            btnCancelar.Image = Properties.Resources.cancel_45px;
            btnCancelar.Location = new Point(130, 69);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(94, 79);
            btnCancelar.TabIndex = 1;
            btnCancelar.Text = "Cancelar";
            btnCancelar.TextImageRelation = TextImageRelation.ImageAboveText;
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // frmIngresarStock
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(236, 167);
            ControlBox = false;
            Controls.Add(label1);
            Controls.Add(btnCancelar);
            Controls.Add(btnConfirmar);
            Controls.Add(textBox1);
            MaximumSize = new Size(252, 206);
            MinimumSize = new Size(252, 206);
            Name = "frmIngresarStock";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmIngresarStock";
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ErrorProvider errorProvider1;
        private Label label1;
        private Button btnCancelar;
        private Button btnConfirmar;
        private TextBox textBox1;
    }
}