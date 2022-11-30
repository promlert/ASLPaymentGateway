using System;
using System.Security.Cryptography;
using System.Text;

namespace ASLPaymentGateway.Utility
{
    public class DataGenerator
    {
        private static Random random = new Random();
        public static long GetCurrentUnixTimestampMillis()
        {
            DateTime UnixEpoch =
    new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return (long)(DateTime.UtcNow - UnixEpoch).TotalMilliseconds;
        }
        public static string GetUniqueKeyOriginal_BIASED(int size)
        {
           
            const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            return new string(Enumerable.Repeat(chars, size)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static byte[] HexStringToByteArray(string hexString)
        {
            MemoryStream stream = new MemoryStream(hexString.Length / 2);
            for (int i = default(int); i < hexString.Length; i += 2)
            {
                stream.WriteByte(byte.Parse(hexString.Substring(i, 2), System.Globalization.NumberStyles.AllowHexSpecifier));
            }
            return stream.ToArray();
        }
    }
}
