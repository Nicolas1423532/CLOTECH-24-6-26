using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SERVICIO
{
    public class SERVICIO_Criptografia
    {
        public static string Encriptar(string textoPlano)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] textoPlanoBytes = Encoding.UTF8.GetBytes(textoPlano);
                byte[] textoPlanoHash = sha256.ComputeHash(textoPlanoBytes);
                StringBuilder sb = new StringBuilder();
                foreach (byte t in textoPlanoHash)
                {
                    sb.Append(t.ToString("x2"));
                }
                return sb.ToString();
            }
        }
        public static string GenerarIDBitacora()
        {
            var generacionIdAuto = Guid.NewGuid().ToString();
            string idBitacora = generacionIdAuto.Substring(0, 10);
            return idBitacora;
        }
    }
}
