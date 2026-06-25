namespace Vista
{
    partial class Menu_CambiarContrase_a
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu_CambiarContrase_a));
            pictureBox1 = new PictureBox();
            bigTextBox1 = new ReaLTaiizor.Controls.BigTextBox();
            bigTextBox2 = new ReaLTaiizor.Controls.BigTextBox();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(89, -77);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(378, 290);
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // bigTextBox1
            // 
            bigTextBox1.BackColor = Color.Transparent;
            bigTextBox1.Font = new Font("Tahoma", 11F);
            bigTextBox1.ForeColor = Color.DimGray;
            bigTextBox1.Image = null;
            bigTextBox1.Location = new Point(144, 252);
            bigTextBox1.MaxLength = 32767;
            bigTextBox1.Multiline = false;
            bigTextBox1.Name = "bigTextBox1";
            bigTextBox1.PlaceholderText = "Contraseña actual";
            bigTextBox1.ReadOnly = false;
            bigTextBox1.Size = new Size(234, 41);
            bigTextBox1.TabIndex = 13;
            bigTextBox1.TextAlignment = HorizontalAlignment.Left;
            bigTextBox1.UseSystemPasswordChar = false;
            // 
            // bigTextBox2
            // 
            bigTextBox2.BackColor = Color.Transparent;
            bigTextBox2.Font = new Font("Tahoma", 11F);
            bigTextBox2.ForeColor = Color.DimGray;
            bigTextBox2.Image = null;
            bigTextBox2.Location = new Point(144, 310);
            bigTextBox2.MaxLength = 32767;
            bigTextBox2.Multiline = false;
            bigTextBox2.Name = "bigTextBox2";
            bigTextBox2.PlaceholderText = "Contraseña nueva";
            bigTextBox2.ReadOnly = false;
            bigTextBox2.Size = new Size(234, 41);
            bigTextBox2.TabIndex = 14;
            bigTextBox2.TextAlignment = HorizontalAlignment.Left;
            bigTextBox2.UseSystemPasswordChar = false;
            // 
            // button1
            // 
            button1.BackColor = Color.Black;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI Black", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.Transparent;
            button1.Location = new Point(189, 400);
            button1.Name = "button1";
            button1.Size = new Size(136, 51);
            button1.TabIndex = 15;
            button1.Text = "ENVIAR";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // Menu_CambiarContrase_a
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(571, 499);
            Controls.Add(button1);
            Controls.Add(bigTextBox2);
            Controls.Add(bigTextBox1);
            Controls.Add(pictureBox1);
            Name = "Menu_CambiarContrase_a";
            Load += Menu_CambiarContrase_a_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private ReaLTaiizor.Controls.BigTextBox bigTextBox1;
        private ReaLTaiizor.Controls.BigTextBox bigTextBox2;
        private Button button1;
    }
}