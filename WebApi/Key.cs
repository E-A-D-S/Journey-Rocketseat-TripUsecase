using System;
using System.Security.Cryptography;

namespace WebApi
{
    public class Key
    {
        public static string Secret
        {
            get
            {
                using (var rng = new RNGCryptoServiceProvider())
                {
                    byte[] keyBytes = new byte[32]; // 256 bits
                    rng.GetBytes(keyBytes);
                    return BitConverter.ToString(keyBytes).Replace("-", "");
                }
            }
        }
    }
}
