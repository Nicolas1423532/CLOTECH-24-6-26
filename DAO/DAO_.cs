using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DAO
{
    public class DAO_
    {
        SqlConnection conexion;
        DataSet ds;
        DataTable dtUsuario, dtProducto, dtCliente, dtProveedor, dtFactura, dtDetalle, dtBitacora,dtDevolucion, dtDevolucionDetalle, dtOrdenCompra, dtOrdenCompraDetalle, dtIdioma,dtUsuarioXIdioma, dtRol, dtFamilia, dtPatente, dtRolXFamilia,dtFamiliaXFamilia,dtRolXPatente,dtPatenteXFamilia, dtUsuarioXRol;
        public DataTable DtUsuario { get => dtUsuario; set => dtUsuario = value; }
        public DataTable DtBitacora { get => dtBitacora; set=> dtBitacora = value; }
        public DataTable DtProducto { get => dtProducto; set => dtProducto = value; }
        public DataTable DtCliente { get => dtCliente; set => dtCliente = value; }
        public DataTable DtProveedor { get => dtProveedor; set => dtProveedor = value; }
        public DataTable DtFactura { get => dtFactura; set => dtFactura = value; }
        public DataTable DtDetalle { get => dtDetalle; set => dtDetalle = value; }
        public DataTable DtUsuarioXRol { get => dtUsuarioXRol; set=> dtUsuarioXRol = value; }
        public DataTable DtRol { get => dtRol; set => dtRol = value; }
        public DataTable DtFamilia { get => dtFamilia; set => dtFamilia = value; }
        public DataTable DtPatente { get => dtPatente; set => dtPatente = value; }
        public DataTable DtRolXFamilia { get => dtRolXFamilia; set => dtRolXFamilia = value; }
        public DataTable DtFamiliaXFamilia { get => dtFamiliaXFamilia; set => dtFamiliaXFamilia = value; }
        public DataTable DtRolXPatente { get => dtRolXPatente; set => dtRolXPatente = value; }
        public DataTable DtIdioma { get => dtIdioma; set => dtIdioma = value; }
        public DataTable DtUsuarioXIdioma_ { get => dtUsuarioXIdioma; set=> dtUsuarioXIdioma = value; }
        public DataTable DtPatenteXFamilia { get => dtPatenteXFamilia; set => dtPatenteXFamilia = value; }
        SqlDataAdapter adapUsuario, adapBitacora,adapProducto, adapCliente, adapProveedor, adapFactura, adapDetalle, adapDevolucion, adapDevolucionDetalle, adapOrdenCompra, adapOrdenCompraDetalle, adapIdioma, adapUsuarioXIdioma,adapUsuarioXRol,adapRol, adapFamilia, adapPatente, adapRolXFamilia, adapFamiliaXFamilia,adapRolXPatente,adapPatenteXFamilia;
        SqlCommandBuilder? cmbUsuario, cmbBitacora,cmbProducto, cmbCliente, cmbProveedor, cmbFactura, cmbDetalle, cmbDevolucion, cmbDevolucionDetalle, cmbOrdenCompra, cmbOrdenCompraDetalle,cmbIdioma,cmbUsuarioXIdioma,cmbUsuarioXRol ,cmbRol, cmbFamilia, cmbPatente, cmbRolXFamilia, cmbRolXPatente, cmbFamiliaXFamilia, cmbPatenteXFamilia;
        DataRelation relUsuario_A_Rol,relRol_A_Usuario,relRolAFamilia, relFamiliaAlRol, relFamiliaAPatente,relPatenteAFamilia, relFamiliaPadre_A_SubFamilia, relFamiliaHija_A_FamiliaPadre;
        public DataRelation RelRolAFamilia { get => relRolAFamilia; set => relRolAFamilia = value; }
        public DataRelation RelFamiliaAlRol { get => relFamiliaAlRol; set => relFamiliaAlRol = value; }
        public DataRelation RelFamiliaAPatente { get => relFamiliaAPatente; set => relFamiliaAPatente = value; }
        public DataRelation RelFamiliaPadre_A_SubFamilia { get => relFamiliaPadre_A_SubFamilia; set => relFamiliaPadre_A_SubFamilia = value; }
        public DataRelation RelFamiliaHija_A_FamiliaPadre { get => relFamiliaHija_A_FamiliaPadre; set => relFamiliaHija_A_FamiliaPadre = value; }
        public DataRelation RelPatenteAFamilia { get => relPatenteAFamilia; set=> relPatenteAFamilia = value; }
        public DataRelation RelUsuario_A_Rol { get => relUsuario_A_Rol; set => relUsuario_A_Rol = value; }
        public DataRelation RelRol_A_Usuario { get => relRol_A_Usuario; set=> relRol_A_Usuario = value; }
        static DAO_? instancia;
        private DAO_()
        {
            ds = new DataSet();
            dtCliente = new DataTable("Cliente");
            dtUsuario = new DataTable("Usuario");
            dtProveedor = new DataTable("Proveedor");
            dtProducto = new DataTable("Producto");
            dtFactura = new DataTable("Factura");
            dtDetalle = new DataTable("Detalle");
            dtIdioma = new DataTable("Idioma");
            dtUsuarioXIdioma = new DataTable("UsuarioXIdioma");
            dtUsuarioXRol = new DataTable("UsuarioXRol");
            dtBitacora = new DataTable("Bitacora");
            dtRol = new DataTable("Rol");
            dtFamilia = new DataTable("Familia");
            dtPatente = new DataTable("Patente");
            dtRolXFamilia = new DataTable("RolXFamilia");
            dtFamiliaXFamilia = new DataTable("FamiliaXFamilia");
            dtRolXPatente = new DataTable("RolXPatente");
            dtPatenteXFamilia = new DataTable("PatenteXFamilia");
            ds.Tables.AddRange(new DataTable[] { dtCliente, dtBitacora,dtUsuario, dtProveedor, dtProducto, dtFactura, dtDetalle, dtRol, dtFamilia, dtPatente, dtRolXFamilia, dtFamiliaXFamilia, dtRolXPatente, dtPatenteXFamilia,dtUsuarioXRol });
            conexion = new SqlConnection("Data Source=.;Initial Catalog=CLOTECH;Integrated Security=True;Trust Server Certificate=True");
            adapCliente = new SqlDataAdapter("SELECT * FROM Cliente", conexion);
            adapUsuario = new SqlDataAdapter("SELECT * FROM Usuario", conexion);
            adapBitacora = new SqlDataAdapter("SELECT * FROM Bitacora", conexion);
            adapProveedor = new SqlDataAdapter("SELECT * FROM Proveedor", conexion);
            adapProducto = new SqlDataAdapter("SELECT * FROM Producto", conexion);
            adapFactura = new SqlDataAdapter("SELECT * FROM Factura", conexion);
            adapDetalle = new SqlDataAdapter("SELECT * FROM Detalle", conexion);
            adapIdioma = new SqlDataAdapter("SELECT * FROM Idioma", conexion);
            adapUsuarioXIdioma = new SqlDataAdapter("SELECT * FROM UsuarioXIdioma", conexion);
            adapUsuarioXRol = new SqlDataAdapter("SELECT * FROM UsuarioXRol", conexion);
            adapRol = new SqlDataAdapter("SELECT * FROM Rol", conexion);
            adapFamilia = new SqlDataAdapter("SELECT * FROM Familia", conexion);
            adapPatente = new SqlDataAdapter("SELECT * FROM Patente", conexion);
            adapRolXFamilia = new SqlDataAdapter("SELECT * FROM RolXFamilia", conexion);
            adapFamiliaXFamilia = new SqlDataAdapter("SELECT * FROM FamiliaXFamilia", conexion);
            adapRolXPatente = new SqlDataAdapter("SELECT * FROM RolXPatente", conexion);
            adapPatenteXFamilia = new SqlDataAdapter("SELECT * FROM PatenteXFamilia", conexion);
            cmbCliente = new SqlCommandBuilder(adapCliente);
            cmbUsuario = new SqlCommandBuilder(adapUsuario);
            cmbBitacora = new SqlCommandBuilder(adapBitacora);
            cmbProveedor = new SqlCommandBuilder(adapProveedor);
            cmbProducto = new SqlCommandBuilder(adapProducto);
            cmbFactura = new SqlCommandBuilder(adapFactura);
            cmbDetalle = new SqlCommandBuilder(adapDetalle);
            cmbIdioma = new SqlCommandBuilder(adapIdioma);
            cmbUsuarioXIdioma = new SqlCommandBuilder(adapUsuarioXIdioma);
            cmbUsuarioXRol = new SqlCommandBuilder(adapUsuarioXRol);
            cmbRol = new SqlCommandBuilder(adapRol);
            cmbFamilia = new SqlCommandBuilder(adapFamilia);
            cmbPatente = new SqlCommandBuilder(adapPatente);
            cmbRolXFamilia = new SqlCommandBuilder(adapRolXFamilia);
            cmbFamiliaXFamilia = new SqlCommandBuilder(adapFamiliaXFamilia);
            cmbRolXPatente = new SqlCommandBuilder(adapRolXPatente);
            cmbPatenteXFamilia = new SqlCommandBuilder(adapPatenteXFamilia);
            ActualizarTablas();
            dtCliente.PrimaryKey = new DataColumn[] { dtCliente.Columns["Id_Cliente"] };
            dtBitacora.PrimaryKey = new DataColumn[] { dtBitacora.Columns["Id_Bitacora"] };
            dtIdioma.PrimaryKey = new DataColumn[] { dtIdioma.Columns["Id_Idioma"] };
            dtUsuarioXIdioma.PrimaryKey = new DataColumn[] { dtUsuarioXIdioma.Columns["Id_Usuario"] };
            dtUsuario.PrimaryKey = new DataColumn[] { dtUsuario.Columns["Id_Usuario"] };
            dtProveedor.PrimaryKey = new DataColumn[] { dtProveedor.Columns["Id_Proveedor"] };
            dtProducto.PrimaryKey = new DataColumn[] { dtProducto.Columns["Id_Producto"] };
            dtFactura.PrimaryKey = new DataColumn[] { dtFactura.Columns["Id_Factura"] };
            dtDetalle.PrimaryKey = new DataColumn[] { dtDetalle.Columns["Id_Detalle"] };
            dtUsuarioXRol.PrimaryKey = new DataColumn[] { dtUsuarioXRol.Columns["Id_Usuario"], dtUsuarioXRol.Columns["Id_Rol"] };
            dtRol.PrimaryKey = new DataColumn[] { dtRol.Columns["Id_Rol"] };
            dtFamilia.PrimaryKey = new DataColumn[] { dtFamilia.Columns["Id_Familia"] };
            dtPatente.PrimaryKey = new DataColumn[] { dtPatente.Columns["Id_Patente"] };
            dtRolXFamilia.PrimaryKey = new DataColumn[] { dtRolXFamilia.Columns["Id_Rol"], dtRolXFamilia.Columns["Id_Familia"] };
            dtFamiliaXFamilia.PrimaryKey = new DataColumn[] { dtFamiliaXFamilia.Columns["Id_Familia"], dtFamiliaXFamilia.Columns["Id_SubFamilia"] };
            dtRolXPatente.PrimaryKey = new DataColumn[] { dtRolXPatente.Columns["Id_Rol"], dtRolXPatente.Columns["Id_Patente"] };
            dtPatenteXFamilia.PrimaryKey = new DataColumn[] { dtPatenteXFamilia.Columns["Id_Patente"], dtPatenteXFamilia.Columns["Id_Familia"] };

            relRolAFamilia = new DataRelation("Rol_A_Familia", dtRol.Columns["Id_Rol"], dtRolXFamilia.Columns["Id_Rol"]);
            relFamiliaAlRol = new DataRelation("Familia_A_Rol", dtFamilia.Columns["Id_Familia"], dtRolXFamilia.Columns["Id_Familia"]);
            relFamiliaPadre_A_SubFamilia = new DataRelation("Familia_Padre_A_SubFamilia", dtFamilia.Columns["Id_Familia"], dtFamiliaXFamilia.Columns["Id_Familia"]);
            relFamiliaHija_A_FamiliaPadre = new DataRelation("Familia_Hija_A_FamiliaPadre", dtFamilia.Columns["Id_Familia"], dtFamiliaXFamilia.Columns["Id_SubFamilia"]);
            relFamiliaAPatente = new DataRelation("Familia_A_Patente", dtFamilia.Columns["Id_Familia"], dtPatenteXFamilia.Columns["Id_Familia"]);
            relPatenteAFamilia = new DataRelation("Patente_A_Familia", dtPatente.Columns["Id_Patente"], dtPatenteXFamilia.Columns["Id_Patente"]);
            relUsuario_A_Rol = new DataRelation("Usuario_A_Rol", dtUsuario.Columns["Id_Usuario"], dtUsuarioXRol.Columns["Id_Usuario"]);
            relRol_A_Usuario = new DataRelation("Rol_A_Usuario", dtRol.Columns["Id_Rol"], dtUsuarioXRol.Columns["Id_Rol"]);
            ds.Relations.AddRange(new DataRelation[] { relUsuario_A_Rol,relRol_A_Usuario,relRolAFamilia, relFamiliaAlRol, relFamiliaPadre_A_SubFamilia, relFamiliaHija_A_FamiliaPadre, relFamiliaAPatente, relPatenteAFamilia });
            
        }
        private void ActualizarTablas()
        {
            adapCliente.Fill(dtCliente);
            adapUsuario.Fill(dtUsuario);
            adapBitacora.Fill(dtBitacora);
            adapProveedor.Fill(dtProveedor);
            adapProducto.Fill(dtProducto);
            adapFactura.Fill(dtFactura);
            adapDetalle.Fill(dtDetalle);
            adapIdioma.Fill(dtIdioma);
            adapUsuarioXIdioma.Fill(dtUsuarioXIdioma);
            adapUsuarioXRol.Fill(dtUsuarioXRol);
            adapRol.Fill(dtRol);
            adapFamilia.Fill(dtFamilia);
            adapPatente.Fill(dtPatente);
            adapRolXFamilia.Fill(dtRolXFamilia);
            adapFamiliaXFamilia.Fill(dtFamiliaXFamilia);
            adapRolXPatente.Fill(dtRolXPatente);
            adapPatenteXFamilia.Fill(dtPatenteXFamilia);
        }
        public void GuardarCambios()
        {
            adapCliente.Update(dtCliente);
            adapUsuario.Update(dtUsuario);
            adapBitacora.Update(dtBitacora);
            adapProveedor.Update(dtProveedor);
            adapProducto.Update(dtProducto);
            adapFactura.Update(dtFactura);
            adapDetalle.Update(dtDetalle);
            adapIdioma.Update(dtIdioma);
            adapUsuarioXIdioma.Update(dtUsuarioXIdioma);
            adapUsuarioXRol.Update(dtUsuarioXRol);
            adapRol.Update(dtRol);
            adapFamilia.Update(dtFamilia);
            adapPatente.Update(dtPatente);
            adapRolXFamilia.Update(dtRolXFamilia);
            adapFamiliaXFamilia.Update(dtFamiliaXFamilia);
            adapRolXPatente.Update(dtRolXPatente);
            adapPatenteXFamilia.Update(dtPatenteXFamilia);
        }
        public static DAO_ ObtenerInstancia()
        {
            if (instancia == null) { instancia = new DAO_(); }
            return instancia;
        }
    }
}
