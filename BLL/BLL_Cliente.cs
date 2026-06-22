using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ORM;
using BE;
namespace BLL
{
    public class BLL_Cliente
    {
        ORM_Cliente ormCliente;
        public BLL_Cliente()
        {
            ormCliente = new ORM_Cliente();
        }

        public void AgregarCliente(BE_Cliente cliente)
        {
            ormCliente.AgregarCliente(cliente);
        }
        public void ModificarCliente(BE_Cliente cliente)
        {
            ormCliente.ModificarCliente(cliente);
        }
        public List<object> ObtenerTodosLosClientes()
        {
            return (from c in ormCliente.ObtenerTodosLosClientes() select new { ID_Cliente = c.Id_cliente, Nombre = c.Nombre, Apellido = c.Apellido, DNI = c.Dni }).ToList<object>();
        }
    }
}
