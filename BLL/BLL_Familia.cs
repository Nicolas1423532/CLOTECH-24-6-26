using BE;
using ORM;
using SERVICIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BLL
{
    public class BLL_Familia
    {
        ORM_Familia ormFamilia;
        ORM_Usuario ormUsuario;
        ORM_Bitacora ormBitacora;
        BE_Usuario usuarioActual = SERVICIO_SesionUsuario.ObtenerInstancia().UsuarioActual;
        public BLL_Familia()
        {
            ormFamilia = new ORM_Familia();
            ormUsuario = new ORM_Usuario();
            ormBitacora = new ORM_Bitacora();
        }
        public void AgregarFamilia(BE_Familia familia)
        {
            ValidarDatosDeFamilia(familia);
            if(familia != null)
            {
                var idBitacora = SERVICIO_Criptografia.GenerarIDBitacora();
                ormFamilia.AgregarFamilia(familia);
                ormBitacora.AgregarBitacora(idBitacora, usuarioActual.Email, "Agregar Familia", "Gestion de Familia", 2, DateTime.Now);
            }
        }
        public void BorrarFamilia(BE_Familia familia)
        {
            if(familia != null)
            {
                ormFamilia.BorrarFamilia(familia);
            }
        }
        public void ModificarFamilia(BE_Familia familia)
        {
            if (familia != null)
            {
                List<BE_Familia> todasLasFamilias = ormFamilia.ObtenerTodasLasFamilias();
                BE_Familia familiaExistente = todasLasFamilias.Find(f => f.Id_rol == familia.Id_rol);

                if (familiaExistente == null)
                {
                    throw new Exception("La familia que intenta modificar no existe en el sistema.");
                }
                string tituloNuevo = familia.Titulo.ToUpper();
                string tituloViejo = familiaExistente.Titulo.ToUpper();

                if (tituloViejo.Contains("MENU") && !tituloNuevo.Contains("MENU"))
                {
                    throw new Exception("No se puede remover la palabra 'MENU' de una familia configurada como contenedor de interfaz.");
                }
                ValidarDatosDeFamilia(familia);
                ormFamilia.ModificarFamilia(familia);
                var idBitacora = SERVICIO_Criptografia.GenerarIDBitacora();
                ormBitacora.AgregarBitacora(idBitacora, usuarioActual.Email, "Modificar Familia", "Gestion de Familia", 2, DateTime.Now);
            }
        }
        public void AsignarFamilia(BE_Usuario usuario,BE_Rol rol, BE_Familia familia)
        {
            if (usuario != null && rol != null && familia != null)
            {
                string tituloFamilia = familia.Titulo.ToUpper();
                string perfilUsuario = usuario.Rol.ToUpper();

                if (tituloFamilia.Contains("ADMINISTRADOR"))
                {
                    if (perfilUsuario != "ADMINISTRADOR")
                    {
                        throw new Exception($"Restricción de seguridad: Un usuario con perfil '{usuario.Rol}' no puede recibir permisos de una familia de tipo 'Administrador'.");
                    }
                }
                ormFamilia.AsignarFamilia(usuario,rol, familia);
            }
        }
        public void DesasignarFamilia(BE_Rol rol, BE_Familia familia)
        {
            if (rol!=null && familia != null)
            {
                ormFamilia.DesasignarFamilia(rol, familia);
            }
            //if (familia.Titulo.ToUpper().Contains("MENU"))
            //{
            //    BE_Usuario usuarioActual = SERVICIO_SesionUsuario.ObtenerInstancia().UsuarioActual;

            //    if (usuarioActual != null && usuarioActual.Rol.ToUpper() == "ADMINISTRADOR")
            //    {
            //        int adminsActivos = ormUsuario.ObtenerTodosLosUsuariosActivos().Count(u => u.Rol.ToUpper() == "ADMINISTRADOR");
            //        if (adminsActivos <= 1)
            //        {
            //            throw new Exception("Operación denegada por seguridad: No se puede desasignar un menú al único Administrador activo del sistema.");
            //        }
            //    }
            //}

        }
        public void AsignarSubfamilia(BE_Familia familiaPadre, BE_Familia subFamilia)
        {
            if (familiaPadre != null && subFamilia != null)
            {
                string tituloPadre = familiaPadre.Titulo.ToUpper();
                string tituloHija = subFamilia.Titulo.ToUpper();

                if (tituloPadre.Contains("MENU") && tituloHija.Contains("MENU"))
                {
                    throw new Exception("Una familia de tipo 'MENU' no puede contener otra subfamilia de tipo 'MENU'.");
                }
                if (familiaPadre.Id_rol == subFamilia.Id_rol)
                {
                    throw new Exception("No es posible asignar una Familia como subfamilia de sí misma.");
                }
                ormFamilia.AsignarSubfamilia(familiaPadre, subFamilia);
            }
        }
        public void DesasignarSubfamilia(BE_Familia familiaPadre, BE_Familia subFamilia)
        {
            //if (subFamilia.Titulo.ToUpper().Contains("MENU"))
            //{
            //    BE_Usuario usuarioActual = SERVICIO_SesionUsuario.ObtenerInstancia().UsuarioActual;

            //    if (usuarioActual != null && usuarioActual.Rol.ToUpper() == "ADMINISTRADOR")
            //    {
            //        int adminsActivos = ormUsuario.ObtenerTodosLosUsuariosActivos().Count(u => u.Rol.ToUpper() == "ADMINISTRADOR");

            //        if (adminsActivos <= 1)
            //        {
            //            throw new Exception("Operación denegada por seguridad: No se puede desasignar una subfamilia de menú al único Administrador activo del sistema.");
            //        }
            //    }
            //}
            if(familiaPadre !=null && subFamilia != null)
            {
                ormFamilia.DesasignarSubfamilia(familiaPadre, subFamilia);
            }
        }
        public List<object> ObtenerTodasLasFamilias()
        {
            return (from f in ormFamilia.ObtenerTodasLasFamilias() select new { ID = f.Id_rol, Titulo =  f.Titulo, Estado = f.Estado }).ToList<object>();
        }
        private void ValidarDatosDeFamilia(BE_Familia familia)
        {
            if (string.IsNullOrWhiteSpace(familia.Id_rol) && string.IsNullOrWhiteSpace(familia.Titulo))
            {
                throw new Exception("Los datos del son incorrectos");
            }
        }
    }
}
