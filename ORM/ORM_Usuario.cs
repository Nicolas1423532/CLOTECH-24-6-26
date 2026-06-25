using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAO;
using System.Data;
namespace ORM
{
    public class ORM_Usuario
    {
        DAO_ dao;
        public ORM_Usuario()
        {
            dao = DAO_.ObtenerInstancia();
        }

        public void AgregarUsuario(BE_Usuario usuario)
        {
            DataRow filaExistente = dao.DtUsuario.Rows.Find(usuario.Id_usuario);
            if(filaExistente == null )
            {
                DataRow fila = dao.DtUsuario.NewRow();
                fila.ItemArray = new object[] { usuario.Id_usuario, usuario.Nombre, usuario.Apellido, usuario.Dni, usuario.Edad, usuario.Email, usuario.Contraseña, usuario.Rol, usuario.Activo };
                dao.DtUsuario.Rows.Add(fila);
                dao.GuardarCambios();

            }
        }
        public void ModificarUsuario(BE_Usuario usuario)
        {
            DataRow fila = dao.DtUsuario.Rows.Find(usuario.Id_usuario);
            if (fila != null)
            {
                fila.ItemArray = new object[] { fila.Field<string>(0), usuario.Nombre, usuario.Apellido, usuario.Dni, usuario.Edad, usuario.Email, usuario.Contraseña, usuario.Rol, usuario.Activo };
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
            }
            else { throw new Exception("El usuario ya esta activo"); }
                dao.GuardarCambios();
        }
        public void DesactivarUsuario(BE_Usuario usuario)
        {
            DataRow filaDetectar = dao.DtUsuario.Rows.Find(usuario.Id_usuario);
            int cantAdmins = TotalAdministradoresActivos();
            if(cantAdmins > 1)
            {
                if (filaDetectar != null && filaDetectar.Field<bool>("Activo"))
                {
                    filaDetectar.SetField<bool>("Activo", false);
                }
                else { throw new Exception("El usuario ya esta desactivo"); }
                dao.GuardarCambios();
            }
            else { throw new Exception("No se puede desactivar un administrador si solo existe uno. Agregue otro administrador"); }
        }
        private int TotalAdministradoresActivos()
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
        public BE_Usuario? ObtenerUsuarioPorEmail(string email)
        {
            BE_Usuario usuario = ObtenerTodosLosUsuariosActivos().Find(u=> u.Email == email);
            if(usuario == null)
            {
                throw new Exception("El usuario esta desactivado");
            }
            //DataRow fila = dao.DtUsuario.AsEnumerable().FirstOrDefault(u => u.Field<string>("Email") == email);
            //DataRow fila = dao.DtUsuario.Rows.Find(email);
            //if (fila != null)
            //{
            //    usuario = new BE_Usuario(fila.ItemArray);
            //}
            return usuario;
        }
    }
}
