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
    public class ORM_Familia
    {
        DAO_ dao;
        public ORM_Familia()
        {
            dao = DAO_.ObtenerInstancia();
        }
        public void AgregarFamilia(BE_Familia familia)
        {
            DataRow fila = dao.DtFamilia.NewRow();
            fila.ItemArray = new object[] { familia.Id_rol, familia.Titulo, familia.Estado };
            dao.DtFamilia.Rows.Add(fila);
            dao.GuardarCambios();
        }
        public void ModificarFamilia(BE_Familia familia)
        {
            DataRow fila = dao.DtFamilia.Rows.Find(familia.Id_rol);
            if (fila != null)
            {
                fila.ItemArray = new object[] { fila.Field<string>(0), familia.Titulo, familia.Estado};
                dao.GuardarCambios();
            }
        }
        public List<BE_Familia> ObtenerTodasLasFamilias()
        {
            List<BE_Familia> lstFamilias = new List<BE_Familia>();
            foreach (DataRow fila in dao.DtFamilia.Rows)
            {
                lstFamilias.Add(new BE_Familia(fila.ItemArray));
            }
            return lstFamilias;
        }
    }
}
