using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.Hashing
{
    public class HashingHelper
    {
        public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt) //password'un hashini ve saltını oluşturacak yapıyı içerecek.
        {
            //verdğimiz bir password değerine göre salt ve hash değerini oluşturmaya yarıyor.
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key; //kullandığımız algoritmanın o an oluşturduğu key değeri
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password)); //string'in byte karşılığını almak için
            }
        }

        public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            //sonradan girilen passwordun veri kaynağımızdaki hashle salt'e göre eşleşip eşleşmediğine bakarız.

            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i]!= passwordHash[i])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
