using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BE_Proveedor
    {
        string id_proveedor;
        string nombre;
        string apellido;
        int dni;
        int telefono;
        string direccion;
        public string Id_proveedor { get => id_proveedor; set => id_proveedor = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public int Dni { get => dni; set => dni = value; }
        public int Telefono { get => telefono; set => telefono = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public BE_Proveedor() { }
        public BE_Proveedor(string idProveedor, string _nombre, string _apellido, int _dni, int _telefono, string _direccion)
        {
            id_proveedor = idProveedor;
            nombre = _nombre;
            apellido = _apellido;
            dni = _dni;
            telefono = _telefono;
            direccion = _direccion;
        }
        public BE_Proveedor(object[] datos) : this(datos[0].ToString(), datos[1].ToString(), datos[2].ToString(), Convert.ToInt32(datos[3]), Convert.ToInt32(datos[4]), datos[5].ToString())
        { }
    }
}
