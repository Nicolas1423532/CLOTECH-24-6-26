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

        // ════════════════════════════════════════════════════════════════════
        // GuardarIdiomaUsuario
        //    Si el usuario ya tiene un registro en la tabla Idioma lo actualiza.
        //    Si no existe lo inserta.
        //    Se llama desde SERVICIO_Idioma.PersistirEnBD() al cerrar sesión.
        // ════════════════════════════════════════════════════════════════════
        public void GuardarIdiomaUsuario(string idUsuario, string codigoIdioma)
        {
            DataRow? filaExistente =  dao.DtUsuarioXIdioma_.Rows.Find(idUsuario);

            if (filaExistente != null)
            {
                // Ya existe un registro → actualizar el código
                filaExistente["Id_Idioma"] = codigoIdioma;
            }
            else
            {
                // No existe → insertar nuevo registro
                DataRow nuevaFila = dao.DtUsuarioXIdioma_.NewRow();
                nuevaFila["Id_Usuario"] = idUsuario;
                nuevaFila["Id_Idioma"] = codigoIdioma;
                dao.DtUsuarioXIdioma_.Rows.Add(nuevaFila);
            }

            dao.GuardarCambios();
        }

        // ════════════════════════════════════════════════════════════════════
        // ObtenerIdiomaUsuario
        //    Devuelve el código de idioma guardado para un usuario.
        //    Retorna "es" por defecto si no hay registro.
        //    Puede usarse en el futuro para cargar el idioma desde BD
        //    en vez de (o además de) desde JSON.
        // ════════════════════════════════════════════════════════════════════
        //public string ObtenerIdiomaUsuarioDesdeBD(string idUsuario)
        //{
        //    DataRow? fila = dao.DtIdioma.Rows.Find(idUsuario);

        //    if (fila != null)
        //        return fila.Field<string>("Codigo") ?? "es";

        //    return "es"; // valor por defecto
        //}
        public string ObtenerIdiomaDelUsuario(string idUsuario)
        {
            DataRow? fila = dao.DtUsuarioXIdioma_.Rows.Find(idUsuario);
            if (fila != null)
                return fila.Field<string>("Id_Idioma") ?? "es";
            return "es"; // si nunca guardó preferencia, español por defecto
        }

    }
}
