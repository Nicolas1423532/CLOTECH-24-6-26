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
        public Menu_Bitacora()
        {
            InitializeComponent();
        }

        private void Menu_Bitacora_Load(object sender, EventArgs e)
        {
            foreach (var pD in this.Controls)
            {
                if (pD is ReaLTaiizor.Controls.PoisonDataGridView)
                {
                    (pD as ReaLTaiizor.Controls.PoisonDataGridView).MultiSelect = false;
                    (pD as ReaLTaiizor.Controls.PoisonDataGridView).SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                }
            }
            bllBitacora = new BLL_Bitacora();
            Mostrar(poisonDataGridView1, bllBitacora.ObtenerTodasLasBitacoras());
        }
        private void Mostrar(PoisonDataGridView pDv, object datos)
        {
            pDv.DataSource = null; pDv.DataSource = datos;
        }

    }
}
