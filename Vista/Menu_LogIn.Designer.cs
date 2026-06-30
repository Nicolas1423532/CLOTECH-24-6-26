namespace Vista
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            pictureBox1 = new PictureBox();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            button1 = new Button();
            aloneComboBox1 = new ReaLTaiizor.Controls.AloneComboBox();
            linkLabel1 = new LinkLabel();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(232, -80);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(378, 290);
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 16F);
            textBox1.Location = new Point(250, 256);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Correo electrónico";
            textBox1.Size = new Size(327, 36);
            textBox1.TabIndex = 4;
            // 
            // textBox2
            // 
            textBox2.Font = new Font("Segoe UI", 16F);
            textBox2.Location = new Point(250, 316);
            textBox2.Name = "textBox2";
            textBox2.PlaceholderText = "Contraseña";
            textBox2.Size = new Size(327, 36);
            textBox2.TabIndex = 5;
            // 
            // button1
            // 
            button1.BackColor = Color.Black;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI Black", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.Transparent;
            button1.Location = new Point(342, 415);
            button1.Name = "button1";
            button1.Size = new Size(136, 51);
            button1.TabIndex = 7;
            button1.Text = "INICIAR SESIÓN";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // aloneComboBox1
            // 
            aloneComboBox1.DrawMode = DrawMode.OwnerDrawFixed;
            aloneComboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            aloneComboBox1.EnabledCalc = true;
            aloneComboBox1.FormattingEnabled = true;
            aloneComboBox1.ItemHeight = 20;
            aloneComboBox1.Items.AddRange(new object[] { "Español", "English" });
            aloneComboBox1.Location = new Point(694, 12);
            aloneComboBox1.Name = "aloneComboBox1";
            aloneComboBox1.Size = new Size(146, 26);
            aloneComboBox1.TabIndex = 9;
            aloneComboBox1.Visible = false;
            aloneComboBox1.SelectedIndexChanged += aloneComboBox1_SelectedIndexChanged;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.LinkColor = Color.FromArgb(0, 149, 221);
            linkLabel1.Location = new Point(250, 370);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(115, 15);
            linkLabel1.TabIndex = 10;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Cambiar Contraseña";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked_1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            ClientSize = new Size(886, 515);
            Controls.Add(linkLabel1);
            Controls.Add(aloneComboBox1);
            Controls.Add(button1);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(pictureBox1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private TextBox textBox1;
        private TextBox textBox2;
        private Button button1;
        private ReaLTaiizor.Controls.AloneComboBox aloneComboBox1;
        private LinkLabel linkLabel1;
    }
}
