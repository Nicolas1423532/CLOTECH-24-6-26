using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BE_Producto
    {
        string id_producto;
        string nombre;
        string descripcion;
        decimal precio_unitario;
        int stock;
        public string Id_producto { get => id_producto; set => id_producto = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public decimal Precio_unitario { get => precio_unitario; set => precio_unitario = value; }
        public int Stock { get => stock; set => stock = value; }
        public BE_Producto() { }
        public BE_Producto(string idProducto, string _nombre, string _descripcion, decimal _precioUnitario, int _stock)
        {
            id_producto = idProducto;
            nombre = _nombre;
            descripcion = _descripcion;
            precio_unitario = _precioUnitario;
            stock = _stock;
        }
        public BE_Producto(object[] datos) : this(datos[0].ToString(), datos[1].ToString(), datos[2].ToString(), Convert.ToDecimal(datos[3]), Convert.ToInt32(datos[4]))
        { }
    }
}
