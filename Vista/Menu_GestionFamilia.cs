using BE;
using BE;
using BLL;
using Microsoft.VisualBasic;
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
    public partial class Menu_GestionFamilia : Form
    {
        BLL_Familia familiaBll;
        BLL_Rol rolBll;
        BLL_Usuario usuarioBll;
        public Menu_GestionFamilia()
        {
            InitializeComponent();
        }
        private void Mostrar(PoisonDataGridView pDv, object datos)
        {
            pDv.DataSource = null; pDv.DataSource = datos;
        }
        private void skyButton4_Click(object sender, EventArgs e)
        {
            try
            {
                BE_Familia familia = new BE_Familia();
                familia.Id_rol = Interaction.InputBox("Id familia: ");
                familia.Titulo = Interaction.InputBox("Titulo familia: ");
                familia.Estado = MessageBox.Show("Estado del rol", "", MessageBoxButtons.YesNo) == DialogResult.Yes ? true : false;
                familiaBll.AgregarFamilia(familia);
                Mostrar(poisonDataGridView2, familiaBll.ObtenerTodasLasFamilias());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void skyButton5_Click(object sender, EventArgs e)
        {
            try
            {
                if (poisonDataGridView2.Rows.Count == 0) { throw new Exception("No hay familias para borrar"); }
                BE_Familia familia = new BE_Familia();
                familia.Id_rol = poisonDataGridView2.SelectedRows[0].Cells[0].Value.ToString();
                familiaBll.BorrarFamilia(familia);
                Mostrar(poisonDataGridView2, familiaBll.ObtenerTodasLasFamilias());
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

        private void Menu_GestionFamilia_Load(object sender, EventArgs e)
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
            familiaBll = new BLL_Familia();
            Mostrar(poisonDataGridView1, usuarioBll.ObtenerTodosLosUsuarios());
            Mostrar(poisonDataGridView2, familiaBll.ObtenerTodasLasFamilias());
        }
    }
}
