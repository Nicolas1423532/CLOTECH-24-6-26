using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ORM;
using BE;
namespace BLL
{
    public class BLL_Bitacora
    {
        ORM_Bitacora ormBitacora;
        public BLL_Bitacora()
        {
            ormBitacora = new ORM_Bitacora();
        }
        public void AgregarBitacora(string idBitacora, string logIn, string evento, string modulo, int criticidad, DateTime fecha, TimeSpan horario)
        {
            ormBitacora.AgregarBitacora(idBitacora, logIn, evento, modulo, criticidad, fecha, horario);
        }
        public List<object> ObtenerTodasLasBitacoras()
        {
            return (from b in ormBitacora.ObtenerTodasLasBitacoras() select new { LOG_IN = b.LogIn, EVENTO = b.Evento, MODULO = b.Modulo, CRITICIDAD = b.Criticidad, FECHA = b.Fecha}).ToList<object>();
        }
        public List<object> ObtenerBitacorasFiltradas(string email, string modulo, string evento, int? criticidad, DateTime fechaIni, DateTime fechaFin)
        {
            var todasLasBitacoras = ormBitacora.ObtenerTodasLasBitacoras();

            var filtradas = todasLasBitacoras.Where(b =>
                (b.Fecha.Date >= fechaIni.Date && b.Fecha.Date <= fechaFin.Date) &&

                (string.IsNullOrEmpty(email) || b.LogIn.Trim().ToLower() == email.Trim().ToLower()) &&
                (string.IsNullOrEmpty(modulo) || b.Modulo.Trim().ToLower() == modulo.Trim().ToLower()) &&
                (string.IsNullOrEmpty(evento) || b.Evento.Trim().ToLower() == evento.Trim().ToLower()) &&
                (!criticidad.HasValue || b.Criticidad == criticidad.Value)
            );

            return (from b in filtradas
                    select new
                    {
                        LOG_IN = b.LogIn,
                        EVENTO = b.Evento,
                        MODULO = b.Modulo,
                        CRITICIDAD = b.Criticidad,
                        FECHA = b.Fecha.ToShortDateString()
                    }).ToList<object>();
}
    }
}
