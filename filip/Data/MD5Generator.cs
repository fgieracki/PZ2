using System.Security.Cryptography;
using System.Text;

namespace filip.Data;

public class MD5Generator
{
    public static string GenerateMD5Hash(string input)
    {
        using (MD5 md5 = MD5.Create())
        {
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] hashBytes = md5.ComputeHash(inputBytes);

            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < hashBytes.Length; i++)
            {
                builder.Append(hashBytes[i].ToString("x2")); // Convert each byte to its hexadecimal representation
            }

            return builder.ToString();
        }
    }
}