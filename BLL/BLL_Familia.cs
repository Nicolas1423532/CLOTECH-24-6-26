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
            if(familia != null)
            {
                ormFamilia.AgregarFamilia(familia);
            }
        }
        public void BorrarFamilia(BE_Familia familia)
        {
            if(familia != null)
            {
                ormFamilia.BorrarFamilia(familia);
            }
        }
        public void ModificarFamilia(BE_Familia familia)
        {
            if (familia != null)
            {
                ormFamilia.ModificarFamilia(familia);
            }
        }
        public void Asignar(object nodoSeleccionado,BE_Usuario usuario, BE_Familia familia)
        {
            if (nodoSeleccionado.GetType() == typeof(BE_Rol))
            {
                AsignarFamilia(usuario, (BE_Rol)nodoSeleccionado, familia);
            }
            else if (nodoSeleccionado.GetType() == typeof(BE_Familia))
            {
                AsignarSubfamilia((BE_Familia)nodoSeleccionado, familia);
            }
        }
        public void Desasignar(object nodoSeleccionado, BE_Familia familia)
        {
            if (nodoSeleccionado.GetType() == typeof(BE_Rol))
            {
                DesasignarFamilia(nodoSeleccionado as BE_Rol, familia);
            }
            else if (nodoSeleccionado.GetType() == typeof(BE_Familia))
            {
                DesasignarSubfamilia(nodoSeleccionado as BE_Familia, familia);
            }
        }
        public void AsignarFamilia(BE_Usuario usuario,BE_Rol rol, BE_Familia familia)
        {
            if (usuario != null && rol != null && familia != null)
            {
                ormFamilia.AsignarFamilia(usuario, rol, familia);
            }
        }
        public void DesasignarFamilia(BE_Rol rol, BE_Familia familia)
        {
            if (rol!=null && familia != null)
            {
                ormFamilia.DesasignarFamilia(rol, familia);
            }
        }
        public void AsignarSubfamilia(BE_Familia familiaPadre, BE_Familia subFamilia)
        {
            if (familiaPadre != null && subFamilia != null)
            {
                string tituloPadre = familiaPadre.Titulo.ToUpper();
                string tituloHija = subFamilia.Titulo.ToUpper();

                if (tituloPadre.Contains("MENU") && tituloHija.Contains("MENU"))
                {
                    throw new Exception("Una familia de tipo 'MENU' no puede contener otra subfamilia de tipo 'MENU'.");
                }
                if (familiaPadre.Id_rol == subFamilia.Id_rol)
                {
                    throw new Exception("No es posible asignar una Familia como subfamilia de sí misma.");
                }
                ormFamilia.AsignarSubfamilia(familiaPadre, subFamilia);
            }
        }
        public void DesasignarSubfamilia(BE_Familia familiaPadre, BE_Familia subFamilia)
        {
            if(familiaPadre!=null && subFamilia != null)
            {
                ormFamilia.DesasignarSubfamilia(familiaPadre, subFamilia);
            }
        }
        public List<object> ObtenerTodasLasFamilias()
        {
            return (from f in ormFamilia.ObtenerTodasLasFamilias() select new { ID = f.Id_rol, Titulo =  f.Titulo, Estado = f.Estado }).ToList<object>();
        }
    }
}
