using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BE;
using BLL;
namespace Vista
{
    public partial class Menu_CambiarContrase_a : Form
    {
        BLL_Usuario usuarioBll;
        string _email;
        public Menu_CambiarContrase_a(string email)
        {
            _email = email;
            InitializeComponent();
        }

        private void Menu_CambiarContrase_a_Load(object sender, EventArgs e)
        {
            usuarioBll = new BLL_Usuario();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string actual = bigTextBox1.Text;
                string nueva = bigTextBox2.Text;
                usuarioBll.CambiarContraseña(_email,actual, nueva);

                MessageBox.Show("La contraseña se ha modificado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
