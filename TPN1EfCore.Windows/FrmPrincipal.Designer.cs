namespace TPN1EfCore.Windows
{
    partial class FrmPrincipal
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
            btnSalir = new Button();
            btnBrand = new Button();
            btnSport = new Button();
            btnGenre = new Button();
            btnColor = new Button();
            btnShoes = new Button();
            btnTalles = new Button();
            SuspendLayout();
            // 
            // btnSalir
            // 
            btnSalir.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSalir.Location = new Point(429, 236);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(54, 23);
            btnSalir.TabIndex = 0;
            btnSalir.Text = "SALIR";
            btnSalir.TextImageRelation = TextImageRelation.ImageAboveText;
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // btnBrand
            // 
            btnBrand.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnBrand.Location = new Point(48, 48);
            btnBrand.Name = "btnBrand";
            btnBrand.Size = new Size(88, 51);
            btnBrand.TabIndex = 0;
            btnBrand.Text = "BRANDS";
            btnBrand.TextImageRelation = TextImageRelation.ImageAboveText;
            btnBrand.UseVisualStyleBackColor = true;
            btnBrand.Click += btnBrand_Click;
            // 
            // btnSport
            // 
            btnSport.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSport.Location = new Point(172, 48);
            btnSport.Name = "btnSport";
            btnSport.Size = new Size(88, 51);
            btnSport.TabIndex = 0;
            btnSport.Text = "SPORTS";
            btnSport.TextImageRelation = TextImageRelation.ImageAboveText;
            btnSport.UseVisualStyleBackColor = true;
            btnSport.Click += btnSport_Click;
            // 
            // btnGenre
            // 
            btnGenre.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnGenre.Location = new Point(287, 48);
            btnGenre.Name = "btnGenre";
            btnGenre.Size = new Size(88, 51);
            btnGenre.TabIndex = 0;
            btnGenre.Text = "GENRES";
            btnGenre.TextImageRelation = TextImageRelation.ImageAboveText;
            btnGenre.UseVisualStyleBackColor = true;
            btnGenre.Click += btnGenre_Click;
            // 
            // btnColor
            // 
            btnColor.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnColor.Location = new Point(48, 127);
            btnColor.Name = "btnColor";
            btnColor.Size = new Size(88, 51);
            btnColor.TabIndex = 0;
            btnColor.Text = "COLORS";
            btnColor.TextImageRelation = TextImageRelation.ImageAboveText;
            btnColor.UseVisualStyleBackColor = true;
            btnColor.Click += btnColor_Click;
            // 
            // btnShoes
            // 
            btnShoes.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnShoes.Location = new Point(172, 127);
            btnShoes.Name = "btnShoes";
            btnShoes.Size = new Size(88, 51);
            btnShoes.TabIndex = 0;
            btnShoes.Text = "SHOES";
            btnShoes.TextImageRelation = TextImageRelation.ImageAboveText;
            btnShoes.UseVisualStyleBackColor = true;
            btnShoes.Click += btnShoe_Click;
            // 
            // btnTalles
            // 
            btnTalles.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnTalles.Location = new Point(287, 127);
            btnTalles.Name = "btnTalles";
            btnTalles.Size = new Size(88, 51);
            btnTalles.TabIndex = 0;
            btnTalles.Text = "SIZES";
            btnTalles.TextImageRelation = TextImageRelation.ImageAboveText;
            btnTalles.UseVisualStyleBackColor = true;
            btnTalles.Click += btnTalles_Click;
            // 
            // FrmPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(495, 271);
            ControlBox = false;
            Controls.Add(btnTalles);
            Controls.Add(btnShoes);
            Controls.Add(btnColor);
            Controls.Add(btnGenre);
            Controls.Add(btnSport);
            Controls.Add(btnBrand);
            Controls.Add(btnSalir);
            Name = "FrmPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmPrincipal";
            Load += FrmPrincipal_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button btnSalir;
        private Button btnBrand;
        private Button btnSport;
        private Button btnGenre;
        private Button btnColor;
        private Button btnShoes;
        private Button btnTalles;
    }
}