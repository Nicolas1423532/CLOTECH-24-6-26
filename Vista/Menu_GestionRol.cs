using BE;
using BLL;
using Microsoft.VisualBasic;
using ORM;
using ReaLTaiizor.Controls;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Vista
{
    public partial class Menu_GestionRol : Form
    {
        BLL_Usuario usuarioBll;
        BLL_Rol rolBll;
        BLL_Familia familiaBll;
        BLL_Patente patenteBll;
        public Menu_GestionRol()
        {
            InitializeComponent();
        }

        private void Menu_GestionRol_Load(object sender, EventArgs e)
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
            patenteBll = new BLL_Patente();
            rolBll = new BLL_Rol();
            Mostrar(poisonDataGridView1, usuarioBll.ObtenerTodosLosUsuariosActivos());
            //mostrar roles y patentes disponibles en el datagridview2
            Mostrar(poisonDataGridView2, rolBll.ObtenerTodosLosRoles());
            Mostrar(poisonDataGridView3, patenteBll.ObtenerTodasLasPatentes());
            radioButton1.Checked = true;

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
        private void Mostrar(PoisonDataGridView pDv, object datos)
        {
            pDv.DataSource = null; pDv.DataSource = datos;
        }

        private void poisonDataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (poisonDataGridView1.Rows.Count == 0) { throw new Exception("No hay usuarios"); }
                BE_Usuario usuario = new BE_Usuario();
                usuario.Id_usuario = poisonDataGridView1.CurrentRow.Cells[0].Value.ToString();
                LlenarTreeViewPermisos(usuario.Id_usuario);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }
        private void LlenarTreeViewPermisos(string idUsuario)
        {
            foreverTreeView1.Nodes.Clear();
            List<BE_Rol> rolesActivos = rolBll.ObtenerFamiliaDelUsuario(idUsuario);

            foreach (BE_Rol rol in rolesActivos)
            {
                if (rol != null)
                {
                    TreeNode nodoRol = new TreeNode(rol.Titulo);
                    nodoRol.Tag = rol;
                    foreverTreeView1.Nodes.Add(nodoRol);
                    AgregarHijosAlTreeView(nodoRol, rol);

                }
            }

            foreverTreeView1.ExpandAll();
        }

        private void AgregarHijosAlTreeView(TreeNode nodoPadre, BE_Rol familiaPadre)
        {
            foreach (BE_Rol componente in familiaPadre.RetornarComponentes())
            {
                TreeNode nodoHijo = new TreeNode(componente.Titulo);
                nodoHijo.Tag = componente;
                nodoPadre.Nodes.Add(nodoHijo);
                if (componente is BE_Familia subFamilia)
                {
                    AgregarHijosAlTreeView(nodoHijo, subFamilia);
                }
            }
        }

        private void skyButton1_Click(object sender, EventArgs e)
        {
            try
            {
                BE_Rol rol = new BE_Familia();
                rol.Id_rol = Interaction.InputBox("Id del rol: ");
                rol.Titulo = Interaction.InputBox("Titulo del rol: ");
                rol.Estado = MessageBox.Show("Estado del rol", "", MessageBoxButtons.YesNo) == DialogResult.Yes ? true : false;

                //BE_Usuario usuario = poisonDataGridView1.SelectedRows[0].DataBoundItem as BE_Usuario;
                rolBll.AgregarRol(rol);

                Mostrar(poisonDataGridView2, rolBll.ObtenerTodosLosRoles());
                //rolBll.AgregarRol();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void skyButton3_Click(object sender, EventArgs e)
        {
            try
            {
                if (foreverTreeView1.Nodes.Count == 0) { throw new Exception("No hay rol para eliminar"); }
                string idRol = poisonDataGridView2.SelectedRows[0].Cells[0].Value.ToString();
                string tituloRol = poisonDataGridView2.SelectedRows[0].Cells[1].Value.ToString();
                BE_Rol rol = new BE_Familia() { Id_rol = idRol, Titulo = tituloRol };
                rolBll.BorrarRol(rol);
                Mostrar(poisonDataGridView2, rolBll.ObtenerTodosLosRoles());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void skyButton5_Click(object sender, EventArgs e)
        {

        }

        private void skyButton4_Click(object sender, EventArgs e)
        {

        }

        private void skyButton10_Click(object sender, EventArgs e)
        {
            try
            {
                BE_Usuario usuario = new BE_Usuario();
                usuario.Id_usuario = poisonDataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                usuario.Rol = poisonDataGridView1.SelectedRows[0].Cells[6].Value.ToString();
                BE_Rol rol = new BE_Familia();
                rol.Id_rol = poisonDataGridView2.SelectedRows[0].Cells[0].Value.ToString();
                if (usuario != null && rol != null)
                {
                    if(radioButton1.Checked)
                    {
                        rolBll.Asignar(usuario, rol);
                    }
                    else if(radioButton2.Checked)
                    {
                        //si el usuario ya tiene rol asignado, se le puede agregar patentes 
                        BE_Patente patente = new BE_Patente();
                        patente.Id_rol = poisonDataGridView3.SelectedRows[0].Cells[0].Value.ToString();
                        patenteBll.AsignarPatenteARol(patente,rol);
                    }
                }
                //BE_Usuario usuario = new BE_Usuario();
                //usuario.Id_usuario = poisonDataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                LlenarTreeViewPermisos(usuario.Id_usuario);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void skyButton6_Click(object sender, EventArgs e)
        {

        }

        private void skyButton11_Click(object sender, EventArgs e)
        {
            try
            {
                BE_Usuario usuario = new BE_Usuario();
                usuario.Id_usuario = poisonDataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                if (foreverTreeView1.SelectedNode.Text == "") { throw new Exception("El treeview no tiene roles, familia o patentes para mostrar"); }
                BE_Rol rol = foreverTreeView1.SelectedNode.Tag as BE_Rol;
                rolBll.Desasignar(usuario, rol);
                LlenarTreeViewPermisos(usuario.Id_usuario);
                //BE_Rol rolRaiz = foreverTreeView1.SelectedNode.Tag as BE_Rol;
                //if (rolRaiz != null)
                //{
                //    rolBll.Desasignar(rolRaiz);
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void skyButton2_Click(object sender, EventArgs e)
        {
            try
            {
                BE_Rol rol = new BE_Familia();
                rol.Id_rol = poisonDataGridView2.SelectedRows[0].Cells[0].Value.ToString();
                rol.Titulo = Interaction.InputBox("Titulo del rol: ");
                rol.Estado = MessageBox.Show("Estado del rol", "", MessageBoxButtons.YesNo) == DialogResult.Yes ? true : false;
                rolBll.ModificarRol(rol);
                Mostrar(poisonDataGridView2, rolBll.ObtenerTodosLosRoles());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            //Mostrar(poisonDataGridView2, rolBll.ObtenerTodosLosRoles());
            //Mostrar(poisonDataGridView3, null);
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            //Mostrar(poisonDataGridView3, patenteBll.ObtenerTodasLasPatentes());
            //Mostrar(poisonDataGridView2, null);
        }
    }
}
