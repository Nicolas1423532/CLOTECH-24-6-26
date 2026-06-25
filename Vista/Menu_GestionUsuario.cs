using ReaLTaiizor.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using BE;
using Microsoft.VisualBasic;
namespace Vista
{
    public partial class Menu_GestionUsuario : Form
    {
        BLL_Usuario usuarioBll;
        public Menu_GestionUsuario()
        {
            InitializeComponent();
        }

        private void Menu_GestionUsuario_Load(object sender, EventArgs e)
        {
            foreach (var pD in this.Controls)
            {
                if (pD is ReaLTaiizor.Controls.PoisonDataGridView)
                {
                    (pD as ReaLTaiizor.Controls.PoisonDataGridView).MultiSelect = false;
                    (pD as ReaLTaiizor.Controls.PoisonDataGridView).SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                }
            }
            usuarioBll = new BLL_Usuario();
            Mostrar(poisonDataGridView1, usuarioBll.ObtenerTodosLosUsuariosActivos());
            Mostrar(poisonDataGridView2, usuarioBll.ObtenerTodosLosUsuariosDesactivos());
        }
        private void Mostrar(PoisonDataGridView pDv, object datos)
        {
            pDv.DataSource = null; pDv.DataSource = datos;
        }

        private void skyButton1_Click(object sender, EventArgs e)
        {
            try
            {
                BE_Usuario usuario = new BE_Usuario();
                usuario.Id_usuario = Interaction.InputBox("Ingrese el id del usuario: ");
                usuario.Nombre = Interaction.InputBox("Ingrese el nombre del usuario: ");
                usuario.Apellido = Interaction.InputBox("Ingrese el apellido del usuario: ");
                usuario.Dni = Convert.ToInt32(Interaction.InputBox("Ingrese el DNI del usuario: "));
                usuario.Edad = Convert.ToInt16(Interaction.InputBox("Ingrese la edad del usuario: "));
                usuario.Rol = Interaction.InputBox("Ingrese el rol del usuario: ");
                bool activo = MessageBox.Show("¿Usuario activo?", "", MessageBoxButtons.YesNo) == DialogResult.Yes ? true : false;
                usuario.Activo = activo;
                usuarioBll.AgregarUsuario(usuario);
                Mostrar(poisonDataGridView1, usuarioBll.ObtenerTodosLosUsuariosActivos());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void skyButton2_Click(object sender, EventArgs e)
        {

        }

        private void skyButton3_Click(object sender, EventArgs e)
        {
            try
            {
                BE_Usuario usuario = new BE_Usuario();
                usuario.Id_usuario = poisonDataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                usuarioBll.ActivarUsuario(usuario);
                Mostrar(poisonDataGridView1, usuarioBll.ObtenerTodosLosUsuariosActivos());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void skyButton4_Click(object sender, EventArgs e)
        {
            try
            {
                BE_Usuario usuario = new BE_Usuario();
                usuario.Id_usuario = poisonDataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                usuarioBll.DesactivarUsuario(usuario);
                Mostrar(poisonDataGridView1, usuarioBll.ObtenerTodosLosUsuariosDesactivos());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
