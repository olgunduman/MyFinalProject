using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Hashing
{
   public class HashingHelper
    {
        //şifreyi hashlemeye yarar
        public static void CreatePasswordHash
            (string password, out byte[] passwordHash,out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash((Encoding.UTF8.GetBytes(password)));

            }
        }

        //hashi doğrulama işlemi
        public static bool VerifyPasswrodHash(string password,  byte[] passwordHash,  byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash((Encoding.UTF8.GetBytes(password)));
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

