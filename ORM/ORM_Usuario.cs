using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAO;
using ORM;
using System.Data;
namespace ORM
{
    public class ORM_Usuario
    {
        DAO_ dao;
        ORM_DV ormDV;
        public ORM_Usuario()
        {
            dao = DAO_.ObtenerInstancia();
            ormDV = new ORM_DV();
        }

        public void AgregarUsuario(BE_Usuario usuario)
        {
            DataRow filaExistente = dao.DtUsuario.Rows.Find(usuario.Id_usuario);
            if(filaExistente == null )
            {
                DataRow fila = dao.DtUsuario.NewRow();
                fila.ItemArray = new object[] { usuario.Id_usuario, usuario.Nombre, usuario.Apellido, usuario.Dni, usuario.Edad, usuario.Email, usuario.Contraseña, usuario.Rol, usuario.Activo };
                dao.DtUsuario.Rows.Add(fila);
                ormDV.ActualizarDVH(dao.DtUsuario);
                ormDV.ActualizarDVV(dao.DtUsuario,"Usuario","Id_Usuario");
                dao.GuardarCambios();

            }
        }
        public void ModificarUsuario(BE_Usuario usuario)
        {
            DataRow fila = dao.DtUsuario.Rows.Find(usuario.Id_usuario);
            if (fila != null)
            {
                fila.ItemArray = new object[] { fila.Field<string>(0), usuario.Nombre,usuario.Apellido, usuario.Dni,usuario.Edad, usuario.Email,usuario.Contraseña,usuario.Rol, usuario.Activo };
                ormDV.ActualizarDVH(dao.DtUsuario);
                ormDV.ActualizarDVV(dao.DtUsuario, "Usuario", "Id_Usuario");
                dao.GuardarCambios();
            }
        }
        public List<BE_Usuario> ObtenerTodosLosUsuariosActivos()
        {
            List<BE_Usuario> lstUsuarios = new List<BE_Usuario>();
            foreach (DataRow fila in dao.DtUsuario.Rows)
            {
                if (fila.Field<bool>("Activo"))
                {
                    lstUsuarios.Add(new BE_Usuario(fila.ItemArray));
                }
            }
            return lstUsuarios;
        }
        public List<BE_Usuario> ObtenerTodosLosUsuariosDesactivos()
        {
            List<BE_Usuario> lstUsuarios = new List<BE_Usuario>();
            foreach (DataRow fila in dao.DtUsuario.Rows)
            {
                if (!fila.Field<bool>("Activo"))
                {
                    lstUsuarios.Add(new BE_Usuario(fila.ItemArray));
                }
            }
            return lstUsuarios;
        }
        public void ActivarUsuario(BE_Usuario usuario)
        {
            DataRow filaDetectar = dao.DtUsuario.Rows.Find(usuario.Id_usuario);
            if (filaDetectar != null && !filaDetectar.Field<bool>("Activo"))
            {
                filaDetectar.SetField<bool>("Activo", true);
                ormDV.ActualizarDVH(dao.DtUsuario);
                ormDV.ActualizarDVV(dao.DtUsuario, "Usuario", "Id_Usuario");
            }
            else { throw new Exception("El usuario que quiere activar se encuentra activo"); }
            dao.GuardarCambios();
        }
        public void DesactivarUsuario(BE_Usuario usuario)
        {
            DataRow filaDetectar = dao.DtUsuario.Rows.Find(usuario.Id_usuario);
            if (filaDetectar != null && filaDetectar.Field<bool>("Activo"))
            {
                 filaDetectar.SetField<bool>("Activo", false);
                ormDV.ActualizarDVH(dao.DtUsuario);
                ormDV.ActualizarDVV(dao.DtUsuario, "Usuario", "Id_Usuario");
                dao.GuardarCambios();
            }
            else { throw new Exception("El usuario que quiere desactivar se encueesta inactivo."); }
        }
        public int TotalAdministradoresActivos()
        {
            int cantAdminEnUsuarios = 0;
            foreach (DataRow fila in dao.DtUsuario.Rows)
            {
                if (fila.Field<string>("Rol").ToUpper().Contains("ADMINISTRADOR") && fila.Field<bool>("Activo"))
                {
                    cantAdminEnUsuarios++;
                }
            }
            return cantAdminEnUsuarios;

        }
        public BE_Usuario? ObtenerUsuarioPorEmail(string email)
        {
            BE_Usuario usuario = ObtenerTodosLosUsuariosActivos().Find(u=> u.Email == email);
            if(usuario == null)
            {
                throw new Exception("El usuario esta desactivado o no existe en el sistema");
            }
            return usuario;
        }
    }
}
