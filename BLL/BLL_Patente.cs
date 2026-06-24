using BE;
using ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLL_Patente
    {
        ORM_Patente ormPatente;
        public BLL_Patente()
        {
            ormPatente = new ORM_Patente();
        }
        public void AgregarPatente(BE_Patente patente)
        {
            ormPatente.AgregarPatente(patente);
        }
        public void BorrarPatente(BE_Patente patente)
        {
            ormPatente.BorrarPatente(patente);
        }
        public void ModificarPatente(BE_Patente patente)
        {
            ormPatente.ModificarPatente(patente);
        }
        public List<object> ObtenerTodasLasPatentes()
        {
            return (from p in ormPatente.ObtenerTodasLasPatentes() select new { ID = p.Id_rol, TITULO = p.Titulo, ESTADO = p.Estado}).ToList<object>();
        }
    }
}
