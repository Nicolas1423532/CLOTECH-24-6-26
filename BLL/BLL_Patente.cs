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
            if(patente != null)
            {
                ValidarDatosDePatente(patente);
                ormPatente.ModificarPatente(patente);
            }
        }
        public void BorrarPatente(BE_Patente patente)
        {
            if(patente != null)
            {
                ormPatente.BorrarPatente(patente);
            }
        }
        public void ModificarPatente(BE_Patente patente)
        {
            ormPatente.ModificarPatente(patente);
        }
        public void AsignarPatente(BE_Patente patente, BE_Familia familia)
        {
            if(patente != null && familia != null)
            {
                ormPatente.AsignarPatente(patente, familia);
            }
        }
        public void DesasignarPatente(BE_Patente patente, BE_Familia familia)
        {
            if (patente != null && familia != null)
            {
                ormPatente.DesasignarPatente(patente, familia);
            }
        }
        public List<object> ObtenerTodasLasPatentes()
        {
            return (from p in ormPatente.ObtenerTodasLasPatentes() select new { ID = p.Id_rol, TITULO = p.Titulo, ESTADO = p.Estado}).ToList<object>();
        }
        private void ValidarDatosDePatente(BE_Patente patente)
        {
            if (string.IsNullOrWhiteSpace(patente.Id_rol) && string.IsNullOrWhiteSpace(patente.Titulo))
            {
                throw new Exception("Los datos del son incorrectos");
            }
        }
    }
}
