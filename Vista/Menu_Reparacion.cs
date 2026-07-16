using BLL;
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
    public partial class Menu_Reparacion : Form
    {
        BLL_DV bllDV;
        bool _inconsistencia;
        public Menu_Reparacion(bool hayInconsistencia)
        {
            InitializeComponent();
            _inconsistencia = hayInconsistencia;
        }

        private void skyButton1_Click(object sender, EventArgs e)
        {
            try
            {
                var opcion = MessageBox.Show(
                    "¿Confirma que desea recalcular los dígitos verificadores?",
                    "Confirmar Recálculo",
                    MessageBoxButtons.YesNo) == DialogResult.Yes ? true : false;

                if (opcion)
                {
                    bllDV.RecalcularTodo();
                    MessageBox.Show(
                        "Recálculo completado. El sistema se cerrará.",
                        "Operación exitosa",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    Application.Exit();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void Menu_Reparacion_Load(object sender, EventArgs e)
        {
            skyButton1.Enabled = _inconsistencia;
            bllDV = new BLL_DV();
        }

        private void skyButton3_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog dialogo = new SaveFileDialog
                {
                    Filter = "Backup SQL Server (*.bak)|*.bak",
                    Title = "Guardar archivo de backup",
                    FileName = $"CLOTECH_Backup_{DateTime.Now:yyyyMMdd_HHmmss}.bak",
                    InitialDirectory = @"D:\SQL SERVER 2025\MSSQL17.MSSQLSERVER\MSSQL\Backup"
                };

                if (dialogo.ShowDialog() == DialogResult.OK)
                {
                    bllDV.GenerarBackup(dialogo.FileName);
                    MessageBox.Show(
                        $"Backup generado correctamente en:\n{dialogo.FileName}",
                        "Backup exitoso",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void skyButton2_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dialogo = new OpenFileDialog
                {
                    Filter = "Backup SQL Server (*.bak)|*.bak",
                    Title = "Seleccionar archivo de backup seguro",
                    InitialDirectory = @"D:\SQL SERVER 2025\MSSQL17.MSSQLSERVER\MSSQL\Backup"
                };

                if (dialogo.ShowDialog() == DialogResult.OK)
                {
                    var confirm = MessageBox.Show(
                        "¿Confirma la restauración del backup seleccionado?\n" +
                        "Esta operación reemplazará todos los datos actuales.",
                        "Confirmar Restauración",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);

                    if (confirm == DialogResult.Yes)
                    {
                        bllDV.RestaurarBackup(dialogo.FileName);
                        MessageBox.Show(
                            "Backup restaurado correctamente.\n" +
                            "El sistema se cerrará para un reinicio limpio.",
                            "Operación exitosa",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        Application.Exit();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
