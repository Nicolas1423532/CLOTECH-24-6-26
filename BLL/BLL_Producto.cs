using ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLL_Producto
    {
        ORM_Producto ormProducto;
        public BLL_Producto()
        {
            ormProducto = new ORM_Producto();
        }
        public void AgregarProducto(BE.BE_Producto producto)
        {
            ormProducto.AgregarProducto(producto);
        }
        public void ModificarProducto(BE.BE_Producto producto)
        {
            ormProducto.ModificarProducto(producto);
        }
        public List<object> ObtenerTodosLosProductos()
        {
            return (from p in ormProducto.ObtenerTodosLosProductos()
                    select new
                    {
                        Id_producto = p.Id_producto,
                        Nombre = p.Nombre,
                        Descripcion = p.Descripcion,
                        Precio_unitario = p.Precio_unitario,
                        Stock = p.Stock
                    }).ToList<object>();
        }

    }
}
