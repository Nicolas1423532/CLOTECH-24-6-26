using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ORM;
using BE;
namespace BLL
{
    public class BLL_Rol
    {
        ORM_Rol ormRol;
        public BLL_Rol()
        {
            ormRol = new ORM_Rol();
        }
        public void AgregarRol(BE_Rol rol)
        {
            ormRol.AgregarRol(rol);
        }
        public void BorrarRol(BE_Rol rol)
        {
            
        }
        public void ModificarRol(BE_Rol rol)
        {
            ormRol.ModificarRol(rol);
        }
        public List<BE_Rol> ObtenerFamiliaDelUsuario(string idUsuario)
        {
            List<BE_Rol> auxFamilias = new List<BE_Rol>();
            BE_Rol familia = ormRol.ObtenerFamiliaDelUsuario(idUsuario);
            auxFamilias.Add(familia);
            return auxFamilias;
        }
    }
}
