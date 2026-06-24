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
    public class ORM_Patente
    {
        DAO_ dao;
        public ORM_Patente()
        {
            dao = DAO_.ObtenerInstancia();
        }
        public void AgregarPatente(BE_Patente patente)
        {
            DataRow fila = dao.DtPatente.NewRow();
            fila.ItemArray = new object[] { patente.Id_rol, patente.Titulo, patente.Estado };
            dao.DtPatente.Rows.Add(fila);
            dao.GuardarCambios();
        }
        public void ModificarPatente(BE_Patente patente)
        {
            DataRow fila = dao.DtPatente.Rows.Find(patente.Id_rol);
            if (fila != null)
            {
                fila.ItemArray = new object[] { fila.Field<string>(0), patente.Titulo, patente.Estado };
                dao.GuardarCambios();
            }
        }
        public void BorrarPatente(BE_Patente patente)
        {
            DataRow fila = dao.DtPatente.Rows.Find(patente.Id_rol);
            fila.Delete();
            dao.GuardarCambios();
        }
        public List<BE_Patente> ObtenerTodasLasPatentes()
        {
            List<BE_Patente> lstPatentes = new List<BE_Patente>();
            foreach (DataRow fila in dao.DtPatente.Rows)
            {
                lstPatentes.Add(new BE_Patente(fila.ItemArray));
            }
            return lstPatentes;
        }
    }
}
