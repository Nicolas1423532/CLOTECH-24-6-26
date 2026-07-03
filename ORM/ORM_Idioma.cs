using DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM
{
    public class ORM_Idioma
    {
        private DAO_ dao;

        public ORM_Idioma()
        {
            dao = DAO_.ObtenerInstancia();
        }

        
        public void GuardarIdiomaUsuario(string idUsuario, string codigoIdioma)
        {
            DataRow? filaExistente =  dao.DtUsuarioXIdioma_.Rows.Find(idUsuario);

            if (filaExistente != null)
            {
                filaExistente["Id_Idioma"] = codigoIdioma;
            }
            else
            {
                DataRow nuevaFila = dao.DtUsuarioXIdioma_.NewRow();
                nuevaFila["Id_Usuario"] = idUsuario;
                nuevaFila["Id_Idioma"] = codigoIdioma;
                dao.DtUsuarioXIdioma_.Rows.Add(nuevaFila);
            }

            dao.GuardarCambios();
        }
        public string ObtenerIdiomaDelUsuario(string idUsuario)
        {
            string idioma = "es";
            DataRow? fila = dao.DtUsuarioXIdioma_.Rows.Find(idUsuario);
            if (fila != null) idioma =  fila.Field<string>("Id_Idioma") ?? "es";
            return idioma;
        }

    }
}
