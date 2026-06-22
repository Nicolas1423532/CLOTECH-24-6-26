using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using BE;
using System.Data;
namespace ORM
{
    public class ORM_Cliente
    {
        DAO_ dao;
        public ORM_Cliente()
        {
            dao = DAO_.ObtenerInstancia();
        }
        public void AgregarCliente(BE_Cliente cliente)
        {
            DataRow fila = dao.DtCliente.NewRow();
            fila.ItemArray = new object[] { cliente.Id_cliente, cliente.Nombre, cliente.Apellido, cliente.Dni };
            dao.DtCliente.Rows.Add(fila);
            dao.GuardarCambios();
        }
        public void ModificarCliente(BE_Cliente cliente)
        {
            DataRow fila = dao.DtCliente.Rows.Find(cliente.Id_cliente);
            if (fila != null)
            {
                fila.ItemArray = new object[] { fila.Field<string>(0),cliente.Nombre, cliente.Apellido, cliente.Dni };
                dao.GuardarCambios();
            }
        }
        public List<BE_Cliente> ObtenerTodosLosClientes()
        {
            List<BE_Cliente> lstClientes = new List<BE_Cliente>();
            foreach (DataRow fila in dao.DtCliente.Rows)
            {
                lstClientes.Add(new BE_Cliente(fila.ItemArray));
            }
            return lstClientes;
        }
    }
}
