using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAO;
using System.Data;
namespace ORM
{
    public class ORM_Producto
    {
        DAO_ dao;
        public ORM_Producto()
        {
            dao = DAO_.ObtenerInstancia();
        }
        public void AgregarProducto(BE_Producto producto)
        {
            DataRow fila = dao.DtProducto.NewRow();
            fila.ItemArray = new object[] { producto.Id_producto, producto.Nombre, producto.Descripcion, producto.Precio_unitario, producto.Stock };
            dao.DtProducto.Rows.Add(fila);
            dao.GuardarCambios();
        }
        public void ModificarProducto(BE_Producto producto)
        {
            DataRow fila = dao.DtProducto.Rows.Find(producto.Id_producto);
            if (fila != null)
            {
                fila.ItemArray = new object[] { fila.Field<string>(0), producto.Nombre, producto.Descripcion, producto.Precio_unitario, producto.Stock };
                dao.GuardarCambios();
            }
        }
        public List<BE_Producto> ObtenerTodosLosProductos()
        {
            List<BE_Producto> lstProductos = new List<BE_Producto>();
            foreach (DataRow fila in dao.DtProducto.Rows)
            {
                lstProductos.Add(new BE_Producto(fila.ItemArray));
            }
            return lstProductos;
        }
    }
}
