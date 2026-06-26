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
        ORM_Bitacora ormBitacora;
        BE_Usuario usuarioActual = SERVICIO_SesionUsuario.ObtenerInstancia().UsuarioActual;
        public BLL_Rol()
        {
            ormRol = new ORM_Rol();
            ormBitacora = new ORM_Bitacora();
        }
        public void AgregarRol(BE_Rol rol)
        {
            ValidarDatosDelRol(rol);
            if (ormRol.TotalAdministradoresActivos() <= 0)
            {
                throw new Exception("Operación inválida: El sistema requiere al menos un rol de Administrador configurado.");
            }
            ormRol.AgregarRol(rol);
            var idBitacora = SERVICIO_Criptografia.GenerarIDBitacora();
            ormBitacora.AgregarBitacora(idBitacora, usuarioActual.Email, "Agregar Rol", "Gestion de Rol", 1, DateTime.Now);
        }
        public void BorrarRol(BE_Rol rol)
        {
            if (rol != null)
            {
                if (rol.Titulo.ToUpper() == "ADMINISTRADOR" || rol.Titulo.ToUpper() == "ADMIN")
                {
                    throw new Exception("Operación denegada: El rol 'Administrador' es un componente crítico del sistema y no puede ser eliminado.");
                }

                if (ormRol.PoseeUsuariosAsignados(rol.Id_rol))
                {
                    throw new Exception("No se puede borrar el rol porque existen usuarios activos asignados a él. Reasigne a los usuarios antes de continuar.");
                }
                ormRol.BorrarRol(rol);
            }
        }
        public void ModificarRol(BE_Rol rol)
        {
            if(rol != null)
            {
                List<BE_Rol> todosLosRoles = ormRol.ObtenerTodosLosRoles();
                BE_Rol rolExistente = todosLosRoles.Find(r => r.Id_rol == rol.Id_rol);
                if (rolExistente.Titulo.ToUpper().Contains("ADMINISTRADOR"))
                {
                    if (rolExistente.Estado == true && rol.Estado == false)
                    {
                        int adminsActivos = todosLosRoles.Count(r => r.Titulo.ToUpper().Contains("ADMINISTRADOR"));
                        if (adminsActivos <= 1)
                        {
                            throw new Exception("No se puede desactivar el rol Administrador porque es el único rol de gestión activo en el sistema.");
                        }
                    }
                }
                ValidarDatosDelRol(rol);
                ormRol.ModificarRol(rol);
                var idBitacora = SERVICIO_Criptografia.GenerarIDBitacora();
                ormBitacora.AgregarBitacora(idBitacora, usuarioActual.Email, "Modificar Rol", "Gestion de Rol", 1, DateTime.Now);
            }
        }
        public void Asignar(BE_Usuario usuario, BE_Rol rol)
        {
            if(usuario != null && rol != null)
            {
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
        public List<BE_Rol> ObtenerFamiliaDelUsuario(string idUsuario)
        {
            List<BE_Rol> auxFamilias = new List<BE_Rol>();
            BE_Rol familia = ormRol.ObtenerFamiliaDelUsuario(idUsuario);
            auxFamilias.Add(familia);
            return auxFamilias;
        }
        public List<object> ObtenerTodosLosRoles()
        {
            return (from r in ormRol.ObtenerTodosLosRoles() select new { ID = r.Id_rol, TITULO = r.Titulo, ESTADO = r.Estado}).ToList<object>();
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
