using ORM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLL_DV
    {
        ORM_DV ormDV;

        public BLL_DV()
        {
            ormDV = new ORM_DV();
        }
        public List<string> VerificarIntegridad()
        {
            return ormDV.VerificarIntegridadCompleta();
        }

        public void ActualizarDV(DataTable tabla, string nombreTabla, string nombreColumnaPK)
        {
            ormDV.ActualizarDVH(tabla);
            ormDV.ActualizarDVV(tabla, nombreTabla, nombreColumnaPK);
        }

        public void RecalcularTodo()
        {
            ormDV.RecalcularTodo();
        }
        public void GenerarBackup(string rutaDestino)
        {
            if (string.IsNullOrWhiteSpace(rutaDestino))
                throw new Exception("La ruta de destino del backup no es válida.");

            string? directorio = System.IO.Path.GetDirectoryName(rutaDestino);
            if (!System.IO.Directory.Exists(directorio))
                throw new Exception($"El directorio destino no existe: {directorio}");

            ormDV.GenerarBackup(rutaDestino);
        }
        public void RestaurarBackup(string rutaArchivoBak)
        {
            if (string.IsNullOrWhiteSpace(rutaArchivoBak))
                throw new Exception("La ruta del archivo de backup no es válida.");

            if (!System.IO.File.Exists(rutaArchivoBak))
                throw new Exception("El archivo de backup seleccionado no existe.");

            ormDV.RestaurarBackup(rutaArchivoBak);
        }
    }
}
