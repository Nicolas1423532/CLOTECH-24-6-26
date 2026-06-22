using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using System.Data;
using BE;
namespace ORM
{
    public class ORM_Rol
    {
        DAO_ dao;
        public ORM_Rol()
        {
            dao = DAO_.ObtenerInstancia();
        }
        public void AgregarRol(BE_Rol rol)
        {
            DataRow fila = dao.DtRol.NewRow();
            fila.ItemArray = new object[] { rol.Id_rol, rol.Titulo, rol.Estado };
            dao.DtRol.Rows.Add(fila);
            dao.GuardarCambios();
        }
        public void ModificarRol(BE_Rol rol)
        {
            DataRow fila = dao.DtRol.Rows.Find(rol.Id_rol);
            if (fila != null)
            {
                fila.ItemArray = new object[] { fila.Field<string>(0), rol.Titulo, rol.Estado };
                dao.GuardarCambios();
            }
        }
        public BE_Rol ObtenerFamiliaDelUsuario(string idUsuario)
        {
            //List<BE_Rol> rolesDelUsuario = new List<BE_Rol>();
            BE_Rol rol = new BE_Familia();
            BE_Familia familiaRaiz = null;
            DataRow filaUsuario = dao.DtUsuario.Rows.Find(idUsuario);

            if (filaUsuario != null)
            {
                DataRow[] asignaciones = filaUsuario.GetChildRows(dao.RelUsuario_A_Rol);

                foreach (DataRow filaAsig in asignaciones)
                {
                    bool estaActivo = filaAsig.Field<bool>(3);

                    if (estaActivo)
                    {
                        string idRol = filaAsig.Field<string>(2);
                        DataRow filaRol = dao.DtRol.Rows.Find(idRol);
                        rol.Titulo = filaRol.Field<string>(1);

                        if (filaRol != null)
                        {
                            DataRow[] filasRolXFamilia = filaRol.GetChildRows(dao.RelRolAFamilia);

                            foreach (DataRow filaRolXFamilia in filasRolXFamilia)
                            {
                                string idFamilia = filaRolXFamilia.Field<string>(2);
                                DataRow filaFamilia = dao.DtFamilia.Rows.Find(idFamilia);
                                if (filaFamilia != null)
                                {
                                    BE_Familia familia = new BE_Familia(filaFamilia.ItemArray);
                                    ArmarHijosRecursivamente(familia, filaFamilia);

                                    if (familiaRaiz == null)
                                    {
                                        familiaRaiz = familia;
                                        (rol as BE_Familia).AgregarComponente(familiaRaiz);
                                    }
                                    else
                                    {
                                        familiaRaiz.AgregarComponente(familia);
                                    }
                                }
                            }

                            //if (familiaRaiz != null)
                            //{
                            //    familiaRaiz.AgregarComponente(familiaRaiz);
                            //}
                        }
                    }
                }
            }
            return rol;
            //List<BE_Rol> lstFamilia = new List<BE_Rol>();
            //BE_Familia familiaRaiz = null;
            //DataRow filaUsuario = dao.DtUsuario.Rows.Find(idlUsuario);
            //DataRow[] filasUsuarioXRol = filaUsuario.GetChildRows(dao.RelUsuario_A_Rol);
            //foreach(DataRow filaUsarioXRol in filasUsuarioXRol)
            //{
            //    string idRol = filaUsarioXRol.Field<string>(1);
            //}
            //DataRow[] filasRolXFamilia = filaRol.GetChildRows(dao.RelRolAFamilia);

            //foreach (DataRow filaRolXFamilia in filasRolXFamilia)
            //{
            //    string idFamilia = filaRolXFamilia.Field<string>(2);
            //    DataRow? filaFamilia = dao.DtFamilia.Rows.Find(idFamilia);
            //    //bool resultado = familiaRaiz.RetornarComponentes().Any(c=>c.Id_rol == idFamilia);
            //    if (filaFamilia != null/* && resultado != true*/)
            //    {
            //        BE_Familia familia = new BE_Familia(filaFamilia.ItemArray);
            //        ArmarHijosRecursivamente(familia, filaFamilia);
            //        if (familiaRaiz == null)
            //        {
            //            familiaRaiz = familia;
            //        }
            //        else
            //        {
            //            familiaRaiz.AgregarComponente(familia);
            //        }
            //    }
            //}
            //return familiaRaiz;
        }
        private void ArmarHijosRecursivamente(BE_Familia padre, DataRow filaFamilia)
        {
            DataRow[] filasPatenteXFamilia = filaFamilia.GetChildRows(dao.RelFamiliaAPatente);

                foreach (DataRow filaPatenteXFamilia in filasPatenteXFamilia)
                {
                    string idPatente = filaPatenteXFamilia.Field<string>(1);

                    DataRow? filaPatente = dao.DtPatente.Rows.Find(idPatente);
                    if (filaPatente != null)
                    {
                        BE_Patente patente = new BE_Patente(filaPatente.ItemArray);
                        padre.AgregarComponente(patente);
                    }
                }
                DataRow[] filasSubFamiliaXFamilia = filaFamilia.GetChildRows(dao.RelFamiliaPadre_A_SubFamilia);

            foreach (DataRow filaSubFamiliaXFamilia in filasSubFamiliaXFamilia)
            {
                string idSubFamilia = filaSubFamiliaXFamilia.Field<string>(2);
                DataRow? filaSubFamilia = dao.DtFamilia.Rows.Find(idSubFamilia);
                if (filaSubFamilia != null)
                {
                    BE_Familia subFamilia = new BE_Familia(filaSubFamilia.ItemArray);
                    ArmarHijosRecursivamente(subFamilia, filaSubFamilia);
                    padre.AgregarComponente(subFamilia);
                }
            }
        }
    }
}
