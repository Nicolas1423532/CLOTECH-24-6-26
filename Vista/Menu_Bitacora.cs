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
namespace Vista
{
    public partial class Menu_Bitacora : Form
    {
        BLL_Bitacora bllBitacora;
        BLL_Usuario bllUsuario;
        public Menu_Bitacora()
        {
            InitializeComponent();
        }

        private void Menu_Bitacora_Load(object sender, EventArgs e)
        {
            bllBitacora = new BLL_Bitacora();
            bllUsuario = new BLL_Usuario();
            foreach (var pD in this.Controls)
            {
                if (pD is ReaLTaiizor.Controls.PoisonDataGridView)
                {
                    (pD as ReaLTaiizor.Controls.PoisonDataGridView).MultiSelect = false;
                    (pD as ReaLTaiizor.Controls.PoisonDataGridView).SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                }
            }
            CargarLogInUsuarios();
        }
        private void CargarLogInUsuarios()
        {
            var usuariosActivos = bllUsuario.ObtenerTodosLosUsuariosActivos();
            dungeonComboBox1.Items.Clear();
            foreach (object usuario in usuariosActivos)
            {
                Type tipo = usuario.GetType();
                var propiedadEmail = tipo.GetProperty("Email");
                if (propiedadEmail != null)
                {
                    object valor = propiedadEmail.GetValue(usuario, null);
                    if (valor != null)
                    {
                        dungeonComboBox1.Items.Add(valor.ToString());
                    }
                }
            }
            Mostrar(poisonDataGridView1, bllBitacora.ObtenerTodasLasBitacoras());
        }

        private void Mostrar(PoisonDataGridView pDv, object datos)
        {
            pDv.DataSource = null; pDv.DataSource = datos;
        }

        private void skyButton2_Click(object sender, EventArgs e)
        {
            string emailSeleccionado = dungeonComboBox1.SelectedItem?.ToString();
            string moduloSeleccionado = dungeonComboBox2.SelectedItem?.ToString();
            string eventoSeleccionado = dungeonComboBox3.SelectedItem?.ToString();
            string criticidadSeleccionada = dungeonComboBox4.SelectedItem?.ToString();
            DateTime fechaIni = poisonDateTime1.Value;
            DateTime fechaFin = poisonDateTime2.Value;

            var registrosFiltrados = bllBitacora.ObtenerBitacorasFiltradas(
                emailSeleccionado,
                moduloSeleccionado,
                eventoSeleccionado,
                int.Parse(criticidadSeleccionada),
                fechaIni,
                fechaFin
            );
            Mostrar(poisonDataGridView1, registrosFiltrados);
        }

        private void skyButton1_Click(object sender, EventArgs e)
        {
            Mostrar(poisonDataGridView1, bllBitacora.ObtenerTodasLasBitacoras());
        }
    }
}
