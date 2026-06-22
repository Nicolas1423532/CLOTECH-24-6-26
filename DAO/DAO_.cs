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
        DataTable dtUsuario, dtProducto, dtCliente, dtProveedor, dtFactura, dtDetalle, dtDevolucion, dtDevolucionDetalle, dtOrdenCompra, dtOrdenCompraDetalle, dtRol, dtFamilia, dtPatente, dtRolXFamilia,dtFamiliaXFamilia,dtRolXPatente,dtPatenteXFamilia, dtUsuarioXRol;
        public DataTable DtUsuario { get => dtUsuario; set => dtUsuario = value; }
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
        public DataTable DtPatenteXFamilia { get => dtPatenteXFamilia; set => dtPatenteXFamilia = value; }
        SqlDataAdapter adapUsuario, adapProducto, adapCliente, adapProveedor, adapFactura, adapDetalle, adapDevolucion, adapDevolucionDetalle, adapOrdenCompra, adapOrdenCompraDetalle, adapUsuarioXRol,adapRol, adapFamilia, adapPatente, adapRolXFamilia, adapFamiliaXFamilia,adapRolXPatente,adapPatenteXFamilia;
        SqlCommandBuilder? cmbUsuario, cmbProducto, cmbCliente, cmbProveedor, cmbFactura, cmbDetalle, cmbDevolucion, cmbDevolucionDetalle, cmbOrdenCompra, cmbOrdenCompraDetalle,cmbUsuarioXRol ,cmbRol, cmbFamilia, cmbPatente, cmbRolXFamilia, cmbRolXPatente, cmbFamiliaXFamilia, cmbPatenteXFamilia;
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
            dtUsuarioXRol = new DataTable("UsuarioXRol");
            dtRol = new DataTable("Rol");
            dtFamilia = new DataTable("Familia");
            dtPatente = new DataTable("Patente");
            dtRolXFamilia = new DataTable("RolXFamilia");
            dtFamiliaXFamilia = new DataTable("FamiliaXFamilia");
            dtRolXPatente = new DataTable("RolXPatente");
            dtPatenteXFamilia = new DataTable("PatenteXFamilia");
            ds.Tables.AddRange(new DataTable[] { dtCliente, dtUsuario, dtProveedor, dtProducto, dtFactura, dtDetalle, dtRol, dtFamilia, dtPatente, dtRolXFamilia, dtFamiliaXFamilia, dtRolXPatente, dtPatenteXFamilia,dtUsuarioXRol });
            conexion = new SqlConnection("Data Source=.;Initial Catalog=CLOTECH;Integrated Security=True;Trust Server Certificate=True");
            adapCliente = new SqlDataAdapter("SELECT * FROM Cliente", conexion);
            adapUsuario = new SqlDataAdapter("SELECT * FROM Usuario", conexion);
            adapProveedor = new SqlDataAdapter("SELECT * FROM Proveedor", conexion);
            adapProducto = new SqlDataAdapter("SELECT * FROM Producto", conexion);
            adapFactura = new SqlDataAdapter("SELECT * FROM Factura", conexion);
            adapDetalle = new SqlDataAdapter("SELECT * FROM Detalle", conexion);
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
            cmbProveedor = new SqlCommandBuilder(adapProveedor);
            cmbProducto = new SqlCommandBuilder(adapProducto);
            cmbFactura = new SqlCommandBuilder(adapFactura);
            cmbDetalle = new SqlCommandBuilder(adapDetalle);
            cmbUsuarioXRol = new SqlCommandBuilder(adapUsuarioXRol);
            cmbRol = new SqlCommandBuilder(adapRol);
            cmbFamilia = new SqlCommandBuilder(adapFamilia);
            cmbPatente = new SqlCommandBuilder(adapPatente);
            cmbRolXFamilia = new SqlCommandBuilder(adapRolXFamilia);
            cmbFamiliaXFamilia = new SqlCommandBuilder(adapFamiliaXFamilia);
            cmbRolXPatente = new SqlCommandBuilder(adapRolXPatente);
            cmbPatenteXFamilia = new SqlCommandBuilder(adapPatenteXFamilia);
            ActualizarTablas();
            dtCliente.PrimaryKey = new DataColumn[] { dtCliente.Columns[0] };
            dtUsuario.PrimaryKey = new DataColumn[] { dtUsuario.Columns[0] };
            dtProveedor.PrimaryKey = new DataColumn[] { dtProveedor.Columns[0] };
            dtProducto.PrimaryKey = new DataColumn[] { dtProducto.Columns[0] };
            dtFactura.PrimaryKey = new DataColumn[] { dtFactura.Columns[0] };
            dtDetalle.PrimaryKey = new DataColumn[] { dtDetalle.Columns[0] };
            dtUsuarioXRol.PrimaryKey = new DataColumn[] { dtUsuarioXRol.Columns[0] };
            dtRol.PrimaryKey = new DataColumn[] { dtRol.Columns[0] };
            dtFamilia.PrimaryKey = new DataColumn[] { dtFamilia.Columns[0] };
            dtPatente.PrimaryKey = new DataColumn[] { dtPatente.Columns[0] };
            dtRolXFamilia.PrimaryKey = new DataColumn[] { dtRolXFamilia.Columns[0] };
            dtFamiliaXFamilia.PrimaryKey = new DataColumn[] { dtFamiliaXFamilia.Columns[0] };
            dtRolXPatente.PrimaryKey = new DataColumn[] { dtRolXPatente.Columns[0] };
            dtPatenteXFamilia.PrimaryKey = new DataColumn[] { dtPatenteXFamilia.Columns[0] };

            relRolAFamilia = new DataRelation("Rol_A_Familia", dtRol.Columns[0], dtRolXFamilia.Columns[1]);
            relFamiliaAlRol = new DataRelation("Familia_A_Rol", dtFamilia.Columns[0], dtRolXFamilia.Columns[2]);
            relFamiliaPadre_A_SubFamilia = new DataRelation("Familia_Padre_A_SubFamilia", dtFamilia.Columns[0], dtFamiliaXFamilia.Columns[1]);
            relFamiliaHija_A_FamiliaPadre = new DataRelation("Familia_Hija_A_FamiliaPadre", dtFamilia.Columns[0], dtFamiliaXFamilia.Columns[2]);
            relFamiliaAPatente = new DataRelation("Familia_A_Patente", dtFamilia.Columns[0], dtPatenteXFamilia.Columns[2]);
            relPatenteAFamilia = new DataRelation("Patente_A_Familia", dtPatente.Columns[0], dtPatenteXFamilia.Columns[1]);
            relUsuario_A_Rol = new DataRelation("Usuario_A_Rol", dtUsuario.Columns[0], dtUsuarioXRol.Columns[1]);
            relRol_A_Usuario = new DataRelation("Rol_A_Usuario", dtRol.Columns[0], dtUsuarioXRol.Columns[2]);
            ds.Relations.AddRange(new DataRelation[] { RelUsuario_A_Rol,relRolAFamilia, relFamiliaAlRol, relFamiliaPadre_A_SubFamilia, relFamiliaHija_A_FamiliaPadre, relFamiliaAPatente, relPatenteAFamilia });

        }
        private void ActualizarTablas()
        {
            adapCliente.Fill(dtCliente);
            adapUsuario.Fill(dtUsuario);
            adapProveedor.Fill(dtProveedor);
            adapProducto.Fill(dtProducto);
            adapFactura.Fill(dtFactura);
            adapDetalle.Fill(dtDetalle);
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
            adapProveedor.Update(dtProveedor);
            adapProducto.Update(dtProducto);
            adapFactura.Update(dtFactura);
            adapDetalle.Update(dtDetalle);
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
