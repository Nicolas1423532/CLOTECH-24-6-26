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
            DataRow filaRolNueva = dao.DtRol.NewRow();
            filaRolNueva.ItemArray = new object[] { rol.Id_rol, rol.Titulo, rol.Estado };
            dao.DtRol.Rows.Add(filaRolNueva);
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
        public void BorrarRol(BE_Rol rol)
        {
            DataRow fila = dao.DtRol.Rows.Find(rol.Id_rol);
            if (fila != null)
            {
                fila.Delete();
                dao.GuardarCambios();
            }
            else
            {
                throw new Exception("El rol que intenta eliminar no existe en la base de datos.");
            }
        }
        public bool PoseeUsuariosAsignados(string idRol)
        {
            bool resultado = false;
            foreach (DataRow filaUser in dao.DtUsuario.Rows)
            {
                if (filaUser.Field<bool>("Activo"))
                {
                    resultado = true;
                }
            }
            return resultado;
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
            filaAEliminar.Delete();
            dao.GuardarCambios();
        }
        public int TotalAdministradoresActivos()
        {
            int cantAdminEnUsuarios = 0;
            foreach (DataRow fila in dao.DtRol.Rows)
            {
                if (fila.Field<string>("Titulo").ToUpper().Contains("ADMINISTRADOR"))
                {
                    cantAdminEnUsuarios++;
                }
            }
            return cantAdminEnUsuarios;
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
            BE_Rol rol = new BE_Familia();
            BE_Familia familiaRaiz = null;
            DataRow filaUsuario = dao.DtUsuario.Rows.Find(idUsuario);

            if (filaUsuario != null)
            {
                DataRow[] asignaciones = filaUsuario.GetChildRows(dao.RelUsuario_A_Rol);
                if(asignaciones.Length > 0)
                {
                    foreach (DataRow filaAsig in asignaciones)
                    {
                        string idRol = filaAsig.Field<string>("Id_Rol");
                        DataRow filaRol = dao.DtRol.Rows.Find(idRol);
                        rol.Id_rol = filaRol.Field<string>("Id_Rol");
                        rol.Titulo = filaRol.Field<string>("Titulo");

                        if (filaRol != null)
                        {
                            DataRow[] filasRolXFamilia = filaRol.GetChildRows(dao.RelRolAFamilia);
                            if (filasRolXFamilia.Length > 0)
                            {
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
