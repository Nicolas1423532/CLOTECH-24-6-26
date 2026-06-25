using BE;
using BLL;
using SERVICIO;

namespace Vista
{
    public partial class Form1 : Form
    {
        byte intentos = 0;
        BLL_Usuario bllUsuario;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (bllUsuario.Log_In(textBox1.Text, textBox2.Text))
                {
                    MessageBox.Show("Inicio de sesión exitoso");
                    Menu_Principal menuP = new Menu_Principal();
                    menuP.Show();
                    this.Hide();
                }
                else
                {
                    textBox2.Text = null;
                    textBox2.PlaceholderText = "Incorrecto!";
                    intentos++;
                    bool limite = bllUsuario.LimiteIntentosLogIn(intentos);
                    DesactivarControles(limite);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void DesactivarControles(bool resultado)
        {
            if (resultado)
            {
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                button1.Enabled = false;
                throw new Exception("Ha alcanzado el numero maximo de intentos. Su cuenta está temporalmente bloqueada");
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            bllUsuario = new BLL_Usuario();
        }

        private void foxLinkLabel1_Click(object sender, EventArgs e)
        {
            try
            {
                string correoTextbox1 = textBox1.Text;
                if (string.IsNullOrEmpty(correoTextbox1)) { throw new Exception("El correo esta vacío, por favor ingrese su correo para cambiar contra"); }
                Menu_CambiarContrase_a menuCambiarContra = new Menu_CambiarContrase_a(correoTextbox1);
                menuCambiarContra.ShowDialog();
                textBox2.Text = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
