using ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLL_Proveedor
    {
        ORM_Proveedor ormProveedor;
        public BLL_Proveedor()
        {
            ormProveedor = new ORM_Proveedor();
        }
        public void AgregarProveedor(BE.BE_Proveedor proveedor)
        {
            ormProveedor.AgregarProveedor(proveedor);
        }
        public void ModificarProveedor(BE.BE_Proveedor proveedor)
        {
            ormProveedor.ModificarProveedor(proveedor);
        }
        public List<object> ObtenerTodosLosProveedores()
        {
            return (from p in ormProveedor.ObtenerTodosLosProveedores()
                    select new
                    {
                        Id_proveedor = p.Id_proveedor,
                        Nombre = p.Nombre,
                        Apellido = p.Apellido,
                        Telefono = p.Telefono,
                        Dni = p.Dni,
                        Direccion = p.Direccion
                    }).ToList<object>();
        }
        public List<object> ObtenerProveedor(string id_proveedor)
        {
            return (from p in ormProveedor.ObtenerTodosLosProveedores()
                    where p.Id_proveedor == id_proveedor
                    select new
                    {
                        Id_proveedor = p.Id_proveedor,
                        Nombre = p.Nombre,
                        Apellido = p.Apellido,
                        Telefono = p.Telefono,
                        Dni = p.Dni,
                        Direccion = p.Direccion
                    }).ToList<object>();
        }
    }
}
