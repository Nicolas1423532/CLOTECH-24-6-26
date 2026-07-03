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
using SERVICIO;
namespace Vista
{
    public partial class Menu_CambiarContrase_a : Form, IObservadorIdioma
    {
        BLL_Usuario usuarioBll;
        SERVICIO_Idioma servicioIdioma = SERVICIO_Idioma.ObtenerInstancia();
        BLL_Idioma bllIdioma;
        string _email;
        public Menu_CambiarContrase_a(string email)
        {
            _email = email;
            InitializeComponent();
        }

        private void Menu_CambiarContrase_a_Load(object sender, EventArgs e)
        {
            usuarioBll = new BLL_Usuario();
            bllIdioma = new BLL_Idioma();
            servicioIdioma.CargarDesdeJson();
            servicioIdioma.Suscribir(this);
            ActualizarIdioma();
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

        public void ActualizarIdioma()
        {
            bigTextBox1.PlaceholderText = servicioIdioma.ObtenerTraduccion("lbl_contra_actual");
            bigTextBox2.PlaceholderText = servicioIdioma.ObtenerTraduccion("lbl_nueva_contra");
            button1.Text = servicioIdioma.ObtenerTraduccion("btn_confirmar");
        }
    }
}
