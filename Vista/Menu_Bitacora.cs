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
        }

        private void Mostrar(PoisonDataGridView pDv, object datos)
        {
            pDv.DataSource = null; pDv.DataSource = datos;
        }

        private void skyButton2_Click(object sender, EventArgs e)
        {
            string emailSeleccionado = textBox1.Text;
            string moduloSeleccionado = textBox2.Text;
            string eventoSeleccionado = textBox3.Text;
            string criticidadSeleccionada = textBox4.Text;
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
