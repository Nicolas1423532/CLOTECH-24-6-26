using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BE_Patente : BE_Rol
    {
        //string? id_patente;
        //string? titulo;
        //bool estado;
        //public string Id_patente { get => id_patente; set => id_patente = value; }
        //public string Titulo { get => titulo; set => titulo = value; }
        //public bool Estado { get => estado; set => estado = value; }

        public override List<BE_Rol> RetornarComponentes()
        {
            return new List<BE_Rol> { this };
        }
        public BE_Patente() { }
        public BE_Patente(object[] datos)
        {
            this.Id_rol = datos[0].ToString();
            this.Titulo = datos[1].ToString();
            this.Estado = Convert.ToBoolean(datos[2]);
        }
    }
}
