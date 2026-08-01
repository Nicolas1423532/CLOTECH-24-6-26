using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SERVICIO
{
    public class SERVICIO_DV
    {
        private static SERVICIO_DV? _instancia;
        private SERVICIO_DV() { }
        public static SERVICIO_DV ObtenerInstancia()
        {
            if (_instancia == null) _instancia = new SERVICIO_DV();
            return _instancia;
        }
        public string CalcularDVH(object[] valoresFila)
        {
            StringBuilder sb = new StringBuilder();
            foreach (object valor in valoresFila)
            {
                if (valor == null || valor == DBNull.Value)
                {
                    sb.Append("");
                }
                else if (valor is DateTime fecha)
                {
                    sb.Append(fecha.ToString("yyyy-MM-dd HH:mm:ss"));
                }
                else
                {
                    sb.Append(valor.ToString().Trim());
                }
            }
                

            return CalcularSHA256(sb.ToString());
        }
        public string CalcularDVV(DataTable tabla, string nombreColumnaPK)
        {
            DataView vista = new DataView(tabla);
            vista.Sort = $"{nombreColumnaPK} ASC";

            StringBuilder sb = new StringBuilder();
            foreach (DataRowView fila in vista)
            {
                if (tabla.Columns.Contains("DVH"))
                    sb.Append(fila["DVH"]?.ToString() ?? "");
            }

            return CalcularSHA256(sb.ToString());
        }
        public string CalcularDVV(DataTable tabla, string[] columnasPK)
        {
            string ordenamiento = string.Join(", ", columnasPK.Select(c => $"{c} ASC"));

            DataView vista = new DataView(tabla);
            vista.Sort = ordenamiento;

            StringBuilder sb = new StringBuilder();
            foreach (DataRowView fila in vista)
            {
                if (tabla.Columns.Contains("DVH"))
                    sb.Append(fila["DVH"]?.ToString() ?? "");
            }

            return CalcularSHA256(sb.ToString());
        }
        public object[] ObtenerValoresSinDVH(DataRow fila, DataTable tabla)
        {
            var valores = new List<object>();
            foreach (DataColumn col in tabla.Columns)
            {
                if (col.ColumnName != "DVH")
                    valores.Add(fila[col] ?? "");
            }
            return valores.ToArray();
        }
        private string CalcularSHA256(string input)
        {
            using SHA256 sha = SHA256.Create();
            byte[] bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(input));
            return BitConverter.ToString(bytes).Replace("-", "").ToUpper();
        }
    }
}
