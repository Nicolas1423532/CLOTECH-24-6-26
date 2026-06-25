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
            DataRow filaExistente = dao.DtRol.Rows.Find(patente.Id_rol);
            if (filaExistente == null)
            {
                DataRow fila = dao.DtPatente.NewRow();
                fila.ItemArray = new object[] { patente.Id_rol, patente.Titulo, patente.Estado };
                dao.DtPatente.Rows.Add(fila);
                dao.GuardarCambios();
            }
            else { throw new Exception("La patente a crear ya existe en el sistema"); }
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
            if(fila != null)
            {
                fila.Delete();
                dao.GuardarCambios();
            }
        }
        public void AsignarPatente(BE_Patente patente, BE_Familia familia)
        {
            //DataRow filaPatente = dao.DtPatente.Rows.Find(patente.Id_rol);
            //DataRow filaFamilia = dao.DtPatente.Rows.Find(familia.Id_rol);
            DataRow relacionExistente = dao.DtPatenteXFamilia.Rows.Find(new object[] { patente.Id_rol, familia.Id_rol });
            if (relacionExistente != null)
            {
                throw new Exception("La patente ya se encuentra asignada al Rol seleccionado.");
            }
            DataRow nuevaFila = dao.DtPatenteXFamilia.NewRow();
            nuevaFila.ItemArray = new object[] { patente.Id_rol, familia.Id_rol };
            dao.DtPatenteXFamilia.Rows.Add(nuevaFila);
            dao.GuardarCambios();
        }
        public void DesasignarPatente(BE_Patente patente, BE_Familia familia)
        {
            DataRow filaRolXFamilia = dao.DtPatenteXFamilia.Rows.Find(new object[] { patente.Id_rol, familia.Id_rol });
            if (filaRolXFamilia != null)
            {
                filaRolXFamilia.Delete();
                dao.GuardarCambios();             
            }
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
