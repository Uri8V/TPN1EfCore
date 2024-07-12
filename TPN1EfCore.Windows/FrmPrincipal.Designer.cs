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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPrincipal));
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
            btnSalir.Anchor = AnchorStyles.None;
            btnSalir.Image = (Image)resources.GetObject("btnSalir.Image");
            btnSalir.Location = new Point(275, 187);
            btnSalir.MaximumSize = new Size(63, 56);
            btnSalir.MinimumSize = new Size(63, 56);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(63, 56);
            btnSalir.TabIndex = 0;
            btnSalir.Text = "SALIR";
            btnSalir.TextImageRelation = TextImageRelation.ImageAboveText;
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // btnBrand
            // 
            btnBrand.Anchor = AnchorStyles.None;
            btnBrand.Image = (Image)resources.GetObject("btnBrand.Image");
            btnBrand.Location = new Point(11, 18);
            btnBrand.MaximumSize = new Size(88, 73);
            btnBrand.MinimumSize = new Size(88, 73);
            btnBrand.Name = "btnBrand";
            btnBrand.Size = new Size(88, 73);
            btnBrand.TabIndex = 0;
            btnBrand.Text = "BRANDS";
            btnBrand.TextImageRelation = TextImageRelation.ImageAboveText;
            btnBrand.UseVisualStyleBackColor = true;
            btnBrand.Click += btnBrand_Click;
            // 
            // btnSport
            // 
            btnSport.Anchor = AnchorStyles.None;
            btnSport.Image = (Image)resources.GetObject("btnSport.Image");
            btnSport.Location = new Point(135, 18);
            btnSport.MaximumSize = new Size(88, 73);
            btnSport.MinimumSize = new Size(88, 73);
            btnSport.Name = "btnSport";
            btnSport.Size = new Size(88, 73);
            btnSport.TabIndex = 0;
            btnSport.Text = "SPORTS";
            btnSport.TextImageRelation = TextImageRelation.ImageAboveText;
            btnSport.UseVisualStyleBackColor = true;
            btnSport.Click += btnSport_Click;
            // 
            // btnGenre
            // 
            btnGenre.Anchor = AnchorStyles.None;
            btnGenre.Image = (Image)resources.GetObject("btnGenre.Image");
            btnGenre.Location = new Point(250, 18);
            btnGenre.MaximumSize = new Size(88, 73);
            btnGenre.MinimumSize = new Size(88, 73);
            btnGenre.Name = "btnGenre";
            btnGenre.Size = new Size(88, 73);
            btnGenre.TabIndex = 0;
            btnGenre.Text = "GENRES";
            btnGenre.TextImageRelation = TextImageRelation.ImageAboveText;
            btnGenre.UseVisualStyleBackColor = true;
            btnGenre.Click += btnGenre_Click;
            // 
            // btnColor
            // 
            btnColor.Anchor = AnchorStyles.None;
            btnColor.Image = (Image)resources.GetObject("btnColor.Image");
            btnColor.Location = new Point(11, 97);
            btnColor.MaximumSize = new Size(88, 73);
            btnColor.MinimumSize = new Size(88, 73);
            btnColor.Name = "btnColor";
            btnColor.Size = new Size(88, 73);
            btnColor.TabIndex = 0;
            btnColor.Text = "COLORS";
            btnColor.TextImageRelation = TextImageRelation.ImageAboveText;
            btnColor.UseVisualStyleBackColor = true;
            btnColor.Click += btnColor_Click;
            // 
            // btnShoes
            // 
            btnShoes.Anchor = AnchorStyles.None;
            btnShoes.Image = (Image)resources.GetObject("btnShoes.Image");
            btnShoes.Location = new Point(135, 97);
            btnShoes.MaximumSize = new Size(88, 73);
            btnShoes.MinimumSize = new Size(88, 73);
            btnShoes.Name = "btnShoes";
            btnShoes.Size = new Size(88, 73);
            btnShoes.TabIndex = 0;
            btnShoes.Text = "SHOES";
            btnShoes.TextImageRelation = TextImageRelation.ImageAboveText;
            btnShoes.UseVisualStyleBackColor = true;
            btnShoes.Click += btnShoe_Click;
            // 
            // btnTalles
            // 
            btnTalles.Anchor = AnchorStyles.None;
            btnTalles.Image = (Image)resources.GetObject("btnTalles.Image");
            btnTalles.Location = new Point(250, 97);
            btnTalles.MaximumSize = new Size(88, 73);
            btnTalles.MinimumSize = new Size(88, 73);
            btnTalles.Name = "btnTalles";
            btnTalles.Size = new Size(88, 73);
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
            ClientSize = new Size(350, 249);
            ControlBox = false;
            Controls.Add(btnTalles);
            Controls.Add(btnShoes);
            Controls.Add(btnColor);
            Controls.Add(btnGenre);
            Controls.Add(btnSport);
            Controls.Add(btnBrand);
            Controls.Add(btnSalir);
            MaximumSize = new Size(366, 288);
            MinimumSize = new Size(366, 288);
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