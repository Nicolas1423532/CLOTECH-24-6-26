using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public abstract class BE_Rol
    {
        string? id_rol;
        string? titulo;
        bool estado;
        public string Id_rol { get => id_rol; set => id_rol = value; }
        public string Titulo { get => titulo; set => titulo = value; }
        public bool Estado { get => estado; set => estado = value; }
        public abstract List<BE_Rol> RetornarComponentes(); 
    }
}
