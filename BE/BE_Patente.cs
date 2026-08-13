using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BE_Patente : BE_Rol
    {
        public override List<BE_Rol> RetornarComponentes()
        {
            return new List<BE_Rol> { this };
        }
        public BE_Patente() { }
        public BE_Patente(object[] datos)
        {
            this.Id_rol = datos[0].ToString();
            this.Titulo = datos[1].ToString();
        }
    }
}
