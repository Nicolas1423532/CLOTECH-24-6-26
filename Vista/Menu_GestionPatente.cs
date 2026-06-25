using BE;
using BLL;
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
namespace Vista
{
    public partial class Menu_GestionPatente : Form
    {
        BLL_Patente patenteBll;
        BLL_Rol rolBll;
        BLL_Usuario usuarioBll;
        public Menu_GestionPatente()
        {
            InitializeComponent();
        }

        private void skyButton10_Click(object sender, EventArgs e)
        {
            try
            {
                if(foreverTreeView1.SelectedNode == null) { throw new Exception("El treeview no tiene roles, familia o patentes para mostrar"); }
                BE_Familia familia = foreverTreeView1.SelectedNode.Tag as BE_Familia;
                BE_Patente patente = new BE_Patente();
                patente.Id_rol = poisonDataGridView2.SelectedRows[0].Cells[0].Value.ToString();
                patenteBll.AsignarPatente(patente, familia);

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
        private void Menu_GestionPatente_Load(object sender, EventArgs e)
        {
            foreach (var pD in this.Controls)
            {
                if (pD is ReaLTaiizor.Controls.PoisonDataGridView)
                {
                    (pD as ReaLTaiizor.Controls.PoisonDataGridView).MultiSelect = false;
                    (pD as ReaLTaiizor.Controls.PoisonDataGridView).SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                }
            }
            patenteBll = new BLL_Patente();
            rolBll = new BLL_Rol();
            usuarioBll = new BLL_Usuario();
            Mostrar(poisonDataGridView1, usuarioBll.ObtenerTodosLosUsuariosActivos());
            Mostrar(poisonDataGridView2, patenteBll.ObtenerTodasLasPatentes());
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

        private void skyButton11_Click(object sender, EventArgs e)
        {
            try
            {
                if(foreverTreeView1.SelectedNode == null) { throw new Exception("El treeview no tiene roles, familia o patentes para mostrar"); }
                BE_Usuario usuario = new BE_Usuario();
                usuario.Id_usuario = poisonDataGridView1.CurrentRow.Cells[0].Value.ToString();
                var familia = foreverTreeView1.SelectedNode.Tag as BE_Familia;
                BE_Patente patente = new BE_Patente();
                patente.Id_rol = poisonDataGridView2.SelectedRows[0].Cells[0].Value.ToString();
                patenteBll.DesasignarPatente(patente,familia);
                LlenarTreeViewPermisos(usuario.Id_usuario);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void skyButton7_Click(object sender, EventArgs e)
        {
            try
            {
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void skyButton8_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void skyButton9_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
