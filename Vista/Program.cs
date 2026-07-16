using BLL;

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
            BLL_DV bllDV = new BLL_DV();
            List<string> tablasCorruptas = bllDV.VerificarIntegridad();
            bool hayInconsistencia = tablasCorruptas.Count > 0;
            Application.Run(new Form1(hayInconsistencia));
        }
    }
}