using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BE_Usuario
    {
        string id_usuario;
        string nombre;
        string apellido;
        int dni;
        int edad;
        string email;
        string contraseña;
        string rol;
        bool activo;
        public string Id_usuario { get => id_usuario; set => id_usuario = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public int Dni { get => dni; set => dni = value; }
        public int Edad { get => edad; set => edad = value; }
        public string Email { get => email; set => email = value; }
        public string Contraseña { get => contraseña; set => contraseña = value; }
        public string Rol { get => rol; set => rol = value; }
        public bool Activo { get => activo; set => activo = value; }
        public BE_Usuario() { }
        public BE_Usuario(string idUsuario, string _nombre, string _apellido, int _dni, int _edad, string _email, string _contraseña, string _rol, bool _activo)
        {
            id_usuario = idUsuario;
            nombre = _nombre;
            apellido = _apellido;
            dni = _dni;
            edad = _edad;
            email = _email;
            contraseña = _contraseña;
            rol = _rol;
            activo = _activo;
        }
        public BE_Usuario(object[] datos) : this(datos[0].ToString(), datos[1].ToString(), datos[2].ToString(), Convert.ToInt32(datos[3]), Convert.ToInt32(datos[4]), datos[5].ToString(), datos[6].ToString(), datos[7].ToString(), Convert.ToBoolean(datos[8])) 
        { }
    }
}
