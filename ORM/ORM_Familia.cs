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
            DataRow filaExistente = dao.DtFamilia.Rows.Find(familia.Id_rol);
            if(filaExistente == null)
            {
                DataRow fila = dao.DtFamilia.NewRow();
                fila.ItemArray = new object[] { familia.Id_rol, familia.Titulo, familia.Estado };
                dao.DtFamilia.Rows.Add(fila);
                dao.GuardarCambios();
            }
            else { throw new Exception("La familia a crear ya existe en el sistema"); }
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
        public void BorrarFamilia(BE_Familia familia)
        {
            DataRow fila = dao.DtFamilia.Rows.Find(familia.Id_rol);
            fila.Delete();
            dao.GuardarCambios();
        }
        public void AsignarFamilia(BE_Usuario usuario, BE_Rol rol, BE_Familia familia)
        {
            DataRow filaFamilia = dao.DtFamilia.Rows.Find(familia.Id_rol);
            if (filaFamilia == null)
            {
                throw new Exception("La Familia seleccionada no existe en la base de datos.");
            }
            DataRow relacionExistente = dao.DtRolXFamilia.Rows.Find(new object[] { rol.Id_rol, familia.Id_rol });
            if (relacionExistente != null)
            {
                throw new Exception("Esta Familia ya se encuentra asignada al Rol seleccionado.");
            }
            DataRow nuevaFila = dao.DtRolXFamilia.NewRow();
            nuevaFila.ItemArray = new object[] { rol.Id_rol, familia.Id_rol };

            dao.DtRolXFamilia.Rows.Add(nuevaFila);
            dao.GuardarCambios();
        }
        public void DesasignarFamilia(BE_Rol rol, BE_Familia familia)
        {
            DataRow filaAEliminar = dao.DtRolXFamilia.Rows.Find(new object[] { rol.Id_rol, familia.Id_rol });

            if (filaAEliminar == null)
            {
                throw new Exception("La relación entre el Rol y la Familia no existe.");
            }

            filaAEliminar.Delete();
            dao.GuardarCambios();
        }
        public void AsignarSubfamilia(BE_Familia familiaPadre, BE_Familia subFamilia)
        {
            DataRow relacionExistente = dao.DtFamiliaXFamilia.Rows.Find(new object[] { familiaPadre.Id_rol, subFamilia.Id_rol });

            if (relacionExistente != null)
            {
                throw new Exception("La subfamilia seleccionada ya se encuentra asignada a esta Familia.");
            }

            DataRow nuevaFilaSubFamilia = dao.DtFamiliaXFamilia.NewRow();
            nuevaFilaSubFamilia.ItemArray = new object[] { familiaPadre.Id_rol, subFamilia.Id_rol };

            dao.DtFamiliaXFamilia.Rows.Add(nuevaFilaSubFamilia);
            dao.GuardarCambios();
        }
        public void DesasignarSubfamilia(BE_Familia familiaPadre, BE_Familia subfamilia)
        {
            DataRow filaEliminar = dao.DtFamiliaXFamilia.Rows.Find(new object[] { familiaPadre.Id_rol, subfamilia.Id_rol });

            if (filaEliminar == null)
            {
                throw new Exception("La relación entre el Familia padre y la Subfamilia no existe.");
            }

            filaEliminar.Delete();
            dao.GuardarCambios();

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
