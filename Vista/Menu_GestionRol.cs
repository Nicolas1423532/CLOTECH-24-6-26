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
            rolBll = new BLL_Rol();
            Mostrar(poisonDataGridView1, usuarioBll.ObtenerTodosLosUsuariosActivos());
            Mostrar(poisonDataGridView2, rolBll.ObtenerTodosLosRoles());
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
                BE_Rol rol = new BE_Familia() { Id_rol = idRol };
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
                if (foreverTreeView1.SelectedNode == null) { throw new Exception("El treeview no tiene roles, familia o patentes para mostrar"); }
                BE_Usuario usuario = new BE_Usuario();
                usuario.Id_usuario = poisonDataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                BE_Rol rol = new BE_Familia();
                rol.Id_rol = poisonDataGridView2.SelectedRows[0].Cells[0].Value.ToString();
                if (usuario != null && rol != null)
                {
                    rolBll.Asignar(usuario, rol);
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
                if(foreverTreeView1.SelectedNode.Text == "") { throw new Exception("El treeview no tiene roles, familia o patentes para mostrar"); }
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
    }
}
