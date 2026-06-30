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
        public void AgregarBitacora(string idBitacora, string logIn, string evento, string modulo, int criticidad, DateTime fecha)
        {
            ormBitacora.AgregarBitacora(idBitacora, logIn, evento, modulo, criticidad, fecha);
        }
        public List<object> ObtenerTodasLasBitacoras()
        {
            return (from b in ormBitacora.ObtenerTodasLasBitacoras() select new { LOG_IN = b.LogIn, EVENTO = b.Evento, MODULO = b.Modulo, CRITICIDAD = b.Criticidad, FECHA = b.Fecha}).ToList<object>();
        }
    }
}
