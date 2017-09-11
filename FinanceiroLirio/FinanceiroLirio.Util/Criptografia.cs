using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
namespace MinhaSerie.Utilitarios
{
    public class Criptografia
    {
        public static string CriptografarMD5(string valor)
        {
            MD5 md5 = new MD5CryptoServiceProvider();

            byte[] hash = md5.ComputeHash(Encoding.UTF8.GetBytes(valor));

            return BitConverter.ToString(hash).Replace("-", string.Empty);
        }
    }
}
