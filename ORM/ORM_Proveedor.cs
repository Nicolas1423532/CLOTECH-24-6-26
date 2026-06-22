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
    public class ORM_Proveedor
    {
        DAO_ dao;
        public ORM_Proveedor()
        {
            dao = DAO_.ObtenerInstancia();
        }
        public void AgregarProveedor(BE_Proveedor proveedor)
        {
            DataRow fila = dao.DtProveedor.NewRow();
            fila.ItemArray = new object[] { proveedor.Id_proveedor, proveedor.Nombre, proveedor.Apellido, proveedor.Telefono, proveedor.Dni, proveedor.Direccion };
            dao.DtProveedor.Rows.Add(fila);
            dao.GuardarCambios();
        }
        public void ModificarProveedor(BE_Proveedor proveedor)
        {
            DataRow fila = dao.DtProveedor.Rows.Find(proveedor.Id_proveedor);
            if (fila != null)
            {
                fila.ItemArray = new object[] { fila.Field<string>(0), proveedor.Nombre, proveedor.Apellido, proveedor.Telefono, proveedor.Dni, proveedor.Direccion };
                dao.GuardarCambios();
            }
        }
        public List<BE_Proveedor> ObtenerTodosLosProveedores()
        {
            List<BE_Proveedor> lstProveedores = new List<BE_Proveedor>();
            foreach (DataRow fila in dao.DtProveedor.Rows)
            {
                lstProveedores.Add(new BE_Proveedor(fila.ItemArray));
            }
            return lstProveedores;
        }
    }
}
