using BE;
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
using ReaLTaiizor.Controls;
using Microsoft.VisualBasic;

namespace Vista
{
    public partial class Menu_Venta : Form
    {
        public Menu_Venta()
        {
            InitializeComponent();
        }

        private void Menu_Venta_Load(object sender, EventArgs e)
        {
            foreach (var pD in this.Controls)
            {
                if (pD is ReaLTaiizor.Controls.PoisonDataGridView)
                {
                    (pD as ReaLTaiizor.Controls.PoisonDataGridView).MultiSelect = false;
                    (pD as ReaLTaiizor.Controls.PoisonDataGridView).SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                }
            }
        }
        private void Mostrar(PoisonDataGridView pD, object datos)
        {
            pD.DataSource = null;
            pD.DataSource = datos;
        }

        private void aloneTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
