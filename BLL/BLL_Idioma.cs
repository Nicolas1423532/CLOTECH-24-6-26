using Microsoft.VisualBasic;
using ORM;
using SERVICIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLL_Idioma
    {
        ORM_Idioma ormIdioma;
        ORM_Bitacora ormBitacora;
        public BLL_Idioma()
        {
            ormIdioma = new ORM_Idioma();
            ormBitacora = new ORM_Bitacora();
        }

        // ════════════════════════════════════════════════════════════════════
        // GuardarIdiomaUsuario
        //    Toma el idioma activo desde SERVICIO_Idioma (memoria)
        //    y lo persiste en la tabla Idioma de la BD mediante ORM_Idioma.
        //    Se llama desde el logout, junto a GuardarEnJson() del servicio.
        //
        //    Flujo completo del logout:
        //      VISTA
        //        ├─ SERVICIO_Idioma.GuardarEnJson()          → escribe idioma.json
        //        └─ BLL_Idioma.GuardarIdiomaUsuario(id)      → escribe tabla Idioma en BD
        //              └─ ORM_Idioma.GuardarIdiomaUsuario()  → upsert en DataTable → DAO
        // ════════════════════════════════════════════════════════════════════
        public void GuardarIdiomaUsuario(string idUsuario)
        {
            if (string.IsNullOrWhiteSpace(idUsuario))
                throw new Exception("No se puede guardar el idioma: el ID de usuario es inválido.");
            if(Information.IsNumeric(idUsuario)) { throw new Exception("El ID no puede ser numerico"); }
            string emailUsuario = SERVICIO_SesionUsuario.ObtenerInstancia().UsuarioActual.Email;
            string idBitacoraIdioma = SERVICIO_Criptografia.GenerarIDBitacora();
            ormBitacora.AgregarBitacora(idBitacoraIdioma, emailUsuario, "Guardado de idioma", "Idioma", 3, DateTime.Now);
            // Leer el idioma actual desde memoria (no de BD)
            string codigoIdioma = SERVICIO_Idioma.ObtenerInstancia().ObtenerIdiomaActual();

            // Persistir en BD
            ormIdioma.GuardarIdiomaUsuario(idUsuario, codigoIdioma);
        }
        public string ObtenerIdiomaDelUsuario(string idUsuario)
        {
            if (string.IsNullOrWhiteSpace(idUsuario))
                throw new Exception("ID de usuario inválido.");

            return ormIdioma.ObtenerIdiomaDelUsuario(idUsuario);
        }
    }
}
