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
            // 1. Buscamos la fila del rol actual en memoria para conocer su Título real
            DataRow filaRolABorrar = dao.DtRol.Rows.Find(rol.Id_rol);

            if (filaRolABorrar == null)
            {
                throw new Exception("El rol que intenta eliminar no existe en la base de datos.");
            }

            string tituloRol = filaRolABorrar.Field<string>("Titulo").ToUpper();

            // 2. Si el rol contiene la palabra "ADMINISTRADOR", aplicamos la protección
            if (tituloRol.Contains("ADMINISTRADOR"))
            {
                // Contamos cuántos usuarios activos tienen asignado UN ROL que sea Administrador
                // Hacemos un Join en memoria entre UsuarioXRol y Rol para validar el título real
                int totalAdministradoresActivos = (from uxr in dao.DtUsuarioXRol.AsEnumerable()
                                                   join r in dao.DtRol.AsEnumerable()
                                                   on uxr.Field<string>("Id_Rol") equals r.Field<string>("Id_Rol")
                                                   where r.Field<string>("Titulo").ToUpper().Contains("ADMINISTRADOR")
                                                   select uxr).Count();

                // Si el conteo da 1 o menos, significa que este rol que quieren borrar 
                // representa al ÚNICO administrador que le da acceso al sistema. Bloqueamos.
                if (totalAdministradoresActivos <= 1)
                {
                    throw new Exception("No se puede eliminar este Rol porque es el único Administrador con usuarios asignados que queda en el sistema. Debe existir al menos un Administrador activo.");
                }
            }

            // 3. Si pasa la regla (o no era un administrador), procedemos al borrado
            // Primero eliminamos las relaciones en la tabla intermedia para evitar errores de FK (ConstraintException)
            DataRow[] filasRelacionadas = dao.DtUsuarioXRol.AsEnumerable()
                .Where(f => f.Field<string>("Id_Rol") == rol.Id_rol).ToArray();

            foreach (DataRow rel in filasRelacionadas)
            {
                rel.Delete();
            }

            // Ahora sí borramos el Rol de la tabla maestra
            filaRolABorrar.Delete();

            // Guardamos todo junto en la base de datos
            dao.GuardarCambios();

            //DataRow filaRol = dao.DtRol.Rows.Find(rol.Id_rol);
            //if (rol.Titulo.Contains("ADMINISTRADOR"))
            //{
            //    filaRol.Delete();
            //    dao.GuardarCambios();
            //}
            //else
            //{
            //    throw new Exception("No se puede eliminar el rol que pertenece a un administrador actual");
            //}
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
            //DataRow filaUsuarioXRol = filasUsuarioXRol[0];

        }
        public void Desasignar(BE_Usuario usuario, BE_Rol rol)
        {
            DataRow filaAEliminar = dao.DtUsuarioXRol.Rows.Find(new object[] { usuario.Id_usuario, rol.Id_rol });

            if (filaAEliminar == null)
            {
                throw new Exception("El usuario no tiene asignado este rol actualmente.");
            }

            // 2. Si el rol que se intenta quitar contiene la palabra "ADMINISTRADOR", aplicamos la regla
            if (rol.Titulo.ToUpper().Contains("ADMINISTRADOR"))
            {
                // Contamos cuántos usuarios tienen asignado un rol de tipo Administrador en este momento
                int totalAdministradoresActivos = (from uxr in dao.DtUsuarioXRol.AsEnumerable()
                                                   join r in dao.DtRol.AsEnumerable()
                                                   on uxr.Field<string>("Id_Rol") equals r.Field<string>("Id_Rol")
                                                   where r.Field<string>("Titulo").ToUpper().Contains("ADMINISTRADOR")
                                                   select uxr).Count();

                // Si el conteo es 1 o menos, significa que este usuario es el ÚNICO administrador activo. Bloqueamos.
                if (totalAdministradoresActivos <= 1)
                {
                    throw new Exception("No se puede desasignar este rol porque es el único Administrador activo que queda en el sistema. Debe existir al menos un Administrador con permisos.");
                }
            }

            // 3. Si pasa la validación, eliminamos la asignación de la tabla intermedia
            filaAEliminar.Delete();

            // Guardamos los cambios para impactar el DELETE en SQL Server
            dao.GuardarCambios();
            //DataRow filaUsuario = dao.DtUsuario.Rows.Find(usuario.Id_usuario);
            //DataRow filaRol = dao.DtRol.Rows.Find(rol.Id_rol);
            //int cantidadAdministradores = dao.DtRol.AsEnumerable().Count(f => f.Field<string>(1) == "Administrador" || f.Field<string>(1) == "ADMINISTRADOR");
            //DataRow[] filaUsuarioXRol = filaUsuario.GetChildRows(dao.RelUsuario_A_Rol);
            //DataRow filaAEliminar = filaUsuarioXRol[0];
            //if (rol.Titulo.Contains("ADMINISTRADOR"))
            //{
            //    // Contamos cuántos usuarios activos tienen asignado UN ROL que sea Administrador
            //    // Hacemos un Join en memoria entre UsuarioXRol y Rol para validar el título real
            //    int totalAdministradoresActivos = (from uxr in dao.DtUsuarioXRol.AsEnumerable()
            //                                       join r in dao.DtRol.AsEnumerable()
            //                                       on uxr.Field<string>("Id_Rol") equals r.Field<string>("Id_Rol")
            //                                       where r.Field<string>("Titulo").ToUpper().Contains("ADMINISTRADOR")
            //                                       select uxr).Count();

            //    // Si el conteo da 1 o menos, significa que este rol que quieren borrar 
            //    // representa al ÚNICO administrador que le da acceso al sistema. Bloqueamos.
            //    if (totalAdministradoresActivos <= 1)
            //    {
            //        throw new Exception("No se puede eliminar este Rol porque es el único Administrador con usuarios asignados que queda en el sistema. Debe existir al menos un Administrador activo.");
            //    }
            //}
            //if (filaAEliminar != null && rol.Titulo.Contains("ADMINISTRADOR") && cantidadAdministradores > 1)
            //{
            //    filaAEliminar.Delete();
            //    dao.GuardarCambios();
            //}
            //else if (filaAEliminar != null && (rol.Titulo.Contains("ADMINISTRADOR")))
            //{
            //    filaAEliminar.Delete();
            //    dao.GuardarCambios();
            //}
            //else { throw new Exception("El usuario ya no posee rol y/o debe haber mas de un administrador con permisos para deasignar uno"); }
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

                        //if (familiaRaiz != null)
                        //{
                        //    familiaRaiz.AgregarComponente(familiaRaiz);
                        //}
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
