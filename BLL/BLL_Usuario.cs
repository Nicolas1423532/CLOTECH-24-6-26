using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using ORM;
using SERVICIO;
namespace BLL
{
    public class BLL_Usuario
    {
        ORM_Usuario ormUsuario;
        ORM_Rol ormRol;
        public BLL_Usuario()
        {
            ormUsuario = new ORM_Usuario();
            ormRol = new ORM_Rol();
        }
        public void AgregarUsuario(BE_Usuario usuario)
        {
            ormUsuario.AgregarUsuario(usuario);
        }
        public void ModificarUsuario(BE_Usuario usuario)
        {
            ormUsuario.ModificarUsuario(usuario);
        }
        public List<object> ObtenerTodosLosUsuarios()
        {
            return (from u in ormUsuario.ObtenerTodosLosUsuarios()
                    select new
                    {
                        Id_usuario = u.Id_usuario,
                        Nombre = u.Nombre,
                        Apellido = u.Apellido,
                        Dni = u.Dni,
                        Edad = u.Edad,
                        Email = u.Email,
                        //Contraseña = u.Contraseña,
                        Rol = u.Rol,
                        Activo = u.Activo
                    }).ToList<object>();
        }
        public bool Log_In(string email, string contraseña)
        {
            bool resultado = false;
            if (string.IsNullOrEmpty(contraseña)) { throw new Exception("El texto a cifrar no puede ser nulo o vacío."); }
            BE_Usuario usuario = ormUsuario.ObtenerUsuarioPorEmail(email);
            if (usuario == null) { resultado = false; }
            string contraseñaEncriptada = SERVICIO_Criptografia.Encriptar(contraseña);
            if(usuario!= null && usuario.Contraseña == contraseñaEncriptada)
            {
                SERVICIO_SesionUsuario.ObtenerInstancia().UsuarioActual = usuario;
                resultado = true;
                BE_Rol permisosUsuario = ormRol.ObtenerFamiliaDelUsuario(usuario.Id_usuario);
                if (permisosUsuario != null) { SERVICIO_SesionUsuario.ObtenerInstancia().FamiliaActual = permisosUsuario; } else { throw new Exception("Usuario sin rol"); }
            }
            else { resultado = false; }
            return resultado;
        }
        public void Log_Out(bool opcion)
        {
            if (opcion)
            {
                SERVICIO_SesionUsuario.ObtenerInstancia().UsuarioActual = null;
                SERVICIO_SesionUsuario.ObtenerInstancia().FamiliaActual = null;
            }
        }
        public bool LimiteIntentosLogIn(int cantidad)
        {
            bool resultado = false;
            if(cantidad >= 3)
            {
                resultado = true;
            }
            return resultado;
        }
    }
}
