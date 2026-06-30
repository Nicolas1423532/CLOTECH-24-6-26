using BE;
using SERVICIO;
using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vista
{
    public partial class Menu_Principal : Form, IObservadorIdioma
    {
        BLL_Usuario usuarioBll;
        BLL_Bitacora bitacoraBll;
        SERVICIO_Idioma servicioIdioma = SERVICIO_Idioma.ObtenerInstancia();
        public Menu_Principal()
        {
            InitializeComponent();
        }

        private void panel1_Click(object sender, EventArgs e)
        {

        }

        private void skyButton1_Click(object sender, EventArgs e)
        {
            Menu_Administracion menuAdmin = new Menu_Administracion();
            menuAdmin.Show();
        }

        private void Menu_Principal_Load(object sender, EventArgs e)
        {
            usuarioBll = new BLL_Usuario();
            bitacoraBll = new BLL_Bitacora();
            servicioIdioma.Suscribir(this);
            CargarComboBoxIdioma();
            ActualizarIdioma();
            BE_Rol rolActual = SERVICIO_SesionUsuario.ObtenerInstancia().FamiliaActual;
            BE_Usuario usuarioActual = SERVICIO_SesionUsuario.ObtenerInstancia().UsuarioActual;
            if (SERVICIO_SesionUsuario.ObtenerInstancia().FamiliaActual != null)
            {
                List<BE_Rol> patentes = (SERVICIO_SesionUsuario.ObtenerInstancia().FamiliaActual as BE_Familia).RetornarComponentesPlanos();
                ValidarPermisosUI(this.Controls, patentes);
            }
            dungeonHeaderLabel1.Text = $"Bienvenido: {usuarioActual.Nombre} {usuarioActual.Apellido}";
            //else
            //{
            //    // Bloqueo total por seguridad si no hay nadie logueado
            //    DeshabilitarTodoElSistema();
            //}
        }
        private void ValidarPermisosUI(Control.ControlCollection controles, List<BE_Rol> patentesUsuario)
        {
            foreach (Control c in controles)
            {
                if (c.Tag != null && !string.IsNullOrEmpty(c.Tag.ToString()))
                {
                    string patenteRequerida = c.Tag.ToString();
                    bool tieneAcceso = patentesUsuario.Any(p => p.Titulo == patenteRequerida);
                    c.Visible = tieneAcceso;
                }

                //RECURSIVIDAD DE GUI: Si el control es un contenedor(un Panel, GroupBox o TabControl),
                if (c.Controls.Count > 0)
                {
                    ValidarPermisosUI(c.Controls, patentesUsuario);
                }
            }
        }
        private void skyButton3_Click(object sender, EventArgs e)
        {
            Menu_Venta menuVenta = new Menu_Venta();
            menuVenta.Show();
        }
        private void skyButton4_Click(object sender, EventArgs e)
        {

        }
        private void skyButton6_Click(object sender, EventArgs e)
        {
            bool resultado = MessageBox.Show("¿Desea cerrar la sesion?", "Cierre de Sesión", MessageBoxButtons.YesNo) == DialogResult.Yes ? true : false;
            if (resultado)
            {
                usuarioBll.Log_Out(resultado);

                Application.Exit();
            }
        }

        private void skyButton5_Click(object sender, EventArgs e)
        {

        }

        public void ActualizarIdioma()
        {
            skyButton1.Text = servicioIdioma.ObtenerTraduccion("menu_administracion");
            skyButton2.Text = servicioIdioma.ObtenerTraduccion("menu_maestro");
            skyButton3.Text = servicioIdioma.ObtenerTraduccion("menu_venta");
            skyButton4.Text = servicioIdioma.ObtenerTraduccion("menu_deposito");
            skyButton5.Text = servicioIdioma.ObtenerTraduccion("menu_ayuda");
            skyButton6.Text = servicioIdioma.ObtenerTraduccion("menu_cerrar_sesion");
        }
        private void CargarComboBoxIdioma()
        {
            aloneComboBox1.Items.Clear();
            aloneComboBox1.Items.Add(new BE_Idioma("es", "Español"));
            aloneComboBox1.Items.Add(new BE_Idioma("en", "English"));
            aloneComboBox1.DisplayMember = "Nombre";

            // Seleccionar el que coincide con el idioma activo
            string idiomaActual = servicioIdioma.ObtenerIdiomaActual();
            foreach (BE_Idioma item in aloneComboBox1.Items)
            {
                if (item.Id_Idioma == idiomaActual)
                {
                    aloneComboBox1.SelectedItem = item;
                    break;
                }
            }
        }

        private void aloneComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (aloneComboBox1.SelectedItem is BE_Idioma seleccionado)
            {
                servicioIdioma.CambiarIdioma(seleccionado.Id_Idioma);
                string idBitacora = SERVICIO_Criptografia.GenerarIDBitacora();
                string emailUsuario = SERVICIO_SesionUsuario.ObtenerInstancia().UsuarioActual.Email;
                bitacoraBll.AgregarBitacora(idBitacora, emailUsuario, "Cambio de idioma", "Idioma",3, DateTime.Now);
            }
        }
    }
}
