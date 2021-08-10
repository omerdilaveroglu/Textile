using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Hashing
{
    public class HashingHelper
    {
        // verdiğimiz bir password değerine göre değinin salt ve hash değerini oluşturmaya yarıyor.
        public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key; //Salting için hmac'in Key değerini kullandık 
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password)); //gönderilen stringin byte karşılığı alınır.
            }
        }
        //daha önce kullandığımız passwordSal'ı kullanarak PasswordHash'i doğrulayacayız.
        public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i]!=passwordHash[i])
                    {
                        return false;
                    } 
                }
                return true;
            }

            
        }
    }
}
