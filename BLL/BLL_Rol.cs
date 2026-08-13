using BE;
using Microsoft.VisualBasic;
using ORM;
using SERVICIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
namespace BLL
{
    public class BLL_Rol
    {
        ORM_Rol ormRol;
        ORM_Familia ormFamilia;
        ORM_Patente ormPatente;
        ORM_Bitacora ormBitacora;
        BE_Usuario usuarioActual = SERVICIO_SesionUsuario.ObtenerInstancia().UsuarioActual;
        public BLL_Rol()
        {
            ormRol = new ORM_Rol();
            ormFamilia = new ORM_Familia();
            ormPatente = new ORM_Patente();
            ormBitacora = new ORM_Bitacora();
        }
        public void AgregarRol(BE_Rol rol)
        {
            ValidarDatosDelRol(rol);
            ValidarIDRol(rol);
            if(rol.RetornarComponentes().Count == 0)
            {
                throw new Exception("El rol debe contener al menos un componente (familia o patente).");
            }
            if (ormRol.TotalAdministradoresActivos() <= 0)
            {
                throw new Exception("Operación inválida: El sistema requiere al menos un rol de Administrador configurado.");
            }

            ormRol.AgregarRol(rol);
            //Si seleccione una familia antes de crear el rol, asigno la familia al rol creado
            if (rol.RetornarComponentes().FirstOrDefault() is BE_Familia)
            {
                ormFamilia.AsignarFamilia(rol, rol.RetornarComponentes().FirstOrDefault() as BE_Familia);
            }
            //Si seleccione una patente antes de crear el rol, asigno la patente al rol creado
            else if (rol.RetornarComponentes().FirstOrDefault() is BE_Patente)
            {
                ormPatente.AsignarPatenteARol(rol.RetornarComponentes().FirstOrDefault() as BE_Patente, rol);
            }
            var idBitacora = SERVICIO_Criptografia.GenerarIDBitacora();
            ormBitacora.AgregarBitacora(idBitacora, usuarioActual.Email, "Agregar Rol", "Gestion de Rol", 1, DateTime.Parse(DateTime.Now.ToShortDateString()), DateTime.Now.TimeOfDay);
        }
        public void BorrarRol(BE_Rol rol)
        {
            if (rol != null)
            {
                if (rol.Titulo.ToUpper() == "ADMINISTRADOR" || rol.Titulo.ToUpper() == "ADMIN")
                {
                    throw new Exception("Operación denegada: El rol 'Administrador' es un componente crítico del sistema y no puede ser eliminado.");
                }

                //if (ormRol.PoseeUsuariosAsignados(rol.Id_rol))
                //{
                //    throw new Exception("No se puede borrar el rol porque existen usuarios activos asignados a él. Reasigne a los usuarios antes de continuar.");
                //}
                ormRol.BorrarRol(rol);
            }
        }
        public void ModificarRol(BE_Rol rol)
        {
            if(rol != null)
            {
                List<BE_Rol> todosLosRoles = ormRol.ObtenerTodosLosRoles();
                BE_Rol rolExistente = todosLosRoles.Find(r => r.Id_rol == rol.Id_rol);
                //if (rolExistente.Titulo.ToUpper().Contains("ADMINISTRADOR"))
                //{
                //    int adminsActivos = todosLosRoles.Count(r => r.Titulo.ToUpper().Contains("ADMINISTRADOR"));
                //    if (adminsActivos <= 1)
                //    {
                //        throw new Exception("No se puede modificar el rol Administrador si en el sistema.");
                //    }
                //}
                if(rolExistente == null)
                {
                    throw new Exception("El rol que intenta modificar no existe en el sistema.");
                }
                ValidarDatosDelRol(rol);
                ormRol.ModificarRol(rol);
                var idBitacora = SERVICIO_Criptografia.GenerarIDBitacora();
                ormBitacora.AgregarBitacora(idBitacora, usuarioActual.Email, "Modificar Rol", "Gestion de Rol", 1, DateTime.Parse(DateTime.Now.ToShortDateString()), DateTime.Now.TimeOfDay);
            }
        }
        private void ValidarIDRol(BE_Rol rol)
        {
            //validacion del id para luego validar si cada familia o patente pertenece a un rol o no
            string patron = @"^[AGCSE].*$";
            if (!Regex.IsMatch(rol.Id_rol, patron))
            {
                throw new Exception("El ID del rol debe comenzar con A, G, C, S o E");
            }
        }
        public void Asignar(BE_Usuario usuario, BE_Rol rol)
        {
            if(usuario != null && rol != null)
            {
                if(usuario.Rol != rol.Titulo) { throw new Exception($"El rol seleccionado no coincide con el rol del usuario.{Environment.NewLine}Ejemplo: Si el usuario posee el rol Gerente, no se deberia asignarle un rol distinto.{Environment.NewLine}Para eso modifique el rol del usuario. "); }
                ormRol.Asignar(usuario, rol);
            }
        }
        public void Desasignar(BE_Usuario usuario, BE_Rol rol)
        {
            if(usuario == null && rol == null) { throw new Exception("Rol o Usuario no seleccionado"); }
            if( ormRol.TotalAdministradoresActivos() > 0)
            {
                ormRol.Desasignar(usuario, rol);
            }
            else
            {
                throw new Exception("No puede desasignar un administrador existente si no hay mas de uno.");
            }
        }
        public int ObtenerCantidadRolFamilias(string idUsuario)
        {
            return ormRol.ObtenerCantidadRolesFamiliasAsignadas(idUsuario);
        }
        //cambiar nombre del metodo a: ObtenerRolRaizDelUsuario
        public List<BE_Rol> ObtenerFamiliaDelUsuario(string idUsuario)
        {
            List<BE_Rol> auxFamilias = new List<BE_Rol>();
            BE_Rol familia = ormRol.ObtenerRolRaizDelUsuario(idUsuario);
            auxFamilias.Add(familia);
            return auxFamilias;
        }
        public List<object> ObtenerTodosLosRoles()
        {
            return (from r in ormRol.ObtenerTodosLosRoles() select new { ID = r.Id_rol, TITULO = r.Titulo}).ToList<object>();
        }
        private void ValidarDatosDelRol(BE_Rol rol)
        {
            if (string.IsNullOrWhiteSpace(rol.Id_rol) && string.IsNullOrWhiteSpace(rol.Titulo))
            {
                throw new Exception("Los datos del son incorrectos");
            }
        }
    }
}
