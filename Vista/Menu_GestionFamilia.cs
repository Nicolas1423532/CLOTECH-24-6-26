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

namespace Vista
{
    public partial class Menu_GestionFamilia : Form
    {
        BLL_Familia familiaBll;
        BLL_Rol rolBll;
        BLL_Usuario usuarioBll;
        BLL_Patente patenteBll;
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
                BE_Patente patente;
                BE_Familia subFamilia;
                var idSubFamilia = "";
                var tituloSubFamilia = "";
                var idPatente = "";
                var tituloPatente = "";
                BE_Familia familia = new BE_Familia();
                if (radioButton1.Checked)
                {
                    idSubFamilia = poisonDataGridView2.SelectedRows[0].Cells[0].Value.ToString();
                    tituloSubFamilia = poisonDataGridView2.SelectedRows[0].Cells[1].Value.ToString();
                    subFamilia = new BE_Familia(); subFamilia.Id_rol = idSubFamilia; subFamilia.Titulo = tituloSubFamilia;
                    familia.AgregarComponente(subFamilia);
                }
                if (radioButton2.Checked) 
                { 
                    idPatente = poisonDataGridView3.SelectedRows[0].Cells[0].Value.ToString();
                    tituloPatente = poisonDataGridView3.SelectedRows[0].Cells[1].Value.ToString();
                    patente = new BE_Patente(); patente.Id_rol = idPatente; patente.Titulo = tituloPatente;
                    familia.AgregarComponente(patente);
                }
                familia.Id_rol = textBox1.Text;
                familia.Titulo = textBox2.Text;
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
            patenteBll = new BLL_Patente();
            Mostrar(poisonDataGridView1, usuarioBll.ObtenerTodosLosUsuariosActivos());
            Mostrar(poisonDataGridView2, familiaBll.ObtenerTodasLasFamilias());

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

        private void skyButton10_Click(object sender, EventArgs e)
        {
            try
            {
                BE_Usuario usuario = new BE_Usuario();
                usuario.Id_usuario = poisonDataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                usuario.Rol = poisonDataGridView1.SelectedRows[0].Cells[6].Value.ToString();
                BE_Familia familiaAAgregar = new BE_Familia();
                familiaAAgregar.Id_rol = poisonDataGridView2.SelectedRows[0].Cells[0].Value.ToString();
                familiaAAgregar.Titulo = poisonDataGridView2.SelectedRows[0].Cells[1].Value.ToString();
                var objetoNodo = foreverTreeView1.SelectedNode.Tag;
                if (foreverTreeView1.SelectedNode.Parent == null)
                {
                    BE_Rol rolRaiz = objetoNodo as BE_Rol;
                    familiaBll.AsignarFamilia(rolRaiz, familiaAAgregar);
                }
                else
                {
                    BE_Familia familiaPadre = objetoNodo as BE_Familia;
                    familiaBll.AsignarSubfamilia(familiaPadre, familiaAAgregar);
                }
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
                BE_Usuario usuario = new BE_Usuario();
                usuario.Id_usuario = poisonDataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                BE_Familia familiaAAgregar = new BE_Familia();
                familiaAAgregar.Id_rol = poisonDataGridView2.SelectedRows[0].Cells[0].Value.ToString();
                familiaAAgregar.Titulo = poisonDataGridView2.SelectedRows[0].Cells[1].Value.ToString();
                var objetoNodo = foreverTreeView1.SelectedNode.Tag;
                if (foreverTreeView1.SelectedNode.Parent == null)
                {
                    BE_Rol rolRaiz = objetoNodo as BE_Rol;
                    familiaBll.DesasignarFamilia(rolRaiz, familiaAAgregar);
                }
                else
                {
                    BE_Familia familiaPadre = objetoNodo as BE_Familia;
                    familiaBll.DesasignarSubfamilia(familiaPadre, familiaAAgregar);
                }
                LlenarTreeViewPermisos(usuario.Id_usuario);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void skyButton6_Click(object sender, EventArgs e)
        {
            try
            {
                BE_Familia familia = new BE_Familia();
                familia.Id_rol = poisonDataGridView2.SelectedRows[0].Cells[0].Value.ToString();
                familia.Titulo = textBox2.Text;
                familiaBll.ModificarFamilia(familia);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            Mostrar(poisonDataGridView2, familiaBll.ObtenerTodasLasFamilias());
            Mostrar(poisonDataGridView3, null);
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            Mostrar(poisonDataGridView3, patenteBll.ObtenerTodasLasPatentes());
            Mostrar(poisonDataGridView2, null);
        }

        private void poisonDataGridView2_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                textBox1.Text = poisonDataGridView2.SelectedRows[0].Cells[0].Value.ToString();
                textBox2.Text = poisonDataGridView2.SelectedRows[0].Cells[1].Value.ToString();
            }
            catch (Exception ex)
            {   

            }
        }
    }
}
