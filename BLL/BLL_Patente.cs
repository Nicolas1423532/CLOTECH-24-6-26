using BE;
using ORM;
using SERVICIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            if(patente != null)
            {
                ValidarDatosDePatente(patente);
                ormPatente.ModificarPatente(patente);
            }
        }
        public void AsignarPatenteAFamilia(BE_Patente patente, BE_Familia familia)
        {
            if(patente != null && familia != null)
            {
                if(patente.Titulo.Contains("Admin".ToUpper()) && !familia.Titulo.Contains("Administrador".ToUpper()))
                {
                    throw new Exception("No se puede asignar los permisos superiores a un usuario que no sea administrador");
                }
                ormPatente.AsignarPatenteAFamilia(patente, familia);
            }
        }
        public void AsignarPatenteARol(BE_Patente patente, BE_Rol rol)
        {
            if (patente != null && rol != null)
            {
                if (patente.Id_rol[0] != rol.Id_rol[0])
                {
                    throw new Exception("No se pueden asignar permisos que no correspondan al rol del usuario");
                }
                ormPatente.AsignarPatenteARol(patente, rol);
            }
        }
        public void DesasignarPatenteARol(BE_Patente patente, BE_Rol rol)
        {
            if (patente != null && rol != null)
            {
                ormPatente.DesasignarPatenteARol(patente, rol);
            }
        }
        public void DesasignarPatenteAFamilia(BE_Patente patente, BE_Familia familia)
        {
            if (patente != null && familia != null)
            {
                ormPatente.DesasignarPatenteAFamilia(patente, familia);
            }
        }
        public List<object> ObtenerTodasLasPatentes()
        {
            return (from p in ormPatente.ObtenerTodasLasPatentes() select new { ID = p.Id_rol, TITULO = p.Titulo}).ToList<object>();
        }
        private void ValidarDatosDePatente(BE_Patente patente)
        {
            if (string.IsNullOrWhiteSpace(patente.Id_rol) && string.IsNullOrWhiteSpace(patente.Titulo))
            {
                throw new Exception("Los datos del son incorrectos");
            }
        }
        private void ValidarIDPatente(BE_Patente patente)
        {
            string patron = @"^[AGCSE].*$";
            if (!Regex.IsMatch(patente.Id_rol, patron))
            {
                throw new Exception("El ID de la patente debe comenzar con A, G, C, S o E");
            }
        }
    }
}
