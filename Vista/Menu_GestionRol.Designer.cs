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
            TreeNode treeNode1 = new TreeNode("Patente");
            TreeNode treeNode2 = new TreeNode("Familia", new TreeNode[] { treeNode1 });
            TreeNode treeNode3 = new TreeNode("Rol", new TreeNode[] { treeNode2 });
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            foreverTreeView1 = new ReaLTaiizor.Controls.ForeverTreeView();
            poisonDataGridView1 = new ReaLTaiizor.Controls.PoisonDataGridView();
            skyButton2 = new ReaLTaiizor.Controls.SkyButton();
            skyButton1 = new ReaLTaiizor.Controls.SkyButton();
            skyButton3 = new ReaLTaiizor.Controls.SkyButton();
            skyButton4 = new ReaLTaiizor.Controls.SkyButton();
            skyButton5 = new ReaLTaiizor.Controls.SkyButton();
            skyButton6 = new ReaLTaiizor.Controls.SkyButton();
            skyButton7 = new ReaLTaiizor.Controls.SkyButton();
            skyButton8 = new ReaLTaiizor.Controls.SkyButton();
            skyButton9 = new ReaLTaiizor.Controls.SkyButton();
            ((System.ComponentModel.ISupportInitialize)poisonDataGridView1).BeginInit();
            SuspendLayout();
            // 
            // foreverTreeView1
            // 
            foreverTreeView1.BackColor = Color.FromArgb(45, 47, 49);
            foreverTreeView1.Font = new Font("Segoe UI", 8F);
            foreverTreeView1.ForeColor = Color.White;
            foreverTreeView1.LineColor = Color.FromArgb(25, 27, 29);
            foreverTreeView1.Location = new Point(39, 104);
            foreverTreeView1.Name = "foreverTreeView1";
            treeNode1.Name = "Nodo2";
            treeNode1.Text = "Patente";
            treeNode2.Name = "Nodo1";
            treeNode2.Text = "Familia";
            treeNode3.Name = "Nodo0";
            treeNode3.Text = "Rol";
            foreverTreeView1.Nodes.AddRange(new TreeNode[] { treeNode3 });
            foreverTreeView1.Size = new Size(149, 299);
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
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(0, 174, 219);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(255, 255, 255);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(0, 198, 247);
            dataGridViewCellStyle1.SelectionForeColor = Color.FromArgb(17, 17, 17);
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            poisonDataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            poisonDataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(255, 255, 255);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(136, 136, 136);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(0, 198, 247);
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(17, 17, 17);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            poisonDataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            poisonDataGridView1.EnableHeadersVisualStyles = false;
            poisonDataGridView1.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Pixel);
            poisonDataGridView1.GridColor = Color.FromArgb(255, 255, 255);
            poisonDataGridView1.Location = new Point(214, 104);
            poisonDataGridView1.Name = "poisonDataGridView1";
            poisonDataGridView1.ReadOnly = true;
            poisonDataGridView1.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(0, 174, 219);
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(255, 255, 255);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(0, 198, 247);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(17, 17, 17);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            poisonDataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            poisonDataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            poisonDataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            poisonDataGridView1.Size = new Size(473, 299);
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
            skyButton2.Location = new Point(735, 181);
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
            skyButton1.Location = new Point(735, 104);
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
            skyButton3.Location = new Point(735, 263);
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
            // 
            // skyButton4
            // 
            skyButton4.BackColor = Color.WhiteSmoke;
            skyButton4.DownBGColorA = Color.FromArgb(70, 153, 205);
            skyButton4.DownBGColorB = Color.FromArgb(53, 124, 170);
            skyButton4.DownBorderColorA = Color.FromArgb(88, 168, 221);
            skyButton4.DownBorderColorB = Color.FromArgb(76, 149, 194);
            skyButton4.DownBorderColorC = Color.FromArgb(38, 93, 131);
            skyButton4.DownBorderColorD = Color.FromArgb(200, 25, 73, 109);
            skyButton4.DownForeColor = Color.White;
            skyButton4.DownShadowForeColor = Color.FromArgb(200, 0, 0, 0);
            skyButton4.Font = new Font("Segoe UI Black", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            skyButton4.ForeColor = Color.FromArgb(27, 94, 137);
            skyButton4.HoverBGColorA = Color.FromArgb(70, 153, 205);
            skyButton4.HoverBGColorB = Color.FromArgb(53, 124, 170);
            skyButton4.HoverBorderColorA = Color.FromArgb(88, 168, 221);
            skyButton4.HoverBorderColorB = Color.FromArgb(76, 149, 194);
            skyButton4.HoverBorderColorC = Color.FromArgb(38, 93, 131);
            skyButton4.HoverBorderColorD = Color.FromArgb(200, 25, 73, 109);
            skyButton4.HoverForeColor = Color.White;
            skyButton4.HoverShadowForeColor = Color.FromArgb(200, 0, 0, 0);
            skyButton4.Location = new Point(961, 104);
            skyButton4.Name = "skyButton4";
            skyButton4.NormalBGColorA = Color.FromArgb(245, 245, 245);
            skyButton4.NormalBGColorB = Color.FromArgb(230, 230, 230);
            skyButton4.NormalBorderColorA = Color.FromArgb(252, 252, 252);
            skyButton4.NormalBorderColorB = Color.FromArgb(249, 249, 249);
            skyButton4.NormalBorderColorC = Color.WhiteSmoke;
            skyButton4.NormalBorderColorD = Color.Transparent;
            skyButton4.NormalForeColor = Color.FromArgb(27, 94, 137);
            skyButton4.NormalShadowForeColor = Color.FromArgb(200, 255, 255, 255);
            skyButton4.Size = new Size(198, 55);
            skyButton4.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            skyButton4.TabIndex = 11;
            skyButton4.Tag = "MODULO_ADMIN";
            skyButton4.Text = "AGREGAR FAMILIA";
            // 
            // skyButton5
            // 
            skyButton5.BackColor = Color.WhiteSmoke;
            skyButton5.DownBGColorA = Color.FromArgb(70, 153, 205);
            skyButton5.DownBGColorB = Color.FromArgb(53, 124, 170);
            skyButton5.DownBorderColorA = Color.FromArgb(88, 168, 221);
            skyButton5.DownBorderColorB = Color.FromArgb(76, 149, 194);
            skyButton5.DownBorderColorC = Color.FromArgb(38, 93, 131);
            skyButton5.DownBorderColorD = Color.FromArgb(200, 25, 73, 109);
            skyButton5.DownForeColor = Color.White;
            skyButton5.DownShadowForeColor = Color.FromArgb(200, 0, 0, 0);
            skyButton5.Font = new Font("Segoe UI Black", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            skyButton5.ForeColor = Color.FromArgb(27, 94, 137);
            skyButton5.HoverBGColorA = Color.FromArgb(70, 153, 205);
            skyButton5.HoverBGColorB = Color.FromArgb(53, 124, 170);
            skyButton5.HoverBorderColorA = Color.FromArgb(88, 168, 221);
            skyButton5.HoverBorderColorB = Color.FromArgb(76, 149, 194);
            skyButton5.HoverBorderColorC = Color.FromArgb(38, 93, 131);
            skyButton5.HoverBorderColorD = Color.FromArgb(200, 25, 73, 109);
            skyButton5.HoverForeColor = Color.White;
            skyButton5.HoverShadowForeColor = Color.FromArgb(200, 0, 0, 0);
            skyButton5.Location = new Point(961, 263);
            skyButton5.Name = "skyButton5";
            skyButton5.NormalBGColorA = Color.FromArgb(245, 245, 245);
            skyButton5.NormalBGColorB = Color.FromArgb(230, 230, 230);
            skyButton5.NormalBorderColorA = Color.FromArgb(252, 252, 252);
            skyButton5.NormalBorderColorB = Color.FromArgb(249, 249, 249);
            skyButton5.NormalBorderColorC = Color.WhiteSmoke;
            skyButton5.NormalBorderColorD = Color.Transparent;
            skyButton5.NormalForeColor = Color.FromArgb(27, 94, 137);
            skyButton5.NormalShadowForeColor = Color.FromArgb(200, 255, 255, 255);
            skyButton5.Size = new Size(198, 55);
            skyButton5.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            skyButton5.TabIndex = 10;
            skyButton5.Tag = "MODULO_ADMIN";
            skyButton5.Text = "ELIMINAR FAMILIA";
            // 
            // skyButton6
            // 
            skyButton6.BackColor = Color.WhiteSmoke;
            skyButton6.DownBGColorA = Color.FromArgb(70, 153, 205);
            skyButton6.DownBGColorB = Color.FromArgb(53, 124, 170);
            skyButton6.DownBorderColorA = Color.FromArgb(88, 168, 221);
            skyButton6.DownBorderColorB = Color.FromArgb(76, 149, 194);
            skyButton6.DownBorderColorC = Color.FromArgb(38, 93, 131);
            skyButton6.DownBorderColorD = Color.FromArgb(200, 25, 73, 109);
            skyButton6.DownForeColor = Color.White;
            skyButton6.DownShadowForeColor = Color.FromArgb(200, 0, 0, 0);
            skyButton6.Font = new Font("Segoe UI Black", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            skyButton6.ForeColor = Color.FromArgb(27, 94, 137);
            skyButton6.HoverBGColorA = Color.FromArgb(70, 153, 205);
            skyButton6.HoverBGColorB = Color.FromArgb(53, 124, 170);
            skyButton6.HoverBorderColorA = Color.FromArgb(88, 168, 221);
            skyButton6.HoverBorderColorB = Color.FromArgb(76, 149, 194);
            skyButton6.HoverBorderColorC = Color.FromArgb(38, 93, 131);
            skyButton6.HoverBorderColorD = Color.FromArgb(200, 25, 73, 109);
            skyButton6.HoverForeColor = Color.White;
            skyButton6.HoverShadowForeColor = Color.FromArgb(200, 0, 0, 0);
            skyButton6.Location = new Point(961, 181);
            skyButton6.Name = "skyButton6";
            skyButton6.NormalBGColorA = Color.FromArgb(245, 245, 245);
            skyButton6.NormalBGColorB = Color.FromArgb(230, 230, 230);
            skyButton6.NormalBorderColorA = Color.FromArgb(252, 252, 252);
            skyButton6.NormalBorderColorB = Color.FromArgb(249, 249, 249);
            skyButton6.NormalBorderColorC = Color.WhiteSmoke;
            skyButton6.NormalBorderColorD = Color.Transparent;
            skyButton6.NormalForeColor = Color.FromArgb(27, 94, 137);
            skyButton6.NormalShadowForeColor = Color.FromArgb(200, 255, 255, 255);
            skyButton6.Size = new Size(198, 55);
            skyButton6.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            skyButton6.TabIndex = 9;
            skyButton6.Tag = "MODULO_ADMIN";
            skyButton6.Text = "MODIFICAR FAMILIA";
            // 
            // skyButton7
            // 
            skyButton7.BackColor = Color.WhiteSmoke;
            skyButton7.DownBGColorA = Color.FromArgb(70, 153, 205);
            skyButton7.DownBGColorB = Color.FromArgb(53, 124, 170);
            skyButton7.DownBorderColorA = Color.FromArgb(88, 168, 221);
            skyButton7.DownBorderColorB = Color.FromArgb(76, 149, 194);
            skyButton7.DownBorderColorC = Color.FromArgb(38, 93, 131);
            skyButton7.DownBorderColorD = Color.FromArgb(200, 25, 73, 109);
            skyButton7.DownForeColor = Color.White;
            skyButton7.DownShadowForeColor = Color.FromArgb(200, 0, 0, 0);
            skyButton7.Font = new Font("Segoe UI Black", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            skyButton7.ForeColor = Color.FromArgb(27, 94, 137);
            skyButton7.HoverBGColorA = Color.FromArgb(70, 153, 205);
            skyButton7.HoverBGColorB = Color.FromArgb(53, 124, 170);
            skyButton7.HoverBorderColorA = Color.FromArgb(88, 168, 221);
            skyButton7.HoverBorderColorB = Color.FromArgb(76, 149, 194);
            skyButton7.HoverBorderColorC = Color.FromArgb(38, 93, 131);
            skyButton7.HoverBorderColorD = Color.FromArgb(200, 25, 73, 109);
            skyButton7.HoverForeColor = Color.White;
            skyButton7.HoverShadowForeColor = Color.FromArgb(200, 0, 0, 0);
            skyButton7.Location = new Point(851, 358);
            skyButton7.Name = "skyButton7";
            skyButton7.NormalBGColorA = Color.FromArgb(245, 245, 245);
            skyButton7.NormalBGColorB = Color.FromArgb(230, 230, 230);
            skyButton7.NormalBorderColorA = Color.FromArgb(252, 252, 252);
            skyButton7.NormalBorderColorB = Color.FromArgb(249, 249, 249);
            skyButton7.NormalBorderColorC = Color.WhiteSmoke;
            skyButton7.NormalBorderColorD = Color.Transparent;
            skyButton7.NormalForeColor = Color.FromArgb(27, 94, 137);
            skyButton7.NormalShadowForeColor = Color.FromArgb(200, 255, 255, 255);
            skyButton7.Size = new Size(198, 55);
            skyButton7.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            skyButton7.TabIndex = 14;
            skyButton7.Tag = "MODULO_ADMIN";
            skyButton7.Text = "AGREGAR PATENTE";
            // 
            // skyButton8
            // 
            skyButton8.BackColor = Color.WhiteSmoke;
            skyButton8.DownBGColorA = Color.FromArgb(70, 153, 205);
            skyButton8.DownBGColorB = Color.FromArgb(53, 124, 170);
            skyButton8.DownBorderColorA = Color.FromArgb(88, 168, 221);
            skyButton8.DownBorderColorB = Color.FromArgb(76, 149, 194);
            skyButton8.DownBorderColorC = Color.FromArgb(38, 93, 131);
            skyButton8.DownBorderColorD = Color.FromArgb(200, 25, 73, 109);
            skyButton8.DownForeColor = Color.White;
            skyButton8.DownShadowForeColor = Color.FromArgb(200, 0, 0, 0);
            skyButton8.Font = new Font("Segoe UI Black", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            skyButton8.ForeColor = Color.FromArgb(27, 94, 137);
            skyButton8.HoverBGColorA = Color.FromArgb(70, 153, 205);
            skyButton8.HoverBGColorB = Color.FromArgb(53, 124, 170);
            skyButton8.HoverBorderColorA = Color.FromArgb(88, 168, 221);
            skyButton8.HoverBorderColorB = Color.FromArgb(76, 149, 194);
            skyButton8.HoverBorderColorC = Color.FromArgb(38, 93, 131);
            skyButton8.HoverBorderColorD = Color.FromArgb(200, 25, 73, 109);
            skyButton8.HoverForeColor = Color.White;
            skyButton8.HoverShadowForeColor = Color.FromArgb(200, 0, 0, 0);
            skyButton8.Location = new Point(851, 443);
            skyButton8.Name = "skyButton8";
            skyButton8.NormalBGColorA = Color.FromArgb(245, 245, 245);
            skyButton8.NormalBGColorB = Color.FromArgb(230, 230, 230);
            skyButton8.NormalBorderColorA = Color.FromArgb(252, 252, 252);
            skyButton8.NormalBorderColorB = Color.FromArgb(249, 249, 249);
            skyButton8.NormalBorderColorC = Color.WhiteSmoke;
            skyButton8.NormalBorderColorD = Color.Transparent;
            skyButton8.NormalForeColor = Color.FromArgb(27, 94, 137);
            skyButton8.NormalShadowForeColor = Color.FromArgb(200, 255, 255, 255);
            skyButton8.Size = new Size(198, 55);
            skyButton8.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            skyButton8.TabIndex = 13;
            skyButton8.Tag = "MODULO_ADMIN";
            skyButton8.Text = "MODIFICAR PATENTE";
            // 
            // skyButton9
            // 
            skyButton9.BackColor = Color.WhiteSmoke;
            skyButton9.DownBGColorA = Color.FromArgb(70, 153, 205);
            skyButton9.DownBGColorB = Color.FromArgb(53, 124, 170);
            skyButton9.DownBorderColorA = Color.FromArgb(88, 168, 221);
            skyButton9.DownBorderColorB = Color.FromArgb(76, 149, 194);
            skyButton9.DownBorderColorC = Color.FromArgb(38, 93, 131);
            skyButton9.DownBorderColorD = Color.FromArgb(200, 25, 73, 109);
            skyButton9.DownForeColor = Color.White;
            skyButton9.DownShadowForeColor = Color.FromArgb(200, 0, 0, 0);
            skyButton9.Font = new Font("Segoe UI Black", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            skyButton9.ForeColor = Color.FromArgb(27, 94, 137);
            skyButton9.HoverBGColorA = Color.FromArgb(70, 153, 205);
            skyButton9.HoverBGColorB = Color.FromArgb(53, 124, 170);
            skyButton9.HoverBorderColorA = Color.FromArgb(88, 168, 221);
            skyButton9.HoverBorderColorB = Color.FromArgb(76, 149, 194);
            skyButton9.HoverBorderColorC = Color.FromArgb(38, 93, 131);
            skyButton9.HoverBorderColorD = Color.FromArgb(200, 25, 73, 109);
            skyButton9.HoverForeColor = Color.White;
            skyButton9.HoverShadowForeColor = Color.FromArgb(200, 0, 0, 0);
            skyButton9.Location = new Point(851, 524);
            skyButton9.Name = "skyButton9";
            skyButton9.NormalBGColorA = Color.FromArgb(245, 245, 245);
            skyButton9.NormalBGColorB = Color.FromArgb(230, 230, 230);
            skyButton9.NormalBorderColorA = Color.FromArgb(252, 252, 252);
            skyButton9.NormalBorderColorB = Color.FromArgb(249, 249, 249);
            skyButton9.NormalBorderColorC = Color.WhiteSmoke;
            skyButton9.NormalBorderColorD = Color.Transparent;
            skyButton9.NormalForeColor = Color.FromArgb(27, 94, 137);
            skyButton9.NormalShadowForeColor = Color.FromArgb(200, 255, 255, 255);
            skyButton9.Size = new Size(198, 55);
            skyButton9.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            skyButton9.TabIndex = 12;
            skyButton9.Tag = "MODULO_ADMIN";
            skyButton9.Text = "ELIMINAR PATENTE";
            // 
            // Menu_GestionRol
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.CadetBlue;
            ClientSize = new Size(1185, 635);
            Controls.Add(skyButton7);
            Controls.Add(skyButton8);
            Controls.Add(skyButton9);
            Controls.Add(skyButton4);
            Controls.Add(skyButton5);
            Controls.Add(skyButton6);
            Controls.Add(skyButton3);
            Controls.Add(skyButton2);
            Controls.Add(skyButton1);
            Controls.Add(poisonDataGridView1);
            Controls.Add(foreverTreeView1);
            Name = "Menu_GestionRol";
            Text = "Menu_GestionRol";
            Load += Menu_GestionRol_Load;
            ((System.ComponentModel.ISupportInitialize)poisonDataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private ReaLTaiizor.Controls.ForeverTreeView foreverTreeView1;
        private ReaLTaiizor.Controls.PoisonDataGridView poisonDataGridView1;
        private ReaLTaiizor.Controls.SkyButton skyButton2;
        private ReaLTaiizor.Controls.SkyButton skyButton1;
        private ReaLTaiizor.Controls.SkyButton skyButton3;
        private ReaLTaiizor.Controls.SkyButton skyButton4;
        private ReaLTaiizor.Controls.SkyButton skyButton5;
        private ReaLTaiizor.Controls.SkyButton skyButton6;
        private ReaLTaiizor.Controls.SkyButton skyButton7;
        private ReaLTaiizor.Controls.SkyButton skyButton8;
        private ReaLTaiizor.Controls.SkyButton skyButton9;
    }
}