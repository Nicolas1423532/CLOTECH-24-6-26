using BLL;
using Microsoft.Data.SqlClient;

namespace Vista
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            //InicializarBaseDeDatos();
            BLL_DV bllDV = new BLL_DV();
            List<string> tablasCorruptas = bllDV.VerificarIntegridad();
            bool hayInconsistencia = tablasCorruptas.Count > 0;
            Application.Run(new Form1(hayInconsistencia));
        }
        static void InicializarBaseDeDatos()
        {
            string connMaster =
                "Data Source=.;Initial Catalog=master;" +
                "Integrated Security=True;Trust Server Certificate=True";

            using (SqlConnection conn = new SqlConnection(connMaster))
            {
                conn.Open();

                string sqlVerificar =
                    "SELECT COUNT(*) FROM sys.databases WHERE name = 'CLOTECH'";

                using (SqlCommand cmd = new SqlCommand(sqlVerificar, conn))
                {
                    int existe = (int)cmd.ExecuteScalar();

                    if (existe == 0)
                    {
                        string script = ObtenerScriptDesdeArchivo();
                        EjecutarScript(conn, script);
                    }
                }
            }
        }

        static string ObtenerScriptDesdeArchivo()
        {
            string rutaScript = Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "CLOTECH_BD.sql");

            if (!File.Exists(rutaScript))
                throw new Exception(
                    $"No se encontró el archivo de base de datos en: {rutaScript}");

            return File.ReadAllText(rutaScript);
        }

        static void EjecutarScript(SqlConnection conn, string script)
        {
            string[] bloques = System.Text.RegularExpressions.Regex
                                     .Split(script, @"^\s*GO\s*$",
                                            System.Text.RegularExpressions.RegexOptions.Multiline |
                                            System.Text.RegularExpressions.RegexOptions.IgnoreCase);

            foreach (string bloque in bloques)
            {
                string sql = bloque.Trim();
                if (string.IsNullOrEmpty(sql)) continue;

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.CommandTimeout = 60;
                    try { cmd.ExecuteNonQuery(); }
                    catch { }
                }
            }
        }
    }
}