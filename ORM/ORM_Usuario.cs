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
            DataRow fila = dao.DtUsuario.NewRow();
            fila.ItemArray = new object[] { usuario.Id_usuario, usuario.Nombre, usuario.Apellido, usuario.Dni, usuario.Edad, usuario.Email, usuario.Contraseña, usuario.Rol, usuario.Activo };
            dao.DtUsuario.Rows.Add(fila);
            dao.GuardarCambios();
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
        public List<BE_Usuario> ObtenerTodosLosUsuarios()
        {
            List<BE_Usuario> lstUsuarios = new List<BE_Usuario>();
            foreach (DataRow fila in dao.DtUsuario.Rows)
            {
                lstUsuarios.Add(new BE_Usuario(fila.ItemArray));
            }
            return lstUsuarios;
        }
        public BE_Usuario? ObtenerUsuarioPorEmail(string email)
        {
            BE_Usuario usuario = ObtenerTodosLosUsuarios().Find(u=> u.Email == email);
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
