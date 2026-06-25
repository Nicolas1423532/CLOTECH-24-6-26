using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ORM;
using BE;
namespace BLL
{
    public class BLL_Rol
    {
        ORM_Rol ormRol;
        public BLL_Rol()
        {
            ormRol = new ORM_Rol();
        }
        public void AgregarRol(BE_Rol rol)
        {
            if (ormRol.TotalAdministradoresActivos() <= 0)
            {
                throw new Exception("Operación inválida: El sistema requiere al menos un rol de Administrador configurado.");
            }
            ormRol.AgregarRol(rol);
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
            ormRol.ModificarRol(rol);
        }
        public void Asignar(BE_Usuario usuario, BE_Rol rol)
        {
            ormRol.Asignar(usuario,rol);
        }
        public void Desasignar(BE_Usuario usuario, BE_Rol rol)
        {
            if(ormRol.TotalAdministradoresActivos() > 0)
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
    }
}
