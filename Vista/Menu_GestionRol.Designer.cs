namespace Vista
{
    partial class Menu_GestionRol
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
            TreeNode treeNode16 = new TreeNode("Patente");
            TreeNode treeNode17 = new TreeNode("Familia", new TreeNode[] { treeNode16 });
            TreeNode treeNode18 = new TreeNode("Rol", new TreeNode[] { treeNode17 });
            DataGridViewCellStyle dataGridViewCellStyle31 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle32 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle33 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle34 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle35 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle36 = new DataGridViewCellStyle();
            foreverTreeView1 = new ReaLTaiizor.Controls.ForeverTreeView();
            poisonDataGridView1 = new ReaLTaiizor.Controls.PoisonDataGridView();
            skyButton2 = new ReaLTaiizor.Controls.SkyButton();
            skyButton1 = new ReaLTaiizor.Controls.SkyButton();
            skyButton3 = new ReaLTaiizor.Controls.SkyButton();
            poisonDataGridView2 = new ReaLTaiizor.Controls.PoisonDataGridView();
            skyButton10 = new ReaLTaiizor.Controls.SkyButton();
            skyButton11 = new ReaLTaiizor.Controls.SkyButton();
            crownLabel1 = new ReaLTaiizor.Controls.CrownLabel();
            crownLabel2 = new ReaLTaiizor.Controls.CrownLabel();
            crownLabel3 = new ReaLTaiizor.Controls.CrownLabel();
            ((System.ComponentModel.ISupportInitialize)poisonDataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)poisonDataGridView2).BeginInit();
            SuspendLayout();
            // 
            // foreverTreeView1
            // 
            foreverTreeView1.BackColor = Color.FromArgb(45, 47, 49);
            foreverTreeView1.Font = new Font("Segoe UI", 8F);
            foreverTreeView1.ForeColor = Color.White;
            foreverTreeView1.LineColor = Color.FromArgb(25, 27, 29);
            foreverTreeView1.Location = new Point(131, 48);
            foreverTreeView1.Name = "foreverTreeView1";
            treeNode16.Name = "Nodo2";
            treeNode16.Text = "Patente";
            treeNode17.Name = "Nodo1";
            treeNode17.Text = "Familia";
            treeNode18.Name = "Nodo0";
            treeNode18.Text = "Rol";
            foreverTreeView1.Nodes.AddRange(new TreeNode[] { treeNode18 });
            foreverTreeView1.Size = new Size(210, 214);
            foreverTreeView1.TabIndex = 2;
            // 
            // poisonDataGridView1
            // 
            poisonDataGridView1.AllowUserToAddRows = false;
            poisonDataGridView1.AllowUserToDeleteRows = false;
            poisonDataGridView1.AllowUserToResizeRows = false;
            poisonDataGridView1.BackgroundColor = Color.FromArgb(255, 255, 255);
            poisonDataGridView1.BorderStyle = BorderStyle.None;
            poisonDataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.None;
            poisonDataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle31.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle31.BackColor = Color.FromArgb(0, 174, 219);
            dataGridViewCellStyle31.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Pixel);
            dataGridViewCellStyle31.ForeColor = Color.FromArgb(255, 255, 255);
            dataGridViewCellStyle31.SelectionBackColor = Color.FromArgb(0, 198, 247);
            dataGridViewCellStyle31.SelectionForeColor = Color.FromArgb(17, 17, 17);
            dataGridViewCellStyle31.WrapMode = DataGridViewTriState.True;
            poisonDataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle31;
            poisonDataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle32.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle32.BackColor = Color.FromArgb(255, 255, 255);
            dataGridViewCellStyle32.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Pixel);
            dataGridViewCellStyle32.ForeColor = Color.FromArgb(136, 136, 136);
            dataGridViewCellStyle32.SelectionBackColor = Color.FromArgb(0, 198, 247);
            dataGridViewCellStyle32.SelectionForeColor = Color.FromArgb(17, 17, 17);
            dataGridViewCellStyle32.WrapMode = DataGridViewTriState.False;
            poisonDataGridView1.DefaultCellStyle = dataGridViewCellStyle32;
            poisonDataGridView1.EnableHeadersVisualStyles = false;
            poisonDataGridView1.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Pixel);
            poisonDataGridView1.GridColor = Color.FromArgb(255, 255, 255);
            poisonDataGridView1.Location = new Point(368, 48);
            poisonDataGridView1.Name = "poisonDataGridView1";
            poisonDataGridView1.ReadOnly = true;
            poisonDataGridView1.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle33.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle33.BackColor = Color.FromArgb(0, 174, 219);
            dataGridViewCellStyle33.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Pixel);
            dataGridViewCellStyle33.ForeColor = Color.FromArgb(255, 255, 255);
            dataGridViewCellStyle33.SelectionBackColor = Color.FromArgb(0, 198, 247);
            dataGridViewCellStyle33.SelectionForeColor = Color.FromArgb(17, 17, 17);
            dataGridViewCellStyle33.WrapMode = DataGridViewTriState.True;
            poisonDataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle33;
            poisonDataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            poisonDataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            poisonDataGridView1.Size = new Size(476, 214);
            poisonDataGridView1.TabIndex = 3;
            poisonDataGridView1.SelectionChanged += poisonDataGridView1_SelectionChanged;
            // 
            // skyButton2
            // 
            skyButton2.BackColor = Color.WhiteSmoke;
            skyButton2.DownBGColorA = Color.FromArgb(70, 153, 205);
            skyButton2.DownBGColorB = Color.FromArgb(53, 124, 170);
            skyButton2.DownBorderColorA = Color.FromArgb(88, 168, 221);
            skyButton2.DownBorderColorB = Color.FromArgb(76, 149, 194);
            skyButton2.DownBorderColorC = Color.FromArgb(38, 93, 131);
            skyButton2.DownBorderColorD = Color.FromArgb(200, 25, 73, 109);
            skyButton2.DownForeColor = Color.White;
            skyButton2.DownShadowForeColor = Color.FromArgb(200, 0, 0, 0);
            skyButton2.Font = new Font("Segoe UI Black", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            skyButton2.ForeColor = Color.FromArgb(27, 94, 137);
            skyButton2.HoverBGColorA = Color.FromArgb(70, 153, 205);
            skyButton2.HoverBGColorB = Color.FromArgb(53, 124, 170);
            skyButton2.HoverBorderColorA = Color.FromArgb(88, 168, 221);
            skyButton2.HoverBorderColorB = Color.FromArgb(76, 149, 194);
            skyButton2.HoverBorderColorC = Color.FromArgb(38, 93, 131);
            skyButton2.HoverBorderColorD = Color.FromArgb(200, 25, 73, 109);
            skyButton2.HoverForeColor = Color.White;
            skyButton2.HoverShadowForeColor = Color.FromArgb(200, 0, 0, 0);
            skyButton2.Location = new Point(473, 382);
            skyButton2.Name = "skyButton2";
            skyButton2.NormalBGColorA = Color.FromArgb(245, 245, 245);
            skyButton2.NormalBGColorB = Color.FromArgb(230, 230, 230);
            skyButton2.NormalBorderColorA = Color.FromArgb(252, 252, 252);
            skyButton2.NormalBorderColorB = Color.FromArgb(249, 249, 249);
            skyButton2.NormalBorderColorC = Color.WhiteSmoke;
            skyButton2.NormalBorderColorD = Color.Transparent;
            skyButton2.NormalForeColor = Color.FromArgb(27, 94, 137);
            skyButton2.NormalShadowForeColor = Color.FromArgb(200, 255, 255, 255);
            skyButton2.Size = new Size(198, 55);
            skyButton2.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            skyButton2.TabIndex = 7;
            skyButton2.Tag = "MODULO_ADMIN";
            skyButton2.Text = "MODIFICAR ROL";
            // 
            // skyButton1
            // 
            skyButton1.BackColor = Color.WhiteSmoke;
            skyButton1.DownBGColorA = Color.FromArgb(70, 153, 205);
            skyButton1.DownBGColorB = Color.FromArgb(53, 124, 170);
            skyButton1.DownBorderColorA = Color.FromArgb(88, 168, 221);
            skyButton1.DownBorderColorB = Color.FromArgb(76, 149, 194);
            skyButton1.DownBorderColorC = Color.FromArgb(38, 93, 131);
            skyButton1.DownBorderColorD = Color.FromArgb(200, 25, 73, 109);
            skyButton1.DownForeColor = Color.White;
            skyButton1.DownShadowForeColor = Color.FromArgb(200, 0, 0, 0);
            skyButton1.Font = new Font("Segoe UI Black", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            skyButton1.ForeColor = Color.FromArgb(27, 94, 137);
            skyButton1.HoverBGColorA = Color.FromArgb(70, 153, 205);
            skyButton1.HoverBGColorB = Color.FromArgb(53, 124, 170);
            skyButton1.HoverBorderColorA = Color.FromArgb(88, 168, 221);
            skyButton1.HoverBorderColorB = Color.FromArgb(76, 149, 194);
            skyButton1.HoverBorderColorC = Color.FromArgb(38, 93, 131);
            skyButton1.HoverBorderColorD = Color.FromArgb(200, 25, 73, 109);
            skyButton1.HoverForeColor = Color.White;
            skyButton1.HoverShadowForeColor = Color.FromArgb(200, 0, 0, 0);
            skyButton1.Location = new Point(473, 297);
            skyButton1.Name = "skyButton1";
            skyButton1.NormalBGColorA = Color.FromArgb(245, 245, 245);
            skyButton1.NormalBGColorB = Color.FromArgb(230, 230, 230);
            skyButton1.NormalBorderColorA = Color.FromArgb(252, 252, 252);
            skyButton1.NormalBorderColorB = Color.FromArgb(249, 249, 249);
            skyButton1.NormalBorderColorC = Color.WhiteSmoke;
            skyButton1.NormalBorderColorD = Color.Transparent;
            skyButton1.NormalForeColor = Color.FromArgb(27, 94, 137);
            skyButton1.NormalShadowForeColor = Color.FromArgb(200, 255, 255, 255);
            skyButton1.Size = new Size(198, 55);
            skyButton1.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            skyButton1.TabIndex = 6;
            skyButton1.Tag = "MODULO_ADMIN";
            skyButton1.Text = "AGREGAR ROL";
            skyButton1.Click += skyButton1_Click;
            // 
            // skyButton3
            // 
            skyButton3.BackColor = Color.WhiteSmoke;
            skyButton3.DownBGColorA = Color.FromArgb(70, 153, 205);
            skyButton3.DownBGColorB = Color.FromArgb(53, 124, 170);
            skyButton3.DownBorderColorA = Color.FromArgb(88, 168, 221);
            skyButton3.DownBorderColorB = Color.FromArgb(76, 149, 194);
            skyButton3.DownBorderColorC = Color.FromArgb(38, 93, 131);
            skyButton3.DownBorderColorD = Color.FromArgb(200, 25, 73, 109);
            skyButton3.DownForeColor = Color.White;
            skyButton3.DownShadowForeColor = Color.FromArgb(200, 0, 0, 0);
            skyButton3.Font = new Font("Segoe UI Black", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            skyButton3.ForeColor = Color.FromArgb(27, 94, 137);
            skyButton3.HoverBGColorA = Color.FromArgb(70, 153, 205);
            skyButton3.HoverBGColorB = Color.FromArgb(53, 124, 170);
            skyButton3.HoverBorderColorA = Color.FromArgb(88, 168, 221);
            skyButton3.HoverBorderColorB = Color.FromArgb(76, 149, 194);
            skyButton3.HoverBorderColorC = Color.FromArgb(38, 93, 131);
            skyButton3.HoverBorderColorD = Color.FromArgb(200, 25, 73, 109);
            skyButton3.HoverForeColor = Color.White;
            skyButton3.HoverShadowForeColor = Color.FromArgb(200, 0, 0, 0);
            skyButton3.Location = new Point(473, 463);
            skyButton3.Name = "skyButton3";
            skyButton3.NormalBGColorA = Color.FromArgb(245, 245, 245);
            skyButton3.NormalBGColorB = Color.FromArgb(230, 230, 230);
            skyButton3.NormalBorderColorA = Color.FromArgb(252, 252, 252);
            skyButton3.NormalBorderColorB = Color.FromArgb(249, 249, 249);
            skyButton3.NormalBorderColorC = Color.WhiteSmoke;
            skyButton3.NormalBorderColorD = Color.Transparent;
            skyButton3.NormalForeColor = Color.FromArgb(27, 94, 137);
            skyButton3.NormalShadowForeColor = Color.FromArgb(200, 255, 255, 255);
            skyButton3.Size = new Size(198, 55);
            skyButton3.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            skyButton3.TabIndex = 8;
            skyButton3.Tag = "MODULO_ADMIN";
            skyButton3.Text = "ELIMINAR ROL";
            skyButton3.Click += skyButton3_Click;
            // 
            // poisonDataGridView2
            // 
            poisonDataGridView2.AllowUserToAddRows = false;
            poisonDataGridView2.AllowUserToDeleteRows = false;
            poisonDataGridView2.AllowUserToResizeRows = false;
            poisonDataGridView2.BackgroundColor = Color.FromArgb(255, 255, 255);
            poisonDataGridView2.BorderStyle = BorderStyle.None;
            poisonDataGridView2.CellBorderStyle = DataGridViewCellBorderStyle.None;
            poisonDataGridView2.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle34.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle34.BackColor = Color.FromArgb(0, 174, 219);
            dataGridViewCellStyle34.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Pixel);
            dataGridViewCellStyle34.ForeColor = Color.FromArgb(255, 255, 255);
            dataGridViewCellStyle34.SelectionBackColor = Color.FromArgb(0, 198, 247);
            dataGridViewCellStyle34.SelectionForeColor = Color.FromArgb(17, 17, 17);
            dataGridViewCellStyle34.WrapMode = DataGridViewTriState.True;
            poisonDataGridView2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle34;
            poisonDataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle35.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle35.BackColor = Color.FromArgb(255, 255, 255);
            dataGridViewCellStyle35.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Pixel);
            dataGridViewCellStyle35.ForeColor = Color.FromArgb(136, 136, 136);
            dataGridViewCellStyle35.SelectionBackColor = Color.FromArgb(0, 198, 247);
            dataGridViewCellStyle35.SelectionForeColor = Color.FromArgb(17, 17, 17);
            dataGridViewCellStyle35.WrapMode = DataGridViewTriState.False;
            poisonDataGridView2.DefaultCellStyle = dataGridViewCellStyle35;
            poisonDataGridView2.EnableHeadersVisualStyles = false;
            poisonDataGridView2.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Pixel);
            poisonDataGridView2.GridColor = Color.FromArgb(255, 255, 255);
            poisonDataGridView2.Location = new Point(131, 297);
            poisonDataGridView2.Name = "poisonDataGridView2";
            poisonDataGridView2.ReadOnly = true;
            poisonDataGridView2.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle36.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle36.BackColor = Color.FromArgb(0, 174, 219);
            dataGridViewCellStyle36.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Pixel);
            dataGridViewCellStyle36.ForeColor = Color.FromArgb(255, 255, 255);
            dataGridViewCellStyle36.SelectionBackColor = Color.FromArgb(0, 198, 247);
            dataGridViewCellStyle36.SelectionForeColor = Color.FromArgb(17, 17, 17);
            dataGridViewCellStyle36.WrapMode = DataGridViewTriState.True;
            poisonDataGridView2.RowHeadersDefaultCellStyle = dataGridViewCellStyle36;
            poisonDataGridView2.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            poisonDataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            poisonDataGridView2.Size = new Size(210, 214);
            poisonDataGridView2.TabIndex = 15;
            // 
            // skyButton10
            // 
            skyButton10.BackColor = Color.WhiteSmoke;
            skyButton10.DownBGColorA = Color.FromArgb(70, 153, 205);
            skyButton10.DownBGColorB = Color.FromArgb(53, 124, 170);
            skyButton10.DownBorderColorA = Color.FromArgb(88, 168, 221);
            skyButton10.DownBorderColorB = Color.FromArgb(76, 149, 194);
            skyButton10.DownBorderColorC = Color.FromArgb(38, 93, 131);
            skyButton10.DownBorderColorD = Color.FromArgb(200, 25, 73, 109);
            skyButton10.DownForeColor = Color.White;
            skyButton10.DownShadowForeColor = Color.FromArgb(200, 0, 0, 0);
            skyButton10.Font = new Font("Segoe UI Black", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            skyButton10.ForeColor = Color.FromArgb(27, 94, 137);
            skyButton10.HoverBGColorA = Color.FromArgb(70, 153, 205);
            skyButton10.HoverBGColorB = Color.FromArgb(53, 124, 170);
            skyButton10.HoverBorderColorA = Color.FromArgb(88, 168, 221);
            skyButton10.HoverBorderColorB = Color.FromArgb(76, 149, 194);
            skyButton10.HoverBorderColorC = Color.FromArgb(38, 93, 131);
            skyButton10.HoverBorderColorD = Color.FromArgb(200, 25, 73, 109);
            skyButton10.HoverForeColor = Color.White;
            skyButton10.HoverShadowForeColor = Color.FromArgb(200, 0, 0, 0);
            skyButton10.Location = new Point(910, 48);
            skyButton10.Name = "skyButton10";
            skyButton10.NormalBGColorA = Color.FromArgb(245, 245, 245);
            skyButton10.NormalBGColorB = Color.FromArgb(230, 230, 230);
            skyButton10.NormalBorderColorA = Color.FromArgb(252, 252, 252);
            skyButton10.NormalBorderColorB = Color.FromArgb(249, 249, 249);
            skyButton10.NormalBorderColorC = Color.WhiteSmoke;
            skyButton10.NormalBorderColorD = Color.Transparent;
            skyButton10.NormalForeColor = Color.FromArgb(27, 94, 137);
            skyButton10.NormalShadowForeColor = Color.FromArgb(200, 255, 255, 255);
            skyButton10.Size = new Size(198, 55);
            skyButton10.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            skyButton10.TabIndex = 16;
            skyButton10.Tag = "MODULO_ADMIN";
            skyButton10.Text = "ASIGNAR ROL";
            skyButton10.Click += skyButton10_Click;
            // 
            // skyButton11
            // 
            skyButton11.BackColor = Color.WhiteSmoke;
            skyButton11.DownBGColorA = Color.FromArgb(70, 153, 205);
            skyButton11.DownBGColorB = Color.FromArgb(53, 124, 170);
            skyButton11.DownBorderColorA = Color.FromArgb(88, 168, 221);
            skyButton11.DownBorderColorB = Color.FromArgb(76, 149, 194);
            skyButton11.DownBorderColorC = Color.FromArgb(38, 93, 131);
            skyButton11.DownBorderColorD = Color.FromArgb(200, 25, 73, 109);
            skyButton11.DownForeColor = Color.White;
            skyButton11.DownShadowForeColor = Color.FromArgb(200, 0, 0, 0);
            skyButton11.Font = new Font("Segoe UI Black", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            skyButton11.ForeColor = Color.FromArgb(27, 94, 137);
            skyButton11.HoverBGColorA = Color.FromArgb(70, 153, 205);
            skyButton11.HoverBGColorB = Color.FromArgb(53, 124, 170);
            skyButton11.HoverBorderColorA = Color.FromArgb(88, 168, 221);
            skyButton11.HoverBorderColorB = Color.FromArgb(76, 149, 194);
            skyButton11.HoverBorderColorC = Color.FromArgb(38, 93, 131);
            skyButton11.HoverBorderColorD = Color.FromArgb(200, 25, 73, 109);
            skyButton11.HoverForeColor = Color.White;
            skyButton11.HoverShadowForeColor = Color.FromArgb(200, 0, 0, 0);
            skyButton11.Location = new Point(910, 133);
            skyButton11.Name = "skyButton11";
            skyButton11.NormalBGColorA = Color.FromArgb(245, 245, 245);
            skyButton11.NormalBGColorB = Color.FromArgb(230, 230, 230);
            skyButton11.NormalBorderColorA = Color.FromArgb(252, 252, 252);
            skyButton11.NormalBorderColorB = Color.FromArgb(249, 249, 249);
            skyButton11.NormalBorderColorC = Color.WhiteSmoke;
            skyButton11.NormalBorderColorD = Color.Transparent;
            skyButton11.NormalForeColor = Color.FromArgb(27, 94, 137);
            skyButton11.NormalShadowForeColor = Color.FromArgb(200, 255, 255, 255);
            skyButton11.Size = new Size(198, 55);
            skyButton11.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            skyButton11.TabIndex = 19;
            skyButton11.Tag = "MODULO_ADMIN";
            skyButton11.Text = "DESASIGNAR ROL";
            skyButton11.Click += skyButton11_Click;
            // 
            // crownLabel1
            // 
            crownLabel1.AutoSize = true;
            crownLabel1.ForeColor = Color.FromArgb(220, 220, 220);
            crownLabel1.Location = new Point(74, 48);
            crownLabel1.Name = "crownLabel1";
            crownLabel1.Size = new Size(24, 15);
            crownLabel1.TabIndex = 20;
            crownLabel1.Text = "Rol";
            // 
            // crownLabel2
            // 
            crownLabel2.AutoSize = true;
            crownLabel2.ForeColor = Color.FromArgb(220, 220, 220);
            crownLabel2.Location = new Point(74, 74);
            crownLabel2.Name = "crownLabel2";
            crownLabel2.Size = new Size(45, 15);
            crownLabel2.TabIndex = 21;
            crownLabel2.Text = "Familia";
            // 
            // crownLabel3
            // 
            crownLabel3.AutoSize = true;
            crownLabel3.ForeColor = Color.FromArgb(220, 220, 220);
            crownLabel3.Location = new Point(74, 100);
            crownLabel3.Name = "crownLabel3";
            crownLabel3.Size = new Size(47, 15);
            crownLabel3.TabIndex = 22;
            crownLabel3.Text = "Patente";
            // 
            // Menu_GestionRol
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.CadetBlue;
            ClientSize = new Size(1160, 678);
            Controls.Add(crownLabel3);
            Controls.Add(crownLabel2);
            Controls.Add(crownLabel1);
            Controls.Add(skyButton11);
            Controls.Add(skyButton10);
            Controls.Add(poisonDataGridView2);
            Controls.Add(skyButton3);
            Controls.Add(skyButton2);
            Controls.Add(skyButton1);
            Controls.Add(poisonDataGridView1);
            Controls.Add(foreverTreeView1);
            Name = "Menu_GestionRol";
            Text = "Menu_GestionRol";
            Load += Menu_GestionRol_Load;
            ((System.ComponentModel.ISupportInitialize)poisonDataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)poisonDataGridView2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ReaLTaiizor.Controls.ForeverTreeView foreverTreeView1;
        private ReaLTaiizor.Controls.PoisonDataGridView poisonDataGridView1;
        private ReaLTaiizor.Controls.SkyButton skyButton2;
        private ReaLTaiizor.Controls.SkyButton skyButton1;
        private ReaLTaiizor.Controls.SkyButton skyButton3;
        private ReaLTaiizor.Controls.PoisonDataGridView poisonDataGridView2;
        private ReaLTaiizor.Controls.SkyButton skyButton10;
        private ReaLTaiizor.Controls.SkyButton skyButton11;
        private ReaLTaiizor.Controls.CrownLabel crownLabel1;
        private ReaLTaiizor.Controls.CrownLabel crownLabel2;
        private ReaLTaiizor.Controls.CrownLabel crownLabel3;
    }
}