using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAO;
namespace ORM
{
    public class ORM_Bitacora
    {
        DAO_ dao;
        public ORM_Bitacora()
        {
            dao = DAO_.ObtenerInstancia();
        }
        public void AgregarBitacora(string idBitacora, string logIn,string evento, string modulo, int criticidad, DateTime fecha)
        {
            DataRow filaExistente = dao.DtBitacora.Rows.Find(idBitacora);
            if (filaExistente == null)
            {
                DataRow filaBitacora = dao.DtBitacora.NewRow();
                filaBitacora.ItemArray = new object[] {idBitacora,logIn,evento,modulo,criticidad,fecha};
                dao.DtBitacora.Rows.Add(filaBitacora);
                dao.GuardarCambios();
            }
        }
        public List<BE_Bitacora> ObtenerTodasLasBitacoras()
        {
            List<BE_Bitacora> lstBitacoras = new List<BE_Bitacora>();
            foreach (DataRow filaB in dao.DtBitacora.Rows)
            {
                lstBitacoras.Add(new BE_Bitacora(filaB.ItemArray));
            }
            return lstBitacoras;
        }
    }
}
