using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ORM;
using BE;
namespace BLL
{
    public class BLL_Familia
    {
        ORM_Familia ormFamilia;
        public BLL_Familia()
        {
            ormFamilia = new ORM_Familia();
        }
        public void AgregarFamilia(BE_Familia familia)
        {
            ormFamilia.AgregarFamilia(familia);
        }
        public void BorrarFamilia(BE_Familia familia)
        {
            ormFamilia.BorrarFamilia(familia);
        }
        public void ModificarFamilia(BE_Familia familia)
        {
            ormFamilia.ModificarFamilia(familia);
        }
        public List<object> ObtenerTodasLasFamilias()
        {
            return (from f in ormFamilia.ObtenerTodasLasFamilias() select new { ID = f.Id_rol, Titulo =  f.Titulo, Estado = f.Estado }).ToList<object>();
        }
    }
}
