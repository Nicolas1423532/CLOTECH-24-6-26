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
            //DataRow filaRolExistente = dao.DtRol.AsEnumerable().FirstOrDefault(f => f.Field<string>("Id_Rol") == rol.Id_rol|| f.Field<string>("Titulo") == rol.Titulo);
            int cantidadAdministradores = dao.DtRol.AsEnumerable().Count(f => f.Field<string>("Titulo") == "Administrador" || f.Field<string>("Titulo") == "ADMINISTRADOR");
            if (cantidadAdministradores > 0)
            {
                DataRow filaRolNueva = dao.DtRol.NewRow();
                filaRolNueva.ItemArray = new object[] { rol.Id_rol,rol.Titulo, rol.Estado };
                dao.DtRol.Rows.Add(filaRolNueva);
                dao.GuardarCambios();
            }
            
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
        public void BorrarRol(BE_Rol rol)
        {
            DataRow filaRolABorrar = dao.DtRol.Rows.Find(rol.Id_rol);
            if (filaRolABorrar == null)
            {
                throw new Exception("El rol que intenta eliminar no existe en la base de datos.");
            }
            string tituloRol = filaRolABorrar.Field<string>("Titulo").ToUpper();
            if (tituloRol.Contains("ADMINISTRADOR"))
            {
                int totalAdministradoresActivos = (from uxr in dao.DtUsuarioXRol.AsEnumerable()
                                                   join r in dao.DtRol.AsEnumerable()
                                                   on uxr.Field<string>("Id_Rol") equals r.Field<string>("Id_Rol")
                                                   where r.Field<string>("Titulo").ToUpper().Contains("ADMINISTRADOR")
                                                   select uxr).Count();
                if (totalAdministradoresActivos <= 1)
                {
                    throw new Exception("No se puede eliminar este Rol porque es el único Administrador con usuarios asignados que queda en el sistema. Debe existir al menos un Administrador activo.");
                }
            }
            DataRow[] filasRelacionadas = dao.DtUsuarioXRol.AsEnumerable()
                .Where(f => f.Field<string>("Id_Rol") == rol.Id_rol).ToArray();

            foreach (DataRow rel in filasRelacionadas)
            {
                rel.Delete();
            }

            filaRolABorrar.Delete();
            dao.GuardarCambios();
        }
        public void Asignar(BE_Usuario usuario, BE_Rol rol)
        {
            DataRow filaRol = dao.DtRol.Rows.Find(rol.Id_rol);
            DataRow filaUsuario = dao.DtUsuario.Rows.Find(usuario.Id_usuario);
            DataRow[] filasUsuarioXRol = filaUsuario.GetChildRows(dao.RelUsuario_A_Rol);
            if (filasUsuarioXRol.Length < 1)
            {
                DataRow fila = dao.DtUsuarioXRol.NewRow();
                fila.ItemArray = new object[] {usuario.Id_usuario, rol.Id_rol};
                dao.DtUsuarioXRol.Rows.Add(fila);
                dao.GuardarCambios();
            }
            else
            {
                throw new Exception("El usuario ya tiene rol asignado");
            }

        }
        public void Desasignar(BE_Usuario usuario, BE_Rol rol)
        {
            DataRow filaAEliminar = dao.DtUsuarioXRol.Rows.Find(new object[] { usuario.Id_usuario, rol.Id_rol });

            if (filaAEliminar == null)
            {
                throw new Exception("El usuario no tiene asignado este rol actualmente.");
            }
            if (rol.Titulo.ToUpper().Contains("ADMINISTRADOR"))
            {
                int totalAdministradoresActivos = (from uxr in dao.DtUsuarioXRol.AsEnumerable()
                                                   join r in dao.DtRol.AsEnumerable()
                                                   on uxr.Field<string>("Id_Rol") equals r.Field<string>("Id_Rol")
                                                   where r.Field<string>("Titulo").ToUpper().Contains("ADMINISTRADOR")
                                                   select uxr).Count();
                if (totalAdministradoresActivos <= 1)
                {
                    throw new Exception("No se puede desasignar este rol porque es el único Administrador activo que queda en el sistema. Debe existir al menos un Administrador con permisos.");
                }
            }
            filaAEliminar.Delete();
            dao.GuardarCambios();
        }
        public List<BE_Rol> ObtenerTodosLosRoles()
        {
            List<BE_Rol> listaRoles = new List<BE_Rol>();
            foreach(DataRow dataRow in dao.DtRol.Rows)
            {
                listaRoles.Add(new BE_Familia(dataRow.ItemArray));
            }
            return listaRoles;
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
                    string idRol = filaAsig.Field<string>("Id_Rol");
                    DataRow filaRol = dao.DtRol.Rows.Find(idRol);
                    rol.Id_rol = filaRol.Field<string>("Id_Rol");
                    rol.Titulo = filaRol.Field<string>("Titulo");

                    if (filaRol != null)
                    {
                        DataRow[] filasRolXFamilia = filaRol.GetChildRows(dao.RelRolAFamilia);

                        foreach (DataRow filaRolXFamilia in filasRolXFamilia)
                        {
                            string idFamilia = filaRolXFamilia.Field<string>("Id_Familia");
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
                    }
                }
            }
            return rol;
        }
        private void ArmarHijosRecursivamente(BE_Familia padre, DataRow filaFamilia)
        {
            DataRow[] filasPatenteXFamilia = filaFamilia.GetChildRows(dao.RelFamiliaAPatente);

                foreach (DataRow filaPatenteXFamilia in filasPatenteXFamilia)
                {
                    string idPatente = filaPatenteXFamilia.Field<string>(0);

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
                string idSubFamilia = filaSubFamiliaXFamilia.Field<string>(1);
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
