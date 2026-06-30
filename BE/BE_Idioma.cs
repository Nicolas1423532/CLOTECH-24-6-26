using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BE_Idioma
    {
        string id_Idioma;
        string nombre;
        public string Id_Idioma { get => id_Idioma; set => id_Idioma = value; } 
        public string Nombre { get => nombre; set => nombre = value; }
        public BE_Idioma(string id, string pNombre)
        {
            id_Idioma = id;
            nombre = pNombre;
        }
        public override string ToString() => Nombre;
    }
}
