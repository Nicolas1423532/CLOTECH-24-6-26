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
    public class BLL_Usuario
    {
        ORM_Usuario ormUsuario;
        ORM_Rol ormRol;
        ORM_Bitacora ormBitacora;
        BLL_Idioma idiomaBll;
        public BLL_Usuario()
        {
            ormUsuario = new ORM_Usuario();
            ormRol = new ORM_Rol();
            ormBitacora = new ORM_Bitacora();
            idiomaBll = new BLL_Idioma();
        }
        public void AgregarUsuario(BE_Usuario usuario)
        {
            if (usuario != null)
            {
                ValidarDatosDelUsuario(usuario);
                EstablecerFormatoCorreoContraBase(usuario);
                var idBitacora = SERVICIO_Criptografia.GenerarIDBitacora();
                ormBitacora.AgregarBitacora(idBitacora, usuario.Email, "Registrar Usuario", "Administracion", 1 ,DateTime.Now);
                ormUsuario.AgregarUsuario(usuario);
            }
        }
        public void EstablecerFormatoCorreoContraBase(BE_Usuario usuario)
        {
            string patronEmail = @"^[a-z]+clotech@gmail\.com$";
            string patronPassword = @"^[a-z]+[0-9]{7,8}$";
            string nombreUsuarioMinuscula = usuario.Nombre.ToLower();
            string apellidoUsuarioMinuscula = usuario.Apellido.ToLower();
            string emailBase = $"{nombreUsuarioMinuscula}{apellidoUsuarioMinuscula}clotech@gmail.com";
            string contraseñaBase = $"{apellidoUsuarioMinuscula}{usuario.Dni}";
            bool emailValido = Regex.IsMatch(emailBase, patronEmail);
            bool contraValida = Regex.IsMatch(contraseñaBase, patronPassword);
            if(emailValido && contraValida)
            {
                usuario.Email = emailBase;
                usuario.Contraseña = SERVICIO_Criptografia.Encriptar(contraseñaBase);
            }
            else { throw new Exception("Error en formato email y contraseña "); }
        }
        public void ModificarUsuario(BE_Usuario usuario)
        {
            if(usuario != null)
            {
                List<BE_Usuario> todos = ormUsuario.ObtenerTodosLosUsuariosActivos();
                BE_Usuario actual = todos.Find(u => u.Id_usuario == usuario.Id_usuario);
                if (actual != null && actual.Rol.ToUpper().Contains("ADMINISTRADOR"))
                {
                    if (ormUsuario.TotalAdministradoresActivos() <= 1)
                    {
                        throw new Exception("No se puede modificar un administrador si solo existe uno. Agregue otro administrador");
                    }
                }
                EstablecerFormatoCorreoContraBase(usuario);
                ValidarDatosDelUsuario(usuario);
                ormUsuario.ModificarUsuario(usuario);
            }
        }
        public List<object> ObtenerTodosLosUsuariosActivos()
        {
            return (from u in ormUsuario.ObtenerTodosLosUsuariosActivos()
                    select new
                    {
                        Id_usuario = u.Id_usuario,
                        Nombre = u.Nombre,
                        Apellido = u.Apellido,
                        Dni = u.Dni,
                        Edad = u.Edad,
                        Email = u.Email,
                        Rol = u.Rol,
                        Activo = u.Activo
                    }).ToList<object>();
        }
        public List<object> ObtenerTodosLosUsuariosDesactivos()
        {
            return (from u in ormUsuario.ObtenerTodosLosUsuariosDesactivos()
                    select new
                    {
                        Id_usuario = u.Id_usuario,
                        Nombre = u.Nombre,
                        Apellido = u.Apellido,
                        Dni = u.Dni,
                        Edad = u.Edad,
                        Email = u.Email,
                        Rol = u.Rol,
                        Activo = u.Activo
                    }).ToList<object>();
        }
        public void ActivarUsuario(BE_Usuario usuario)
        {
            if (usuario != null)
            {
                ormUsuario.ActivarUsuario(usuario);
            }
        }
        public void DesactivarUsuario(BE_Usuario usuario)
        {
            List<BE_Usuario> todos = ormUsuario.ObtenerTodosLosUsuariosActivos();
            BE_Usuario actual = todos.Find(u => u.Id_usuario == usuario.Id_usuario);

            if (actual != null && actual.Rol.ToUpper().Contains("ADMINISTRADOR"))
            {
                if (ormUsuario.TotalAdministradoresActivos() <= 1)
                {
                    throw new Exception("No se puede desactivar un administrador si solo existe uno. Agregue otro administrador");
                }
            }
            ormUsuario.DesactivarUsuario(usuario);
        }
        public bool Log_In(string email, string contraseña)
        {
            bool resultado = false;
            string idBitacora = SERVICIO_Criptografia.GenerarIDBitacora();
            if (string.IsNullOrEmpty(contraseña)) { throw new Exception("El texto a cifrar no puede ser nulo o vacío."); }
            if (string.IsNullOrEmpty(email)) { throw new Exception("El correo no puede estar vacío"); }
            BE_Usuario usuario = ormUsuario.ObtenerUsuarioPorEmail(email);
            if (usuario == null) { resultado = false; }
            string contraseñaEncriptada = SERVICIO_Criptografia.Encriptar(contraseña);
            if(usuario!= null && usuario.Contraseña == contraseñaEncriptada)
            {
                SERVICIO_SesionUsuario.ObtenerInstancia().UsuarioActual = usuario;
                resultado = true;
                ormBitacora.AgregarBitacora(idBitacora, usuario.Email, "Log In", "Usuario", 1,DateTime.Now);
                BE_Rol permisosUsuario = ormRol.ObtenerFamiliaDelUsuario(usuario.Id_usuario);
                if (permisosUsuario != null) { SERVICIO_SesionUsuario.ObtenerInstancia().FamiliaActual = permisosUsuario; } else { throw new Exception("Usuario sin rol"); }
            }
            else { resultado = false; }
            return resultado;
        }
        private void ValidarDatosDelUsuario(BE_Usuario usuario)
        {
            string patronDni = @"^\d{7,8}$";
            string dniUsuario = usuario.Dni.ToString();
            if (string.IsNullOrWhiteSpace(usuario.Id_usuario) || Information.IsNumeric(usuario.Nombre) || Information.IsNumeric(usuario.Apellido) || !Regex.IsMatch(dniUsuario,patronDni) || !Information.IsNumeric(usuario.Edad))
            {
                throw new Exception("Los datos de usuario son incorrectos");
            }

        }
        public void Log_Out(bool opcion)
        {
            if (opcion)
            {
                var idBitacoraLogOut = SERVICIO_Criptografia.GenerarIDBitacora();
                string emailUsuario = SERVICIO_SesionUsuario.ObtenerInstancia().UsuarioActual.Email;
                string idUsuario = SERVICIO_SesionUsuario.ObtenerInstancia().UsuarioActual.Id_usuario;
                ormBitacora.AgregarBitacora(idBitacoraLogOut, emailUsuario, "Log Out", "Usuario", 2, DateTime.Now);
                idiomaBll.GuardarIdiomaUsuario(idUsuario);
                SERVICIO_Idioma.ObtenerInstancia().GuardarEnJson();
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
        public void CambiarContraseña(string email, string contraActual, string contraNueva)
        {
            if (string.IsNullOrWhiteSpace(contraActual) || string.IsNullOrWhiteSpace(contraNueva))
            {
                throw new Exception("Los campos de contraseña no pueden estar vacíos.");
            }
            BE_Usuario usuario = ormUsuario.ObtenerUsuarioPorEmail(email);
            if (usuario == null)
            {
                throw new Exception("El usuario no existe o se encuentra desactivado.");
            }
            string contraActualEncriptada = SERVICIO_Criptografia.Encriptar(contraActual);
            if (usuario.Contraseña != contraActualEncriptada)
            {
                throw new Exception("La contraseña actual ingresada es incorrecta.");
            }
            usuario.Contraseña = SERVICIO_Criptografia.Encriptar(contraNueva);
            ormUsuario.ModificarUsuario(usuario);
            var idBitacora = SERVICIO_Criptografia.GenerarIDBitacora();
            ormBitacora.AgregarBitacora(idBitacora, usuario.Email, "Cambio de Contraseña", "Usuario", 2, DateTime.Now);
        }
    }
}
