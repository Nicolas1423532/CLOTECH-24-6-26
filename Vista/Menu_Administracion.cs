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
    public partial class Menu_Administracion : Form
    {
        public Menu_Administracion()
        {
            InitializeComponent();
        }

        private void skyButton1_Click(object sender, EventArgs e)
        {
            Menu_GestionUsuario menuGUsuario = new Menu_GestionUsuario();
            menuGUsuario.Show();
        }

        private void skyButton4_Click(object sender, EventArgs e)
        {
            Menu_Bitacora menu_Bitacora = new Menu_Bitacora();
            menu_Bitacora.Show();
        }

        private void skyButton2_Click(object sender, EventArgs e)
        {
            Menu_GestionRol menu_rol = new Menu_GestionRol();
            menu_rol.Show();
        }
    }
}
