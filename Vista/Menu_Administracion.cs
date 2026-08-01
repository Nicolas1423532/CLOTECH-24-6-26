using BE;
using SERVICIO;
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
        bool _inconsistencia;
        public Menu_Administracion(bool hayInconsistencia = false)
        {
            InitializeComponent();
            _inconsistencia = hayInconsistencia;
        }

        private void skyButton1_Click(object sender, EventArgs e)
        {
            Menu_GestionUsuario menuGUsuario = new Menu_GestionUsuario();
            menuGUsuario.ShowDialog();
        }

        private void skyButton4_Click(object sender, EventArgs e)
        {
            Menu_Bitacora menu_Bitacora = new Menu_Bitacora();
            menu_Bitacora.ShowDialog();
        }

        private void skyButton2_Click(object sender, EventArgs e)
        {
            Menu_GestionRol menu_rol = new Menu_GestionRol();
            menu_rol.ShowDialog();
        }

        private void skyButton3_Click(object sender, EventArgs e)
        {
            Menu_GestionFamilia menuFamilia = new Menu_GestionFamilia();
            menuFamilia.ShowDialog();
        }

        private void skyButton5_Click(object sender, EventArgs e)
        {
            Menu_GestionPatente menuPatente = new Menu_GestionPatente();
            menuPatente.ShowDialog();
        }

        private void skyButton6_Click(object sender, EventArgs e)
        {
            Menu_Reparacion menuReparacion = new Menu_Reparacion(_inconsistencia);
            menuReparacion.ShowDialog();
        }

        private void Menu_Administracion_Load(object sender, EventArgs e)
        {
            if (SERVICIO_SesionUsuario.ObtenerInstancia().FamiliaActual != null)
            {
                List<BE_Rol> patentes = (SERVICIO_SesionUsuario.ObtenerInstancia().FamiliaActual as BE_Familia).RetornarComponentesPlanos();
                ValidarPermisosUI(this.Controls, patentes);
            }
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
                if (c.Controls.Count > 0)
                    ValidarPermisosUI(c.Controls, patentesUsuario);
            }
        }
    }
}
