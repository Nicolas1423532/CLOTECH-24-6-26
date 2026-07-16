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

        // ════════════════════════════════════════════════════════════════════
        // CalcularDVH
        // Recibe los valores de UNA fila (sin incluir la columna DVH)
        // y devuelve su hash SHA-256.
        // La concatenación en orden garantiza que el intercambio de posiciones
        // entre columnas sea detectado.
        // ════════════════════════════════════════════════════════════════════
        public string CalcularDVH(object[] valoresFila)
        {
            StringBuilder sb = new StringBuilder();
            foreach (object valor in valoresFila)
                sb.Append(valor?.ToString() ?? "");

            return CalcularSHA256(sb.ToString());
        }

        // ════════════════════════════════════════════════════════════════════
        // CalcularDVV
        // Recibe una DataTable completa, lee el DVH de cada fila
        // ordenada por PK y hashea la concatenación de todos los DVH.
        // El orden fijo (OrderBy PK) garantiza que agregar/quitar/mover
        // filas sea detectado.
        // ════════════════════════════════════════════════════════════════════
        public string CalcularDVV(DataTable tabla, string nombreColumnaPK)
        {
            // Ordenar por PK para que el DVV sea determinístico
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
            // Ordenar por todas las columnas de la PK separadas por coma
            // Ejemplo: "Id_Usuario ASC, Id_Rol ASC"
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
        // ════════════════════════════════════════════════════════════════════
        // ObtenerValoresSinDVH
        // Devuelve el array de valores de una fila excluyendo la columna DVH
        // para evitar circularidad al calcular el nuevo DVH.
        // ════════════════════════════════════════════════════════════════════
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

        // ════════════════════════════════════════════════════════════════════
        // CalcularSHA256 — método privado reutilizable
        // ════════════════════════════════════════════════════════════════════
        private string CalcularSHA256(string input)
        {
            using SHA256 sha = SHA256.Create();
            byte[] bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(input));
            return BitConverter.ToString(bytes).Replace("-", "").ToUpper();
        }
    }
}
