using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BE_Detalle
    {
        string id_detalle;
        string id_factura;
        string id_producto;
        int cantidad;
        decimal subtotal;
        decimal precio_venta;
        decimal descuento;
        public string Id_detalle { get => id_detalle; set => id_detalle = value; }
        public string Id_factura { get => id_factura; }
        public string Id_producto { get => id_producto; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
        public decimal Subtotal { get => subtotal; set => subtotal = value; }
        public decimal Precio_venta { get => precio_venta; set => precio_venta = value; }
        public decimal Descuento { get => descuento; set => descuento = value; }
        public BE_Detalle() { }
        public BE_Detalle(string idDetalle, string idFactura, string idProducto, int _cantidad, decimal subTotal, decimal _precioVenta,decimal _descuento)
        {
            id_detalle = idDetalle;
            id_factura = idFactura;
            id_producto = idProducto;
            cantidad = _cantidad;
            subtotal = subTotal;
            precio_venta = _precioVenta;
            descuento = _descuento;
        }
        public BE_Detalle(object[] datos) : this(datos[0].ToString(), datos[1].ToString(), datos[2].ToString(), Convert.ToInt32(datos[3]), Convert.ToDecimal(datos[4]), Convert.ToDecimal(datos[5]), Convert.ToDecimal(datos[6]))
        { }
    }
}
