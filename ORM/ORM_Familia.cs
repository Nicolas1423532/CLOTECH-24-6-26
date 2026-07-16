using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using BE;
using ORM;
using System.Data;
namespace ORM
{
    public class ORM_Familia
    {
        DAO_ dao;
        ORM_DV ormDV;
        public ORM_Familia()
        {
            dao = DAO_.ObtenerInstancia();
            ormDV = new ORM_DV();
        }
        public void AgregarFamilia(BE_Familia familia)
        {
            DataRow filaExistente = dao.DtFamilia.Rows.Find(familia.Id_rol);
            if(filaExistente == null)
            {
                DataRow fila = dao.DtFamilia.NewRow();
                fila.ItemArray = new object[] { familia.Id_rol, familia.Titulo, familia.Estado };
                dao.DtFamilia.Rows.Add(fila);
                ormDV.ActualizarDVH(dao.DtFamilia);
                ormDV.ActualizarDVV(dao.DtFamilia, "Familia","Id_Familia");
                dao.GuardarCambios();
            }
            else { throw new Exception("La familia a crear ya existe en el sistema"); }
        }
        public void ModificarFamilia(BE_Familia familia)
        {
            DataRow fila = dao.DtFamilia.Rows.Find(familia.Id_rol);
            int filasConectadasARol = fila.GetChildRows(dao.RelFamiliaAlRol).Length;
            int filasConectadasASubfamilia = fila.GetChildRows(dao.RelFamiliaPadre_A_SubFamilia).Length;
            int filasConectadasAPatente = fila.GetChildRows(dao.RelFamiliaAPatente).Length;
            int combinacion = filasConectadasARol + filasConectadasASubfamilia + filasConectadasAPatente;
            if (fila != null && combinacion < 1)
            {
                fila.ItemArray = new object[] { fila.Field<string>(0), familia.Titulo, familia.Estado};
                ormDV.ActualizarDVH(dao.DtFamilia);
                ormDV.ActualizarDVV(dao.DtFamilia, "Familia", "Id_Familia");
                dao.GuardarCambios();
            }
            else { throw new Exception("No se puede modificar la familia si esta asociada a usuarios/familias/patentes"); }
        }
        public void BorrarFamilia(BE_Familia familia)
        {
            DataRow fila = dao.DtFamilia.Rows.Find(familia.Id_rol);
            //int filasRelacionadas = dao.DtRolXFamilia.Select($"Id_rol = {familia.Id_rol}").Length;
            //int filasRelacionadas = fila.GetChildRows(dao.RelFamiliaAlRol).Length;
            int filasConectadasARol = fila.GetChildRows(dao.RelFamiliaAlRol).Length;
            int filasConectadasASubfamilia = fila.GetChildRows(dao.RelFamiliaPadre_A_SubFamilia).Length;
            int filasConectadasAPatente = fila.GetChildRows(dao.RelFamiliaAPatente).Length;
            int combinacion = filasConectadasARol + filasConectadasASubfamilia + filasConectadasAPatente;
            if (fila!= null && combinacion < 1)
            {
                fila.Delete();
                ormDV.ActualizarDVH(dao.DtFamilia);
                ormDV.ActualizarDVV(dao.DtFamilia, "Familia", "Id_Familia");
                dao.GuardarCambios();
            }
            else
            {
                throw new Exception("No se puede eliminar la familia porque tiene roles asignados o no existe en la BD");
            }
        }
        public void AsignarFamilia(BE_Rol rol, BE_Familia familia)
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
            ormDV.ActualizarDVH(dao.DtRolXFamilia);
            ormDV.ActualizarDVV(dao.DtRolXFamilia,"RolXFamilia",new string[] {"Id_Rol","Id_Familia"});
            dao.GuardarCambios();
        }
        public void DesasignarFamilia(BE_Rol rol, BE_Familia familia)
        {
            DataRow filaFamilia = dao.DtFamilia.Rows.Find(familia.Id_rol);
            DataRow filaAEliminar = dao.DtRolXFamilia.Rows.Find(new object[] { rol.Id_rol, familia.Id_rol });
            DataRow[] filasPatentes = filaFamilia.GetChildRows(dao.RelFamiliaAPatente);
            if (filaAEliminar == null || filasPatentes.Length > 0)
            {
                throw new Exception("No se puede borrar la familia del usuario si tiene patentes incluidas.");
            }

            filaAEliminar.Delete();
            ormDV.ActualizarDVH(dao.DtRolXFamilia);
            ormDV.ActualizarDVV(dao.DtRolXFamilia, "RolXFamilia", new string[] { "Id_Rol", "Id_Familia" });
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
            ormDV.ActualizarDVH(dao.DtFamiliaXFamilia);
            ormDV.ActualizarDVV(dao.DtFamiliaXFamilia, "FamiliaXFamilia", new string[] { "Id_FamiliaPadre", "Id_SubFamilia" });
            dao.GuardarCambios();
        }
        public void DesasignarSubfamilia(BE_Familia familiaPadre, BE_Familia subfamilia)
        {
            DataRow familia2 = dao.DtFamilia.Rows.Find(subfamilia.Id_rol);
            DataRow filaEliminar = dao.DtFamiliaXFamilia.Rows.Find(new object[] { familiaPadre.Id_rol, subfamilia.Id_rol });
            int filasConectadasApatentes = familia2.GetChildRows(dao.RelFamiliaAPatente).Length;
            int filasConectadasAotrasFamilias = familia2.GetChildRows(dao.RelFamiliaPadre_A_SubFamilia).Length;
            int combinacion = filasConectadasApatentes + filasConectadasAotrasFamilias;
            if (combinacion < 1)
            {
                filaEliminar.Delete();
                ormDV.ActualizarDVH(dao.DtFamiliaXFamilia);
                ormDV.ActualizarDVV(dao.DtFamiliaXFamilia, "FamiliaXFamilia", new string[] { "Id_FamiliaPadre", "Id_SubFamilia" });
                dao.GuardarCambios();
            }
            else { throw new Exception("La subfamilia a desasignar esta asociada a otras familias/patentes. Primero desasigne todas las relaciones que tenga la subfamilia"); }


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
