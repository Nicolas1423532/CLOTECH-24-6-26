using DAO;
using Microsoft.Data.SqlClient;
using SERVICIO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM
{
    public class ORM_DV
    {
        DAO_ dao;
        SERVICIO_DV servicioDV;

        public ORM_DV()
        {
            dao = DAO_.ObtenerInstancia();
            servicioDV = SERVICIO_DV.ObtenerInstancia();
        }

        public void ActualizarDVH(DataTable tabla)
        {
            foreach (DataRow fila in tabla.Rows)
            {
                if (fila.RowState == DataRowState.Deleted) continue;
                object[] valores = servicioDV.ObtenerValoresSinDVH(fila, tabla);
                fila["DVH"] = servicioDV.CalcularDVH(valores);
            }
        }
        public void ActualizarDVV(DataTable tabla, string nombreTabla, string nombreColumnaPK)
        {
            string dvvNuevo = servicioDV.CalcularDVV(tabla, nombreColumnaPK);

            DataRow? filaDVV = dao.DtDVV.Rows.Find(nombreTabla);
            if (filaDVV != null)
                filaDVV["ValorHash"] = dvvNuevo;
        }
        public void ActualizarDVV(DataTable tabla, string nombreTabla, string[] columnasPK)
        {
            string dvvNuevo = servicioDV.CalcularDVV(tabla, columnasPK);

            DataRow? filaDVV = dao.DtDVV.Rows.Find(nombreTabla);
            if (filaDVV != null)
                filaDVV["ValorHash"] = dvvNuevo;
        }
        public bool VerificarDVV(DataTable tabla, string nombreTabla, string nombreColumnaPK)
        {
            foreach (DataRow fila in tabla.Rows)
            {
                if (fila.RowState == DataRowState.Deleted) continue;

                string dvhGuardado = fila["DVH"]?.ToString() ?? "";
                object[] valores = servicioDV.ObtenerValoresSinDVH(fila, tabla);
                string dvhRecalculado = servicioDV.CalcularDVH(valores);

                if (dvhGuardado != dvhRecalculado)
                    return false;
            }
            string dvvCalculado = servicioDV.CalcularDVV(tabla, nombreColumnaPK);

            DataRow? filaDVV = dao.DtDVV.Rows.Find(nombreTabla);
            if (filaDVV == null) return false;

            string dvvGuardado = filaDVV["ValorHash"]?.ToString() ?? "";
            if (string.IsNullOrEmpty(dvvGuardado)) return true;

            return dvvCalculado == dvvGuardado;
        }
        public bool VerificarDVV(DataTable tabla, string nombreTabla, string[] columnasPK)
        {
            foreach (DataRow fila in tabla.Rows)
            {
                if (fila.RowState == DataRowState.Deleted) continue;

                string dvhGuardado = fila["DVH"]?.ToString() ?? "";
                object[] valores = servicioDV.ObtenerValoresSinDVH(fila, tabla);
                string dvhRecalculado = servicioDV.CalcularDVH(valores);

                if (dvhGuardado != dvhRecalculado)
                    return false;
            }
            string dvvCalculado = servicioDV.CalcularDVV(tabla, columnasPK);

            DataRow? filaDVV = dao.DtDVV.Rows.Find(nombreTabla);
            if (filaDVV == null) return false;

            string dvvGuardado = filaDVV["ValorHash"]?.ToString() ?? "";
            if (string.IsNullOrEmpty(dvvGuardado)) return true;

            return dvvCalculado == dvvGuardado;
        }
        public List<string> VerificarIntegridadCompleta()
        {
            //se agrega la vericicacion de la tabla ROLXPATENTE
            var tablasCorruptas = new List<string>();
            var tablas = new (DataTable dt, string nombre, string[] pks)[]
            {
                (dao.DtUsuario,         "Usuario",         new[] { "Id_Usuario" }),
                (dao.DtRol,             "Rol",             new[] { "Id_Rol" }),
                (dao.DtFamilia,         "Familia",         new[] { "Id_Familia" }),
                (dao.DtPatente,         "Patente",         new[] { "Id_Patente" }),
                (dao.DtIdioma,          "Idioma",          new[] { "Id_Idioma" }),
                (dao.DtUsuarioXIdioma_,  "UsuarioXIdioma",  new[] { "Id_Usuario"}),
                (dao.DtUsuarioXRol,     "UsuarioXRol",     new[] { "Id_Usuario", "Id_Rol" }),
                (dao.DtRolXFamilia,     "RolXFamilia",     new[] { "Id_Rol", "Id_Familia" }),
                (dao.DtRolXPatente,    "RolXPatente",     new[] { "Id_Rol", "Id_Patente" }),
                (dao.DtFamiliaXFamilia, "FamiliaXFamilia", new[] { "Id_Familia", "Id_SubFamilia" }),
                (dao.DtPatenteXFamilia, "PatenteXFamilia", new[] { "Id_Patente", "Id_Familia" }),
            };

            foreach (var (dt, nombre, pk) in tablas)
            {
                if (!VerificarDVV(dt, nombre, pk))
                    tablasCorruptas.Add(nombre);
            }

            return tablasCorruptas;
        }
        public void RecalcularTodo()
        {
            //se agrega el recalculo de la tabla ROLXPATENTE
            var tablas = new (DataTable dt, string nombre, string[] pk)[]
            {
                (dao.DtUsuario,         "Usuario",         new[] { "Id_Usuario" }),
                (dao.DtRol,             "Rol",             new[] { "Id_Rol" }),
                (dao.DtFamilia,         "Familia",         new[] { "Id_Familia" }),
                (dao.DtPatente,         "Patente",         new[] { "Id_Patente" }),
                (dao.DtIdioma,          "Idioma",          new[] { "Id_Idioma" }),
                (dao.DtUsuarioXRol,      "UsuarioXRol",     new[] { "Id_Usuario", "Id_Rol" }),
                (dao.DtUsuarioXIdioma_,   "UsuarioXIdioma",  new[] { "Id_Usuario"}),
                (dao.DtRolXFamilia,      "RolXFamilia",     new[] { "Id_Rol",     "Id_Familia" }),
                (dao.DtRolXPatente,    "RolXPatente",     new[] { "Id_Rol", "Id_Patente" }),
                (dao.DtFamiliaXFamilia,  "FamiliaXFamilia", new[] { "Id_Familia", "Id_SubFamilia" }),
                (dao.DtPatenteXFamilia,  "PatenteXFamilia", new[] { "Id_Patente", "Id_Familia" }),
            };

            foreach (var (dt, nombre, pk) in tablas)
            {
                ActualizarDVH(dt);
                ActualizarDVV(dt, nombre, pk);
            }

            dao.GuardarCambios();
        }
        public void GenerarBackup(string rutaDestino)
        {
            string connectionStringMaster = "Data Source=.;Initial Catalog=master;" +
                                            "Integrated Security=True;" +
                                            "Trust Server Certificate=True";

            using (SqlConnection conn = new SqlConnection(connectionStringMaster))
            {
                conn.Open();

                string sqlBackup =
                    $"BACKUP DATABASE CLOTECH TO DISK = '{rutaDestino}' " +
                    $"WITH FORMAT, MEDIANAME = 'CLOTECH_Backup', " +
                    $"NAME = 'Backup completo CLOTECH'";

                using (SqlCommand cmd = new SqlCommand(sqlBackup, conn))
                {
                    cmd.CommandTimeout = 300;
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void RestaurarBackup(string rutaArchivoBak)
        {
            // La conexión del DAO apunta a CLOTECH.
            // Para hacer un RESTORE hay que conectarse a master
            // y forzar que nadie más esté conectado a CLOTECH.
            string connectionStringMaster = "Data Source=.;Initial Catalog=master;" +
                                            "Integrated Security=True;" +
                                            "Trust Server Certificate=True";

            using (SqlConnection conn = new SqlConnection(connectionStringMaster))
            {
                conn.Open();

                string sqlSingleUser =
                    "ALTER DATABASE CLOTECH SET SINGLE_USER WITH ROLLBACK IMMEDIATE";

                using (SqlCommand cmd = new SqlCommand(sqlSingleUser, conn))
                {
                    cmd.ExecuteNonQuery();
                }
                string sqlRestore =
                    $"RESTORE DATABASE CLOTECH FROM DISK = '{rutaArchivoBak}' " +
                    $"WITH REPLACE, RECOVERY";

                using (SqlCommand cmd = new SqlCommand(sqlRestore, conn))
                {
                    cmd.CommandTimeout = 300;
                    cmd.ExecuteNonQuery();
                }

                string sqlMultiUser =
                    "ALTER DATABASE CLOTECH SET MULTI_USER";

                using (SqlCommand cmd = new SqlCommand(sqlMultiUser, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
