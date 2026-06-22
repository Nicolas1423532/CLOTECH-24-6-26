using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BE_Factura
    {
        string id_factura;
        string id_cliente;
        string descripcion;
        string metodo_pago;
        DateTime fecha_emision;
        decimal total;

        public string Id_factura { get => id_factura; set => id_factura = value; }
        public string Id_cliente { get => id_cliente; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public string Metodo_pago { get => metodo_pago; set => metodo_pago = value; }
        public DateTime Fecha_emision { get => fecha_emision; set => fecha_emision = value; }
        public decimal Total { get => total; set => total = value; }
        public BE_Factura() { }
        public BE_Factura(string idFactura, string idCliente, string _descripcion, string metodoPago, DateTime fechaEmision, decimal _total)
        {
            id_factura = idFactura;
            id_cliente = idCliente;
            descripcion = _descripcion;
            metodo_pago = metodoPago;
            fecha_emision = fechaEmision;
            total = _total;
        }
        public BE_Factura(object[] datos) : this(datos[0].ToString(), datos[1].ToString(), datos[2].ToString(), datos[3].ToString(), Convert.ToDateTime(datos[4]), Convert.ToDecimal(datos[5]))
        { }
    }
}
