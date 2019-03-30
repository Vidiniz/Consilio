using System.Security.Cryptography;
using System.Text;

namespace ConsilioServices.Application.Validations
{
    public class EncryptData
    {
        public static string EncryptPassword(string value)
        {
            StringBuilder senha = new StringBuilder();

            MD5 md5 = MD5.Create();
            byte[] hash = md5.ComputeHash(Encoding.UTF8.GetBytes(value));
            for (int i = 0; i < hash.Length; i++)
            {
                senha.Append(hash[i].ToString("X2"));
            }
            return senha.ToString();
        }
    }
}
